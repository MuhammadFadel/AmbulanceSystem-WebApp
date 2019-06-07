using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Services.Core
{
    public class HospitalService :IHospitalService
    {
        private readonly IHttpClientService _httpClientService;

        public HospitalService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;

        }
        public async Task<BedResource> GetAllBedsForHospital(Guid hospitalId)
        {
            var responseMessage = await _httpClientService.SendHttpGetRequest(hospitalId.ToString(), "recieptionist/gethospitalbeds/");
            var bed = JsonConvert.DeserializeObject<BedResource>(responseMessage);
            return bed;

        }

    }
}
