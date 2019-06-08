using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmbulanceSystem_WebApp.Models;
using AmbulanceSystem_WebApp.Resources;
using AmbulanceSystem_WebApp.Services.Interfaces;
using AmbulanceSystem_WebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AmbulanceSystem_WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthorityController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IHttpClientService _httpClientService;
        private readonly IParamedicService _paramedicService;
        private readonly IOrderService _orderService;

        public AuthorityController(
            IHttpClientService httpClientService,
            IPatientService patientService,
            IParamedicService paramedicService,
            IOrderService orderService)
        {
            _orderService = orderService;
            _patientService = patientService;
            _httpClientService = httpClientService;
            _paramedicService = paramedicService;
        }


        public async Task<IActionResult> Dashboard()
        {
            var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
            var authorityId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Authority));

            if (authorityId != null && roleName == "Authority")
            {
                try
                {

                    var paramedics = await _paramedicService.GetAllParamedicsForAuthority(authorityId);
                    var orders = await _orderService.GetAllOrdersForAuthority(authorityId);
                    AuthorityStatisticsViewModel authorityStatistics = new AuthorityStatisticsViewModel()
                    {
                        AvailableParamedicCount = paramedics.AvailableParamedics.Count(),
                        unAvailableParamedicCount = paramedics.unAvailableParamedics.Count(),
                        FailedOrders = orders.FailedOrders.Count(),
                        FinishedOrders = orders.FinishedOrders.Count()

                    };
                    return View(authorityStatistics);
                }
                catch
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "Home");
        }

        [Route("{patientId}")]
        public async Task<IActionResult> ViewPatient([FromRoute] Guid patientId)
        {
            if (patientId != null)
            {
                var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
                var authorityId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Authority));

                if (authorityId != null && roleName == "Authority")
                {
                    try
                    {
                        var patient = await _patientService.GetPatientWithOrders(patientId);
                        return View(patient);
                    }
                    catch
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("Dashboard");
        }

        [Route("{paramedicId}")]
        public async Task<IActionResult> ViewParamedic(Guid paramedicId)
        {
            if (paramedicId != null)
            {
                var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
                var authorityId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Authority));

                if (authorityId != null && roleName == "Authority")
                {
                    try
                    {
                        var paramedic = await _paramedicService.GetParamedicWithOrders(paramedicId);
                        return View(paramedic);
                    }
                    catch
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("ViewParamedics");
        }


        public async Task<IActionResult> ViewParamedics()
        {
            var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
            var authorityId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Authority));

            if (authorityId != null && roleName == "Authority")
            {
                try
                {
                    var paramedicsData = await _paramedicService.GetAllParamedicsForAuthority(authorityId);
                    return View(paramedicsData);
                }
                catch
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> ViewOrders()
        {

            var roleName = HttpContext.Session.GetString(SessionSettings.RoleName);
            var authorityId = Guid.Parse(HttpContext.Session.GetString(SessionSettings.Authority));

            if (authorityId != null && roleName == "Authority")
            {
                try
                {
                    var orders = await _orderService.GetAllOrdersForAuthority(authorityId);
                    return View(orders);
                }
                catch
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("{authorityId}")]
        public async Task<IActionResult> GetAllParamedicsForAuthority([FromRoute] Guid authorityId)
        {
            if (authorityId == Guid.Empty)
                return BadRequest(null);
            try
            {
                var paramedicsData = await _paramedicService.GetAllParamedicsForAuthority(authorityId);
                return Ok(paramedicsData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{authorityId}")]
        public async Task<IActionResult> GetAllOrdersForAuthority([FromRoute] Guid authorityId)
        {
            if (authorityId == Guid.Empty)
                return BadRequest(null);
            try
            {
                var orders = await _orderService.GetAllOrdersForAuthority(authorityId);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{paramedicId}")]
        public async Task<IActionResult> GetParamedicWithOrders([FromRoute] Guid paramedicId)
        {
            if (paramedicId == Guid.Empty)
                return BadRequest(null);
            try
            {
                var paramedics = await _paramedicService.GetParamedicWithOrders(paramedicId);
                return Ok(paramedics);
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

        [HttpGet("{authorityId}")]
        public async Task<IActionResult> GetAuthorityStatistics([FromRoute] Guid authorityId)
        {
            var paramedics = await _paramedicService.GetAllParamedicsForAuthority(authorityId);
            var orders = await _orderService.GetAllOrdersForAuthority(authorityId);
            AuthorityStatisticsViewModel authorityStatistics = new AuthorityStatisticsViewModel()
            {
                AvailableParamedicCount = paramedics.AvailableParamedics.Count(),
                unAvailableParamedicCount = paramedics.unAvailableParamedics.Count(),
                FailedOrders = orders.FailedOrders.Count(),
                FinishedOrders = orders.FinishedOrders.Count()

            };
            return Ok(authorityStatistics);
        }
    }

}