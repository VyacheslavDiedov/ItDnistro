﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.Models;
using DataBase;
using System.Linq;
using System.Threading.Channels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            var tourType = _db.TourTypes.Find(idTourType ?? _db.TourTypes.FirstOrDefault()?.Id);
            if (tourType == null)
            {
                Response.StatusCode = 404;
                return View("Error404", new ErrorViewModel()
                {
                    //todo fill fields
                });
            }

            var tourPhotos = _db.TourPhotos.Where(x => x.TourTypeId == tourType.Id).Where(x => x.ToutPhotoTypeId == 1).ToList();

            ViewBag.TourId = tourType.Id;
            ViewBag.TourName = tourType.TourTypeName;
            ViewBag.TourTagName = tourType.TourTypeTagName;
            ViewBag.TourTypeDescription = tourType.TourTypeDescription;
            ViewBag.DateFrom = tourType.TourDateFrom.ToShortDateString();
            ViewBag.DateTo = tourType.TourDateTo.ToShortDateString();

            var backgrounds = _db.TourPhotos.Where(x => x.TourTypeId == tourType.Id).Where(x => x.ToutPhotoTypeId == 2).ToList();
            if (backgrounds.Count > 0)
            {
                ViewBag.Background = backgrounds.FirstOrDefault()?.PhotoLink;
                ViewBag.BackgroundTwo = backgrounds.Skip(1).FirstOrDefault()?.PhotoLink;
                ViewBag.BackgroundThree = backgrounds.Skip(2).FirstOrDefault()?.PhotoLink;
            }
            return View("Default", tourPhotos);
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("home/setdata")]
        public ActionResult SetData(Participant item)
        {
            Participant participant = new Participant()
            {
                Id = item.Id,
                FullName = item.FullName,
                EMail = item.EMail,
                PhoneNumber = item.PhoneNumber,
                TourTypeId = item.TourTypeId
            };
            _db.Add(participant);
            var TourType = _db.TourTypes.Find(item.TourTypeId);
            TourType.Amount++;
            _db.SaveChanges();

            return Ok();
        }

        [HttpGet("error404")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error404()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
