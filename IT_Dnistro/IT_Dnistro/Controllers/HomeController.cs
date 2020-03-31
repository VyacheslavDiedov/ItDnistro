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
        private readonly DatabaseContext _db;

        public HomeController(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("tour-id/{idTourType:int?}")]
        public ActionResult GetTourId(int? idTourType)
        {
            var tourType = _db.TourTypes.Find(idTourType ?? _db.TourTypes.First().Id);
            if (tourType == null)
            {
                Response.StatusCode = 404;
                return View("Error", new ErrorViewModel()
                {
                    //todo fill fields
                });
            }

            var tourPhotos = _db.TourPhotos.Where(x => x.TourTypeId == tourType.Id).ToList();
           
            ViewBag.TourName = tourType.TourTypeName;
            ViewBag.TourDescription = tourType.TourTypeDescription;
            ViewBag.DateFrom = tourType.TourDateFrom.ToShortDateString();
            ViewBag.DateTo = tourType.TourDateTo.ToShortDateString();

            var backgrounds = _db.TourPhotoBackgrounds.Where(x => x.TourTypeId == tourType.Id).ToList();
            if(backgrounds.Count != 3)
                throw new ArgumentException("Not enough images for this tour type");

            ViewBag.Background = backgrounds.First().PhotoLink;
            ViewBag.BackgroundTwo = backgrounds[1].PhotoLink;
            ViewBag.BackgroundThree = backgrounds.Last().PhotoLink;

            return View("Default", tourPhotos);
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
