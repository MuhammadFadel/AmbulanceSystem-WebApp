using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Newtonsoft.Json;

namespace AmbulanceSystemWebApp.Services
{
    public class RecieptionistService : IRecieptionistService
    {
        private readonly IHttpClientService _httpClientService;

        public RecieptionistService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<RecieptionistFullData> GetRecieptionistFullData(Guid userId)
        {
            var responseMessage = await 
                _httpClientService.SendHttpGetRequest(userId.ToString(), "Recieptionist/GetRecieptionistByUserId/");
            if (string.IsNullOrEmpty(responseMessage))
            {
                return null;
            }

            var RecieptionistData = JsonConvert.DeserializeObject<RecieptionistFullData>(responseMessage);
            return RecieptionistData;
        }
    }
}
