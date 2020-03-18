﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.Models;
using DataBase;
using System.Linq;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        DatabaseContext _db;
        public HomeController(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View(_db.TourPhotos.ToList());
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
