using System;
using DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Dnistro.Controllers
{
    public class AdminController : Controller
    {
        private DatabaseContext _db;
        public AdminController (DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("admin")]
        public IActionResult Admin()
        {
            Console.WriteLine(HttpContext.User.Identity.Name);
            return View();
        }
    }
}
