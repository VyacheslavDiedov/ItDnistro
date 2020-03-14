using System;
using DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private DatabaseContext _db;
        public AdminController (DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("adminmain")]
        public IActionResult AdminMainPage()
        {
            Console.WriteLine(HttpContext.User.Identity.Name);
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        //[Route("admin")]
        public IActionResult Admin()
        {
            Console.WriteLine(HttpContext.User.Identity.Name);
            return View();
        }
    }
}
