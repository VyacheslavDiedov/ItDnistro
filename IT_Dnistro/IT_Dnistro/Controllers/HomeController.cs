using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IT_Dnistro.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace IT_Dnistro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        [Route("carpaty")]
        public IActionResult Carpaty()
        {
            return View();
        }
        [HttpGet]
        [Route("scandinavia")]
        public IActionResult Scandinavia()
        {
            return View();
        }
        //[Authorize]
        //[Route("dnistro")]
        [HttpGet]
        public IActionResult Dnistro()
        {
            return View();
       // return Content(User.Identity.Name);

        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
