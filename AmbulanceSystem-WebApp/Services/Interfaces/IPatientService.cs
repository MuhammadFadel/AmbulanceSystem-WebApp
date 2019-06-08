using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;

namespace AmbulanceSystem_WebApp.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientFullData> GetPatientFullData(Guid patientId);
        Task<IEnumerable<PatientFullData>> GetPatientsForHospital(Guid hospitalId);

        Task<PatientWithOrders> GetPatientWithOrders(Guid patientId);
    }

}
