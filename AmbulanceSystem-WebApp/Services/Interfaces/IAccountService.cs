using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem.Resources;

namespace AmbulanceSystem_WebApp.Services.Interfaces
{
    public interface IAccountService
    {
         Task<UserLoginReturn> Login(LoginInfoResources loginInfoResources);
    }
}
