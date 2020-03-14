using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataBase;
using System.IO;
using DataBase.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadAppController : Controller
    {
        DatabaseContext _context;
        IWebHostEnvironment _appEnvironment;

        public FileUploadAppController(DatabaseContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        [Route("Upload")]
        public IActionResult Index()
        {
            return View(_context.TourPhotos.ToList());
        }

        [HttpPut("addFileToDnistro")]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null) 
            {
                // путь к папке Files
                string path = "/images/Dnistro/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                TourPhoto file = new TourPhoto() { PhotoLink = uploadedFile.FileName, TourTypeId = 1 };
                _context.TourPhotos.Add(file);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tourPhoto = _context.TourPhotos.Find(id);
            _context.TourPhotos.Remove(tourPhoto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("UploadCarpaty")]
        public IActionResult Carpaty()
        {
            return View(_context.TourPhotos.ToList());
        }

        [HttpPut("addFileToCarpaty")]
        public async Task<IActionResult> AddFileCarpaty(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/images/Carpaty/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                TourPhoto file = new TourPhoto() { PhotoLink = uploadedFile.FileName, TourTypeId = 2 };
                _context.TourPhotos.Add(file);
                _context.SaveChanges();
            }
            return RedirectToAction("Carpaty");
        }
        [HttpGet]
        [Route("UploadScandinavia")]
        public IActionResult Scandinavia()
        {
            return View(_context.TourPhotos.ToList());
        }

        [HttpPut("addFileToScandinavia")]
        public async Task<IActionResult> AddFileScandinavia(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/images/Scandinavia/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                TourPhoto file = new TourPhoto() { PhotoLink = uploadedFile.FileName, TourTypeId = 3 };
                _context.TourPhotos.Add(file);
                _context.SaveChanges();
            }
            return RedirectToAction("Scandinavia");
        }

    }
}
