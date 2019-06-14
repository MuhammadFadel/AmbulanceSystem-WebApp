using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Models;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace AmbulanceSystemWebApp.Controllers
{
    [Route("[controller]/[Action]")]
    public class AccountController : Controller
    {
        private readonly string UserId = SessionSettings.UserId;
        private readonly string Email = SessionSettings.Email;
        private readonly string RoleName = SessionSettings.RoleName;
        private readonly string Hospital = SessionSettings.Hospital;
        private readonly string Authority = SessionSettings.Authority;

        private readonly ISession _session;

        private readonly IAccountService _accountService;
        private readonly IRecieptionistService _recieptionistService;
        private readonly IAuthorityService _authorityService;
        public AccountController(IHttpContextAccessor httpContextAccessor,
                                IAccountService accountService,
                                IRecieptionistService recieptionistService,
                                IAuthorityService authorityService)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _accountService = accountService;
            _recieptionistService = recieptionistService;
            _authorityService = authorityService;
        }



        public IActionResult Login()
        {
            if (_session.GetString(UserId) == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInfoResources loginInfoResources)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(loginInfoResources);
                }
                else
                {
                    var userInfo = await _accountService.Login(loginInfoResources);

                    if (userInfo == null)
                    {
                        ViewBag.userFounded = false;
                        ViewBag.userAuthorized = false;
                        return View();
                    }

                    if (userInfo.RoleName.Equals("Hospital"))
                    {
                        var recieptionistData = await _recieptionistService.GetRecieptionistFullData(userInfo.Id);
                        TempData["recieptionistData"] = JsonConvert.SerializeObject(recieptionistData);
                        TempData.Keep();

                        _session.SetString(Email, userInfo.Email);
                        _session.SetString(UserId, userInfo.Id.ToString());
                        _session.SetString(RoleName, userInfo.RoleName);
                        _session.SetString(Hospital, recieptionistData.HospitalData.HospitalData.Id.ToString());


                        User.AddIdentity(new System.Security.Claims.ClaimsIdentity
                        {
                            Label = _session.GetString(Email)
                        });



                        ViewBag.userEmail = userInfo.Email;
                        return RedirectToAction("Index", "Home");
                    }
                    else if (userInfo.RoleName.Equals("Authority"))
                    {
                        var authorityData = await _authorityService.AuthorityFullData(userInfo.Id);
                        TempData["authorityData"] = JsonConvert.SerializeObject(authorityData);
                        TempData.Keep();

                        _session.SetString(Email, userInfo.Email);
                        _session.SetString(UserId, userInfo.Id.ToString());
                        _session.SetString(RoleName, userInfo.RoleName);
                        _session.SetString(Authority, authorityData.AuthorityFullData.Id.ToString());

                        ViewBag.userEmail = userInfo.Email;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.userFounded = true;
                        ViewBag.userAuthorized = false;
                        return View();
                    }

                }
            }
            
            catch
            {
                ViewBag.userFounded = true;
                ViewBag.userAuthorized = false;
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            var userRole = HttpContext.Session.GetString(RoleName);
            if (userRole == null)
                return RedirectToAction("Index", "Home");
            else if (userRole == "Hospital")
                return RedirectToAction("Dashboard", "Recieptionist");
            else if (userRole == "Authority")
                return RedirectToAction("Dashboard", "Authority");

            //Else Will Go To Home
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            var userId = Guid.Parse(_session.GetString(UserId));
            var roleName = _session.GetString(RoleName);

            var connectionDeleted = await _accountService.Logout(new LogoutInfoResources
            {
                UserId = userId,
                RoleName = roleName
            });

            if(connectionDeleted)
                _session.Clear();
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgetPassword()
        {
            if (HttpContext.Session.GetString(Email) == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (!ModelState.IsValid)
                return View(forgetPasswordViewModel);

            var mailSent = await _accountService.ForgetPassword(forgetPasswordViewModel.Email);

            if (mailSent)
            {
                ViewBag.mailSent = true;
                return View();
            }
            else
            {
                ViewBag.mailSent = false;
                return View(forgetPasswordViewModel);
            }
        }

        [Route("{linkId}")]
        public IActionResult ResetPassword(Guid linkId)
        {
            if (HttpContext.Session.GetString(Email) == null)
            {
                return View(new ConfirmNewPassword {
                    LinkId = linkId
                });
            }                
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPasswordConfirmation(ConfirmNewPassword confirmNewPassword)
        {
            if (!ModelState.IsValid)
                return View("ResetPassword", confirmNewPassword);

            var passwordChanged = await _accountService.ResetPassword(confirmNewPassword);

            if (passwordChanged)
            {
                ViewBag.passwordChanged = true;
                return View("ResetPassword");
            }
            else
            {
                ViewBag.passwordChanged = false;
                return View("ResetPassword", confirmNewPassword);
            }
        }
    }


    public class AuthorizedUser : ActionFilterAttribute, IActionFilter
    {        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString(SessionSettings.Email) == null)
            {                
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller", "Account"},
                    {"Action", "Login"}
                });
            }

            base.OnActionExecuting(context);
        }
    }

}