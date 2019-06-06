using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;

namespace AmbulanceSystem_WebApp.Services.Interfaces
{
    public interface IHospitalService
    {
        Task<BedResource> GetAllBedsForHospital(Guid hospitalId);
    }
}
