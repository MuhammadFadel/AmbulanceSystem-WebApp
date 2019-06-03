using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem.Resources;

namespace AmbulanceSystemWebApp.Services.Interfaces
{
    public interface IAccountService
    {
         Task<UserLoginReturn> Login(LoginInfoResources loginInfoResources);
    }
}
