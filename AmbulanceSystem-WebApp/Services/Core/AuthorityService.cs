using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Services.Core
{
    public class AuthorityService : IAuthorityService
    {
        private readonly IHttpClientService _httpClientService;

        public AuthorityService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<AuthorityEmployeeFullData> AuthorityFullData(Guid userId)
        {
            var responseMessage = await
                _httpClientService.SendHttpGetRequest(userId.ToString(), "Authority/GetEmployeeByUserId/");
            if (string.IsNullOrEmpty(responseMessage))
            {
                return null;
            }

            var authorityFullData = JsonConvert.DeserializeObject<AuthorityEmployeeFullData>(responseMessage);
            return authorityFullData;
        }
    }
}
