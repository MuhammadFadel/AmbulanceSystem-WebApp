using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
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
        public AccountController(IAccountService accountService,IRecieptionistService recieptionistService, IAuthorityService authorityService)
        {
            _accountService = accountService;
            _recieptionistService = recieptionistService;
            _authorityService = authorityService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginInfoResources loginInfoResources)
        {
            var userInfo = await _accountService.Login(loginInfoResources);

            if (userInfo == null)
                return BadRequest();
            if (userInfo.RoleName.Equals("Recieptionist"))
            {
                var recieptionistData = await _recieptionistService.GetRecieptionistFullData(userInfo.Id);
                TempData["RecieptionistData"] = recieptionistData;
                TempData.Keep();
                return Ok(recieptionistData);
            }


            if (userInfo.RoleName.Equals("Authority"))
            {
                var authorityData = await _authorityService.AuthorityFullData(userInfo.Id);
                return Ok(authorityData);
            }

            return Ok(userInfo);

        }
    }
}