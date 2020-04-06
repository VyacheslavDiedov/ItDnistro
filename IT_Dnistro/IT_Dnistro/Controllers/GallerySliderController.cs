using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataBase;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using IT_Dnistro.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class GallerySliderController : Controller
    {
        DatabaseContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        List<TourPhoto> _photos;
        List<TourType> _tours;

        public GallerySliderController(DatabaseContext context, IWebHostEnvironment appEnvironment)
        {
            _db = context;
            _appEnvironment = appEnvironment;
        }

        //todo add parameter isBackground
        [HttpGet("index")]
        public IActionResult Index()
        {
            var tourTypeFirst = _db.TourTypes.FirstOrDefault()?.Id;
            var tourTypeId = _db.TourTypes.Find(DashboardController.IdTour)?.Id;
            _photos = new List<TourPhoto>(_db.TourPhotos);
            _tours = new List<TourType>(_db.TourTypes);
            GalleryViewModel gvm = new GalleryViewModel { Tours = _tours, Photos = _photos };

            if (tourTypeId == null)
            {
                if (tourTypeFirst != null)
                {
                    DashboardController.IdTour = _db.TourTypes.First().Id;
                }
            }

            if (_db.TourTypes.Find(DashboardController.IdTour)?.Id != null)
            {
                gvm.Photos = _photos.Where(p => p.TourTypeId == DashboardController.IdTour);
                gvm.Tours = _tours.Where(p => p.Id == DashboardController.IdTour);
                ViewBag.TourName = _db.TourTypes.Find(DashboardController.IdTour)?.TourTypeName;
            }
            return View(gvm);
        }

        [HttpPost]
        public RedirectToActionResult AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string namePhoto = "";
                if (uploadedFile.FileName.Length <= 15)
                {
                    namePhoto = uploadedFile.FileName;
                }
                else
                {
                    var position = uploadedFile.FileName.IndexOf(".", StringComparison.Ordinal);
                    namePhoto = uploadedFile.FileName.Substring(0, 11) + uploadedFile.FileName.Substring(position);
                }
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + @"\images\Swiper\" + namePhoto, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
                if (DashboardController.IdTour != 0)
                {
                    TourPhoto file = new TourPhoto() { PhotoLink = namePhoto, TourTypeId = DashboardController.IdTour };
                    _db.TourPhotos.Add(file);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var tourPhoto = _db.TourPhotos.Find(id);
            _db.TourPhotos.Remove(tourPhoto);
            _db.SaveChanges();
            string path = _appEnvironment.WebRootPath + @"\images\Swiper\" + tourPhoto.PhotoLink;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Index");
        }
    }
}
