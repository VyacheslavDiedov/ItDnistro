using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IT_Dnistro.Models;

namespace IT_Dnistro.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        [Route("carpaty")]
        public IActionResult Carpaty()
        {
            return View();
        }

        DatabaseContext db;
        public HomeController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("scandinavia")]
        public IActionResult Scandinavia()
        {
            return View(db.TourPhotos.ToList());
        }

        //[Route("index")]
        [HttpGet]
        public IActionResult Index()
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
