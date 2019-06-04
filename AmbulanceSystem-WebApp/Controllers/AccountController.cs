using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem.Resources;

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
        public AccountController(IAccountService accountService,IRecieptionistService recieptionistService)
        {
            _accountService = accountService;
            _recieptionistService = recieptionistService;

        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginInfoResources loginInfoResources)
        {
            var userInfo = await _accountService.Login(loginInfoResources);

            if (userInfo == null)
                return BadRequest();
            if (userInfo.RoleName.Equals("Recieptionist"))
            {
                var RecieptionistData = await _recieptionistService.GetRecieptionistFullData(userInfo.Id);
                return Ok(RecieptionistData);
            }


            if (userInfo.RoleName.Equals("Authority"))
            {
                //var AuthorityData= 
                //return View();
            }

            return Ok(userInfo);

        }
    }
}