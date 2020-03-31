using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.Models;
using DataBase;
using System.Linq;
using System.Threading.Channels;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        DatabaseContext _db;
        private static int IdTour;
        private string _nameTour = "";

        public HomeController(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("tour-id")]
        public ActionResult GetTourId(int idTour)
        {
            IdTour = idTour;

            _nameTour = _db.TourTypes.Find(IdTour).TourTypeName;
            int position = _nameTour.IndexOf(" ");
            _nameTour = _nameTour.Substring(position + 1);
            for (int i = 0; i < _nameTour.Length; i++)
            {
                if ((((_nameTour[i] >= 'a') && (_nameTour[i] <= 'z')) || ((_nameTour[i] >= 'A') && (_nameTour[i] <= 'Z')) 
                                                                     || _nameTour[i] == '-' || _nameTour[i] == '_'
                                                                     || ((_nameTour[i] >= '0') && (_nameTour[i] <= '9'))) != true)
                {
                    _nameTour = "Index";
                }

                
            }
            Console.WriteLine(_nameTour);
            return Redirect(_nameTour);
        }

        [HttpGet("{_nameTour}")]
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
                if (_db.TourTypes.Find(IdTour)?.Id == null)
                {
                    if (_db.TourTypes.FirstOrDefault()?.Id != null)
                    {
                        IdTour = _db.TourTypes.First().Id;
                    }
                }

                if (_db.TourTypes.Find(IdTour)?.Id != null)
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
