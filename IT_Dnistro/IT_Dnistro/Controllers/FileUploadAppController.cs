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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IT_Dnistro.Controllers
{
    public class FileUploadAppController : Controller
    {
            DatabaseContext _context;
            IWebHostEnvironment _appEnvironment;

            public FileUploadAppController(DatabaseContext context, IWebHostEnvironment appEnvironment)
            {
                _context = context;
                _appEnvironment = appEnvironment;
            }

        [Route("Upload")]
        public IActionResult Index()
            {
                return View(_context.TourPhotos.ToList());
            }
            [HttpPost]
            public async Task<IActionResult> AddFile(IFormFile uploadedFile)
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
                    TourPhoto file = new TourPhoto() { PhotoLink = uploadedFile.FileName, TourTypeId = 1 };
                    _context.TourPhotos.Add(file);
                    _context.SaveChanges();
                }



                return RedirectToAction("Index");
            }
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tourPhoto = await _context.TourPhotos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tourPhoto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tourPhoto);
        //}

        //// POST: TourTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tourPhoto = await _context.TourPhotos.FindAsync(id);
        //    _context.TourPhotos.Remove(tourPhoto);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        public ActionResult Delete(int id = 0)
        {
            var tourPhoto = _context.TourPhotos.Find(id);
            if (tourPhoto == null)
            {
                return NotFound();
            }
            return View(tourPhoto as IEnumerable<TourPhoto>);
        }


        //POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                var tourPhoto = _context.TourPhotos.Find(id);
                _context.TourPhotos.Remove(tourPhoto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

    }
}
