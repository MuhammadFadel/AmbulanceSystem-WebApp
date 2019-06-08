using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AmbulanceSystem_WebApp.Models;
using Microsoft.AspNetCore.Http;

namespace AmbulanceSystem_WebApp.Controllers
{
    [Route("[Controller]/[Action]")]
    [AmbulanceSystemWebApp.Controllers.AuthorizedUser]
    public class RecieptionistController : Controller
    {
        //To Controll Session Data
        private readonly ISession _session;

        private readonly IPatientService _patientService;
        private readonly IHospitalService _hospitalService;
        private readonly IReportService _reportService;
        public RecieptionistController(
            IHttpContextAccessor httpContextAccessor,
            IPatientService patientService,
            IHospitalService hospitalService,
            IReportService reportService
            )
        {
            _session = httpContextAccessor.HttpContext.Session;
            _patientService = patientService;
            _hospitalService = hospitalService;
            _reportService = reportService;
        }


        public async Task<IActionResult> Dashboard()
        {
            var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
            var hospitalId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Hospital));

            if (hospitalId != null && roleName == "Hospital")
            {
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
                    return View(hospitalStatistics);
                }
                catch
                {
                    ViewBag.ErrorLoadingPatients = true;
                    return RedirectToAction("Index", "Home");
                }
            }            
            return RedirectToAction("Login", "Home");
        }


        public async Task<IActionResult> CreateReport()
        {
            var userId = Guid.Parse(_session.GetString(SessionSettings.UserId));
            var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
            var hospitalId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Hospital));

            if (hospitalId != null && roleName == "Hospital")
            {
                try
                {
                    var patients = await _patientService.GetPatientsForHospital(hospitalId);
                    var createReportModel = new CreateReportViewModel
                    {
                        HospitalId = hospitalId
                    };
                    foreach (var patient in patients)
                    {
                        createReportModel.PatientsList.Add(new CreateReportPatientList
                        {
                            Id = patient.Id,
                            Username = patient.User.Username
                        });
                    }

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
        public async Task<IActionResult> CreateReport(CreateReportViewModel createReportViewModel)
        {
            if (!ModelState.IsValid)
                return View(createReportViewModel);

            try
            {
                ReportCreationResources reportCreationResources = new ReportCreationResources
                {
                    HospitalId = createReportViewModel.HospitalId,
                    Description = createReportViewModel.Description,
                    DiseaseName = createReportViewModel.DiseaseName,
                    IsChronicDisease = createReportViewModel.IsChronicDisease,
                    PatientId = createReportViewModel.PatientId
                };

                await _reportService.CreateReport(reportCreationResources);
                _session.SetString("ReportSaved", "true");
                return RedirectToAction("CreateReport");
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


        public async Task<IActionResult> ViewPatients()
        {
            var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
            var hospitalId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Hospital));

            if (hospitalId != null && roleName == "Hospital")
            {
                try
                {
                    var patients = await _patientService.GetPatientsForHospital(hospitalId);
                    return View(patients);
                }
                catch
                {
                    ViewBag.ErrorLoadingPatients = true;
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("{patientId}")]
        public async Task<IActionResult> ViewPatient([FromRoute] Guid patientId)
        {
            var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
            var hospitalId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Hospital));

            if (hospitalId != null && roleName == "Hospital")
            {
                try
                {
                    var patient = await _patientService.GetPatientFullData(patientId);
                    return View(patient);
                }
                catch
                {
                    ViewBag.ErrorLoadingPatients = true;
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
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