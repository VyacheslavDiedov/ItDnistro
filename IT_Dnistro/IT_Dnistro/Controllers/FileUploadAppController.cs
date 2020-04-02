﻿using System;
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
    public class FileUploadAppController : DashboardController
    {
        DatabaseContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
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

            gvm.Photos = _photos.Where(p => p.TourTypeId == IdTour);
            gvm.Tours = _tours.Where(p => p.Id == IdTour);
            ViewBag.TourName = _db.TourTypes.Find(IdTour)?.TourTypeName;
            
            return View(gvm);
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
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + @"\images\Swiper\" + namePhoto, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
                if (IdTour != 0)
                {
                    TourPhoto file = new TourPhoto() { PhotoLink = namePhoto, TourTypeId = IdTour };
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

        //[HttpGet]
        //[Route("tour-info")]
        //public ActionResult GetTourInfo(int idTour)
        //{
        //    Console.WriteLine(IdTour);
        //    return RedirectToAction("Index");
        //}


    }
}
