using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using AmbulanceSystem_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Services.Core
{
    public class ParamedicService : IParamedicService
    {
        private readonly IHttpClientService _httpClientService;

        public ParamedicService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;

        }
        public async  Task<ParamedicsViewModel> GetAllParamedicsForAuthority(Guid authorityId)
        {
            var responseMessage = await
                _httpClientService.SendHttpGetRequest(authorityId.ToString(), "authority/GetParamedicsAndCars/");
            var paramedics = JsonConvert.DeserializeObject<IEnumerable<ParamedicAndCarsResources>>(responseMessage);
            ParamedicsViewModel paramedicsData = new ParamedicsViewModel()
            {
                AvailableParamedics = paramedics.Where(p => p.Avalaibility.Equals("A")).ToList(),
                unAvailableParamedics = paramedics.Where(p => p.Avalaibility.Equals("A") == false).ToList()

            };



            return paramedicsData;
        }

        public async Task<ParamedicResources> GetParamedicWithOrders(Guid paramedicId)
        {
            var responseMessage = await
                _httpClientService.SendHttpGetRequest(paramedicId.ToString(), "paramedic/GetParamedicWithOrders/");
            var paramedic = JsonConvert.DeserializeObject<ParamedicResources>(responseMessage);
            return paramedic;
        }
    }
}
