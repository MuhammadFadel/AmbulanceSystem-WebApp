using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Models;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace AmbulanceSystem_WebApp.Services.Core
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientService _httpClientService;
        public AccountService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async  Task<UserLoginReturn> Login(LoginInfoResources loginInfoResources)
        {

           var responseMessage = await _httpClientService.SendHttpPostRequest(loginInfoResources, "users/login");

           if (string.IsNullOrEmpty(responseMessage))
               return null;

           var UserData = JsonConvert.DeserializeObject<UserLoginReturn>(responseMessage);
           
            

            return UserData;
        }


        public async Task<Boolean> ForgetPassword(string email)
        {
            var response = await _httpClientService.SendHttpGetRequest(email,"users/forgetpassword/");

            if (response.Equals("false"))
                return false;

            return true;

        }

        public async Task<Boolean> ResetPassword(Guid linkId, ConfirmNewPassword confirmNewPassword)
        {
            var response = await _httpClientService.SendHttpPostRequest(confirmNewPassword, "users/forgetpassword/" + linkId.ToString());

            if (response.Equals("false"))
                return false;

            return true;

        }
    }
}
