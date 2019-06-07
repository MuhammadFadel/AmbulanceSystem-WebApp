using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.ViewModels;

namespace AmbulanceSystem_WebApp.Services.Interfaces
{
    public interface IParamedicService
    {
        Task<ParamedicsViewModel> GetAllParamedicsForAuthority(Guid authorityId);
        Task<ParamedicResources> GetParamedicWithOrders(Guid paramedicId);
    }
}
