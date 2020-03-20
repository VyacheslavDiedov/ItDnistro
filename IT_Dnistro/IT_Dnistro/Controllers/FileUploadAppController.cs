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
    public class FileUploadAppController : Controller
    {
        DatabaseContext _context;
        IWebHostEnvironment _appEnvironment;
        private static int _id;
        List<DataBase.TourPhoto> photos;
        List<DataBase.TourType> tours;

        public FileUploadAppController(DatabaseContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet("upload")]
        public IActionResult Index()
        {
            photos = new List<TourPhoto>(_context.TourPhotos);
            tours = new List<TourType>(_context.TourTypes);
            // На 1 місце
            tours.Insert(0, new TourType() { Id = 0, TourTypeName = "Все" });
            GalleryViewModel gvm = new GalleryViewModel { Tours = tours, Photos = photos };
            // якщо є id, створює фільтр фільтрація
            if (_id > 0)
            {
                gvm.Photos = photos.Where(p => p.TourTypeId == _id);
            }
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
                     uploadedFile.CopyToAsync(fileStream).ConfigureAwait(true);
                }
                if(_id != 0)
                {
                    TourPhoto file = new TourPhoto() { PhotoLink = uploadedFile.FileName, TourTypeId = _id };
                    _context.TourPhotos.Add(file);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet("getId")]
        public ActionResult GetIdTour(int idTour)
        {
            _id = idTour;
            Console.WriteLine("присвоїти - " + _id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteConfirmed(int id)
        {
            var tourPhoto = _context.TourPhotos.Find(id);
            _context.TourPhotos.Remove(tourPhoto);
            _context.SaveChanges();
            string path = _appEnvironment.WebRootPath + "/images/Swiper/" + tourPhoto.PhotoLink;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Index");
        }
    }
}
