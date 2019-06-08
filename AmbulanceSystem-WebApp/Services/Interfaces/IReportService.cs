using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;

namespace AmbulanceSystem_WebApp.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportTuble>> GetPatientReports(Guid patientId);
        Task<ReportTuble> GetReport(Guid reportId);
        Task<ReportTuble> UpdateReport(ReportResources reportResources);
        Task<ReportTuble> CreateReport(ReportCreationResources reportCreationResources);
    }
}
