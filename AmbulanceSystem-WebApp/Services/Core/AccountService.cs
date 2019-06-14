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

        public async Task<bool> Logout(LogoutInfoResources logoutInfoResources)
        {

            var responseMessage = await _httpClientService.SendHttpPostRequest(logoutInfoResources, "users/logout");

            if (string.IsNullOrEmpty(responseMessage))
                return false;

            return true;
        }

        public async Task<Boolean> ForgetPassword(string email)
        {
            try
            {
                var response = await _httpClientService.SendHttpGetRequest(email, "users/forgetpassword/");
                return true;
            }
            catch
            {
                return false;
            }                                   
        }

        public async Task<Boolean> ResetPassword(ConfirmNewPassword confirmNewPassword)
        {
            try
            {
                var response = await _httpClientService.SendHttpPostRequest(confirmNewPassword, "users/ResetPassword/");
                return response.Equals("true");
            }
            catch
            {
                return false;
            }
        }
    }
}
