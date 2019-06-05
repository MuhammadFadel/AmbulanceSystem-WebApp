using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Services.Interfaces;


using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Services.Core
{
    public class HttpClientService : IHttpClientService

    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> SendHttpPostRequest<T>(T requestMessage,string url) where  T : new()
        {
            var client = _httpClientFactory.CreateClient("Api");
            var requestMessageJson = JsonConvert.SerializeObject(requestMessage);
            var content = new StringContent(requestMessageJson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var resultObject = await responseMessage.Content.ReadAsStringAsync();
                return resultObject;
            }

            return string.Empty;
        }

        public async Task<string> SendHttpGetRequest(string parameter, string url)
        {
            var client = _httpClientFactory.CreateClient("Api");
            var urlq = url + parameter;
            var responseMessage = await client.GetAsync(urlq);
            if (responseMessage.IsSuccessStatusCode)
            {
                var resultObject = await responseMessage.Content.ReadAsStringAsync();
                return resultObject;
            }

            return string.Empty;
        }

        
    }
}
