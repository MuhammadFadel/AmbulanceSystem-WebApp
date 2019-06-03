using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystemWebApp.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> SendHttpPostRequest<T>(T requestMessage, string url) where T : new();
        Task<string> SendHttpGetRequest(string parameter, string url);
    }
}
