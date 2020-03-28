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

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadAppController : DashboardController
    {
        DatabaseContext _db;
        IWebHostEnvironment _appEnvironment;
        List<TourPhoto> _photos;
        List<TourType> _tours;

        public FileUploadAppController(DatabaseContext context, IWebHostEnvironment appEnvironment) : base(context, appEnvironment)
        {
            _db = context;
            _appEnvironment = appEnvironment;
        }

        //public FileUploadAppController(DatabaseContext context, IWebHostEnvironment appEnvironment) : base()
        //{
        //    _db = context;
        //    _appEnvironment = appEnvironment;
        //}


        [HttpGet("upload")]
        public IActionResult Index()
        {
            _photos = new List<TourPhoto>(_db.TourPhotos);
            _tours = new List<TourType>(_db.TourTypes);
            GalleryViewModel gvm = new GalleryViewModel { Tours = _tours, Photos = _photos };
            // якщо є id, створює фільтр фільтрація
            if (IdTour == 0)
            {
                IdTour = 1;
            }

            gvm.Photos = _photos.Where(p => p.TourTypeId == IdTour);
            gvm.Tours = _tours.Where(p => p.Id == IdTour);

            
            return View(gvm);
        }

        [HttpPost]
        public RedirectToActionResult AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null) 
            {
                string path = "/images/Swiper/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
                if (IdTour != 0)
                {
                    TourPhoto file = new TourPhoto() { PhotoLink = uploadedFile.FileName, TourTypeId = IdTour };
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
            string path = _appEnvironment.WebRootPath + "/images/Swiper/" + tourPhoto.PhotoLink;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //[Route("tour-info")]
        //public ActionResult GetTourInfo(int idTour)
        //{
        //    _id = idTour;
        //    return RedirectToAction("Index");
        //}

        
    }
}
