using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Controllers
{
    [Route("[Controller]/[Action]")]
    public class RecieptionistController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        

        public RecieptionistController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreationResources reportCreationResources)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var responseMessage = await
                    _httpClientService.SendHttpPostRequest(reportCreationResources, "report/createreport");
                var report = JsonConvert.DeserializeObject<ReportTuble>(responseMessage);

                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            


        }
        [HttpPost]
        public async Task<IActionResult> UpdateReport([FromBody] ReportResources reportResources)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var responseMessage = await _httpClientService.SendHttpPostRequest(reportResources, "report/updatereport");
                var report = JsonConvert.DeserializeObject<ReportTuble>(responseMessage);
                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{reportId}")]
        public async Task<IActionResult> GetReport([FromRoute] Guid reportId)
        {
            if (reportId == Guid.Empty)
                return BadRequest();

            try
            {
                var responseMessage = await _httpClientService.SendHttpGetRequest(reportId.ToString(), "report/getreport/");
                var report = JsonConvert.DeserializeObject<ReportTuble>(responseMessage);
                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientData(Guid patientId)
        {
            if (patientId == Guid.Empty)
                return BadRequest();

            try
            {
                var responseMessage = await _httpClientService.SendHttpGetRequest(patientId.ToString(), "report/getpatientreport/");
                var reports = JsonConvert.DeserializeObject<IEnumerable<ReportTuble>>(responseMessage);
                return Ok(reports);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{hospitalId}")]
        public async Task<IActionResult> GetAllPatientsForHospital(Guid hospitalId)
        {
            if (hospitalId == Guid.Empty)
                return BadRequest();

            try
            {
                var responseMessage = await _httpClientService
                    .SendHttpGetRequest(hospitalId.ToString(), "recieptionist/getAllPatientsForHospital/");
                var patients = JsonConvert.DeserializeObject<IEnumerable<PatientProfileResources>>(responseMessage);
                return Ok(patients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}