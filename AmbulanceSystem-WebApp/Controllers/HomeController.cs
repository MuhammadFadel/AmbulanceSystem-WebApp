using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AmbulanceSystem_WebApp.Models;
using Microsoft.AspNetCore.Http;

namespace AmbulanceSystem_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.IsAvailable)
            {
                ViewBag.userEmail = HttpContext.Session.GetString("userEmail");
            }
            return View();
        }        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
