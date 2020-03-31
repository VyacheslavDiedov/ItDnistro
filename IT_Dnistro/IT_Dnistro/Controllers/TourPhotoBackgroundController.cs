using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using IT_Dnistro.ViewModels;


namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourPhotoBackgroundController : DashboardController
    {
        DatabaseContext _context;
        IWebHostEnvironment _appEnvironment;
        List<TourPhotoBackground> _photos;
        List<TourType> _tours;

        public TourPhotoBackgroundController(DatabaseContext context, IWebHostEnvironment appEnvironment) : base(
            context, appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            _photos = new List<TourPhotoBackground>(_context.TourPhotoBackgrounds);
            _tours = new List<TourType>(_context.TourTypes);
            BackgroundViewModel bvm = new BackgroundViewModel { Tours = _tours, Photos = _photos};
            if (IdTour == 0)
            {
                if (_context.TourTypes.FirstOrDefault()?.Id == null)
                {
                    IdTour = 0;
                }
                if (_context.TourTypes.FirstOrDefault()?.Id != null)
                {
                    IdTour = _context.TourTypes.First().Id;
                }
            }

            bvm.Photos = _photos.Where(p => p.TourTypeId == IdTour);
            bvm.Tours = _tours.Where(p => p.Id == IdTour);
            ViewBag.TourName = _context.TourTypes.Find(IdTour)?.TourTypeName;
            return View(bvm);
        }

        [HttpPost]
        public RedirectToActionResult AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string namePhoto = "";
                if (uploadedFile.FileName.Length <= 35)
                {
                    namePhoto = uploadedFile.FileName;
                }
                else
                {
                    int position = uploadedFile.FileName.IndexOf(".");
                    namePhoto = uploadedFile.FileName.Substring(0, 31) + uploadedFile.FileName.Substring(position);
                }
                using (var fileStream =
                    new FileStream(_appEnvironment.WebRootPath + @"\images\TourBG\" + namePhoto,
                        FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }

                if (IdTour != 0)
                {
                    TourPhotoBackground file = new TourPhotoBackground() {PhotoLink = namePhoto, TourTypeId = IdTour};
                    _context.TourPhotoBackgrounds.Add(file);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var tourPhoto = _context.TourPhotoBackgrounds.Find(id);
            _context.TourPhotoBackgrounds.Remove(tourPhoto);
            _context.SaveChanges();
            string path = _appEnvironment.WebRootPath + @"\images\TourBG\" + tourPhoto.PhotoLink;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Index");
        }
    }
}