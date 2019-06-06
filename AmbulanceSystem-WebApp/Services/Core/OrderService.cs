using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Services.Core
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientService _httpClientService;

        public OrderService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseAllOrders> GetAllOrdersForAuthority(Guid authorityId)
        {
            var responseMessage = await
                _httpClientService.SendHttpGetRequest(authorityId.ToString(), "authority/GetAllOrdersForAuthority/");
            var orders = JsonConvert.DeserializeObject<ResponseAllOrders>(responseMessage);
            return orders;
        }
    }
}
