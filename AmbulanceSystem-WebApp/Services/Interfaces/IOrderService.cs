using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;

namespace AmbulanceSystem_WebApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseAllOrders> GetAllOrdersForAuthority(Guid authorityId);
    }
}
