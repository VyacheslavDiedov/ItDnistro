using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.Models;
using DataBase;
using System.Linq;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        DatabaseContext _db;
        private static int IdTour;

        public HomeController(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("tour-id")]
        public ActionResult GetTourId(int idTour)
        {
            IdTour = idTour;
            return RedirectToAction("Default");
        }

        [HttpGet("default")]
        public IActionResult Default()
        {
            if (IdTour == 0)
            {
                if (_db.TourTypes.FirstOrDefault()?.Id == null)
                {
                    IdTour = 0;
                }
                if (_db.TourTypes.FirstOrDefault()?.Id != null)
                {
                    IdTour = _db.TourTypes.First().Id;
                }
            }
            if (IdTour > 0)
            {
                if (_db.TourTypes.FirstOrDefault()?.Id != null)
                {
                    IdTour = _db.TourTypes.Find(IdTour).Id;
                    ViewBag.TourId = IdTour;
                    ViewBag.TourName = _db.TourTypes.Find(IdTour).TourTypeName;
                    ViewBag.TourDescription = _db.TourTypes.Find(IdTour).TourTypeDescription;
                    ViewBag.DateFrom = _db.TourTypes.Find(IdTour).TourDateFrom.ToShortDateString();
                    ViewBag.DateTo = _db.TourTypes.Find(IdTour).TourDateTo.ToShortDateString();
                    ViewBag.Background =
                        _db.TourPhotoBackgrounds.Where(x => x.TourTypeId == IdTour).FirstOrDefault()?.PhotoLink;
                    ViewBag.BackgroundTwo =
                        _db.TourPhotoBackgrounds.Where(x => x.TourTypeId == IdTour).Skip(1).FirstOrDefault()?.PhotoLink;
                    ViewBag.BackgroundThree =
                        _db.TourPhotoBackgrounds.Where(x => x.TourTypeId == IdTour).Skip(2).FirstOrDefault()?.PhotoLink;
                }
            }
            var item = _db.TourPhotos.Where(x => x.TourTypeId == IdTour).ToList();
            return View(item);
        }

        //[HttpGet("dnistro")]
        //public IActionResult Index()
        //{
        //    return View(_db.TourPhotos.ToList());
        //}

        //[HttpGet("carpaty")]
        //public IActionResult Carpaty()
        //{
        //    return View(_db.TourPhotos.ToList());
        //}

        //[HttpGet("scandinavia")]
        //public IActionResult Scandinavia()
        //{
        //    return View(_db.TourPhotos.ToList());
        //}

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
