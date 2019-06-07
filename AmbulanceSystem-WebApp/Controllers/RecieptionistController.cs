using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AmbulanceSystem_WebApp.ViewModels;
using AmbulanceSystem_WebApp.Models;
using Microsoft.AspNetCore.Http;

namespace AmbulanceSystem_WebApp.Controllers
{
    [Route("[Controller]/[Action]")]
    public class RecieptionistController : Controller
    {

        private readonly IPatientService _patientService;
        private readonly IHospitalService _hospitalService;
        private readonly IReportService _reportService;
        public RecieptionistController(
            IPatientService patientService,
            IHospitalService hospitalService,
            IReportService reportService
            )
        {
            _patientService = patientService;
            _hospitalService = hospitalService;
            _reportService = reportService;
        }


        public IActionResult Dashboard()
        {
            return View();
        }


        public async Task<IActionResult> CreateReport()
        {
            var hospitalId = Guid.Parse(HttpContext.Session.GetString("userId"));
            var roleName = HttpContext.Session.GetString("userRole");
            if (hospitalId != null && roleName == "Hospital")
            {
                try
                {
                    var patients = await _patientService.GetPatientsForHospital(hospitalId);
                    var createReportModel = new CreateReportViewModel
                    {
                        HospitalId = hospitalId,
                        PatientsList = patients
                    };
                    return View(createReportModel);
                }
                catch
                {
                    ViewBag.ErrorLoadingPatients = true;
                    return View();
                }
            }
            ViewBag.ErrorAuthorize = true;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(ReportCreationResources reportCreationResources)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var report = await _reportService.CreateReport(reportCreationResources);
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
                var report = await _reportService.UpdateReport(reportResources);
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
                var report = await _reportService.GetReport(reportId);
                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientFullData([FromRoute] Guid patientId)
        {
            if (patientId == Guid.Empty)
                return BadRequest(null);
            try
            {
                var patient = await _patientService.GetPatientFullData(patientId);
                return Ok(patient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientReports(Guid patientId)
        {
            if (patientId == Guid.Empty)
                return BadRequest();

            try
            {
                var reports = await _reportService.GetPatientReports(patientId);
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
                var patients = await _patientService.GetPatientsForHospital(hospitalId);
                return Ok(patients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{hospitalId}")]
        public async Task<IActionResult> GetHospitalStatistics([FromRoute] Guid hospitalId)
        {
            if (hospitalId == Guid.Empty)
                return BadRequest();
            try
            {
                var bedResource = await _hospitalService.GetAllBedsForHospital(hospitalId);
                var patients = await _patientService.GetPatientsForHospital(hospitalId);
                HospitalStatisticsViewModel hospitalStatistics = new HospitalStatisticsViewModel()
                {
                    AvailableBedsCount = bedResource.AvailableBeds.Count,
                    UmAvailableBedsCount = bedResource.UnAvailableBeds.Count,
                    PatientsCount = patients.Count()

                };
                return Ok(hospitalStatistics);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }




        }


    }

}