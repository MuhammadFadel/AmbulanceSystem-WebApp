using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem.Resources;
using AmbulanceSystem_WebApp.Resources;

namespace AmbulanceSystem_WebApp.Services.Interfaces
{
    public interface IAuthorityService
    {
        Task<AuthorityEmployeeFullData> AuthorityFullData(Guid userId);
    }
}
