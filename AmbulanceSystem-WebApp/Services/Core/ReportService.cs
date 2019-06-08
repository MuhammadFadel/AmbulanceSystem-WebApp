using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Services.Core
{
    public class ReportService : IReportService
    {
        private readonly IHttpClientService _httpClientService;

        public ReportService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<IEnumerable<ReportTuble>> GetPatientReports(Guid patientId)
        {
            var responseMessage = await _httpClientService.SendHttpGetRequest(patientId.ToString(), "report/getpatientreport/");
            var reports = JsonConvert.DeserializeObject<IEnumerable<ReportTuble>>(responseMessage);
            return reports;
        }

        public async Task<ReportTuble> GetReport(Guid reportId)
        {
            var responseMessage = await _httpClientService.SendHttpGetRequest(reportId.ToString(), "report/getreport/");
            var report = JsonConvert.DeserializeObject<ReportTuble>(responseMessage);
            return report;
        }

        public async Task<ReportTuble> UpdateReport(ReportResources reportResources)
        {
            var responseMessage = await _httpClientService.SendHttpPostRequest(reportResources, "report/updatereport");
            var report = JsonConvert.DeserializeObject<ReportTuble>(responseMessage);
            return report;
        }

        public async Task<ReportTuble> CreateReport(ReportCreationResources reportCreationResources)
        {
            var responseMessage = await
                _httpClientService.SendHttpPostRequest(reportCreationResources, "report/createreport");
            var report = JsonConvert.DeserializeObject<ReportTuble>(responseMessage);

            return report;
        }
    }
}
