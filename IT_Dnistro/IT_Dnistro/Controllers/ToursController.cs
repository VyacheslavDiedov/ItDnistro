using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using DataBase;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : Controller
    {
        private readonly DatabaseContext _context;

        public ToursController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("index")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Tours.Include(t => t.TourType);
            return View(await databaseContext.ToListAsync().ConfigureAwait(true));
        }
        [HttpGet("details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.TourType)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(true);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            ViewData["TourTypeId"] = new SelectList(_context.TourTypes, "Id", "TourTypeName");
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TourName,TourTypeId,TourDate,TourLength")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tour);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TourTypeId"] = new SelectList(_context.TourTypes, "Id", "TourTypeName", tour.TourTypeId);
            return View(tour);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            ViewData["TourTypeId"] = new SelectList(_context.TourTypes, "Id", "TourTypeName", tour.TourTypeId);
            return View(tour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourName,TourTypeId,TourDate,TourLength")] Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TourTypeId"] = new SelectList(_context.TourTypes, "Id", "TourTypeName", tour.TourTypeId);
            return View(tour);
        }
        [HttpGet("delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.TourType)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(true);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
    }
}
