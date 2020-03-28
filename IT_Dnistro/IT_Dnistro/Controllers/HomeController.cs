using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.Models;
using DataBase;
using System.Linq;
using IT_Dnistro.ViewModels;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        DatabaseContext _db;
        private static int _idTour = 1;
        List<TourPhoto> _photos;
        List<TourType> _tours;
        public HomeController(DatabaseContext context)
        {
            _db = context;
        }


        [HttpGet("dnistro")]
        public IActionResult Index()
        {
            _photos = new List<TourPhoto>(_db.TourPhotos);
            _tours = new List<TourType>(_db.TourTypes);
            GalleryViewModel gvm = new GalleryViewModel { Tours = _tours, Photos = _photos };
            gvm.Photos = _photos.Where(p => p.TourTypeId == _idTour);
            gvm.Tours = _tours.Where(p => p.Id == _idTour);
            return View(gvm);
        }

        [HttpGet("carpaty")]
        public IActionResult Carpaty()
        {
            return View(_db.TourPhotos.ToList());
        }

        [HttpGet("scandinavia")]
        public IActionResult Scandinavia()
        {
            return View(_db.TourPhotos.ToList());
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}