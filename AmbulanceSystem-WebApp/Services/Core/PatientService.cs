using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Services.Core
{
    
    public class PatientService : IPatientService
    {
        private readonly IHttpClientService _httpClientService;

        public PatientService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<PatientFullData> GetPatientFullData(Guid patientId)
        {
            var responseMessage = await
                _httpClientService.SendHttpGetRequest(patientId.ToString(), "authority/getpatientFulldata/");
            var patient = JsonConvert.DeserializeObject<PatientFullData>(responseMessage);
            return patient;
        }

        public async Task<PatientWithOrders> GetPatientWithOrders(Guid patientId)
        {
            var responseMessage = await
                _httpClientService.SendHttpGetRequest(patientId.ToString(), "authority/GetPatientWithOrders/");
            var patient = JsonConvert.DeserializeObject<PatientWithOrders>(responseMessage);
            return patient;
        }

        public async Task<IEnumerable<PatientFullData>> GetPatientsForHospital(Guid hospitalId)
        {
            var responseMessage = await _httpClientService
                .SendHttpGetRequest(hospitalId.ToString(), "recieptionist/getAllPatientsForHospital/");
            var patients = JsonConvert.DeserializeObject<IEnumerable<PatientFullData>>(responseMessage);
            return patients;
        }
    }
}
