using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IT_Dnistro.Models;
using Microsoft.AspNetCore.Authorization;


namespace IT_Dnistro.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AdminController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        //[Authorize]
        [Route("Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
