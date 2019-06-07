using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmbulanceSystemWebApp.Controllers
{
    [Route("[controller]/[Action]")]
    public class AccountController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IAccountService _accountService;
        private readonly IRecieptionistService _recieptionistService;
        private readonly IAuthorityService _authorityService;
        public AccountController(IAccountService accountService, IRecieptionistService recieptionistService, IAuthorityService authorityService)
        {
            _accountService = accountService;
            _recieptionistService = recieptionistService;
            _authorityService = authorityService;
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInfoResources loginInfoResources)
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
                    TempData["RecieptionistData"] = recieptionistData;
                    TempData.Keep();

                    HttpContext.Session.SetString("userEmail", userInfo.Email);
                    HttpContext.Session.SetString("userId", userInfo.Id.ToString());
                    HttpContext.Session.SetString("userRole", userInfo.RoleName);
                    return RedirectToAction("Index", "Home");
                }
                else if (userInfo.RoleName.Equals("Authority"))
                {
                    var authorityData = await _authorityService.AuthorityFullData(userInfo.Id);

                    HttpContext.Session.SetString("userEmail", userInfo.Email);
                    HttpContext.Session.SetString("userId", userInfo.Id.ToString());
                    HttpContext.Session.SetString("userRole", userInfo.RoleName);
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

        public IActionResult Dashboard()
        {
            var userRole = HttpContext.Session.GetString("userRole");
            if (userRole == null)            
                return RedirectToAction("Index", "Home");            
            else if (userRole == "Hospital")
                return RedirectToAction("Dashboard", "Recieptionist");
            else if (userRole == "Authority")
                return RedirectToAction("Dashboard", "Authority");

            //Else Will Go To Home
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}