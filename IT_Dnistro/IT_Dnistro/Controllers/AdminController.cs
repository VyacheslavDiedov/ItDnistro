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
        [Authorize]
        [Route("Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
