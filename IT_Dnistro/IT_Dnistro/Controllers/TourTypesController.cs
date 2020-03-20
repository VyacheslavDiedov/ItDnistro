using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBase;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourTypesController : Controller
    {
        private readonly DatabaseContext _context;

        public TourTypesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TourTypes.ToListAsync().ConfigureAwait(true));
        }
        [HttpGet("details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourType = await _context.TourTypes
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(true);
            if (tourType == null)
            {
                return NotFound();
            }

            return View(tourType);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm][Bind("Id,TourTypeName,TourTypeDescription")] TourType tourType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tourType);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            return View(tourType);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourType = await _context.TourTypes.FindAsync(id);
            if (tourType == null)
            {
                return NotFound();
            }
            return View(tourType);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm]int id, [FromForm][Bind("Id,TourTypeName,TourTypeDescription")] TourType tourType)
        {
            if (id != tourType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourType);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourTypeExists(tourType.Id))
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
            return View(tourType);
        }
        [HttpGet("delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourType = await _context.TourTypes
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(true);
            if (tourType == null)
            {
                return NotFound();
            }

            return View(tourType);
        }

        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm]int id)
        {
            var tourType = await _context.TourTypes.FindAsync(id);
            _context.TourTypes.Remove(tourType);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(Index));
        }

        private bool TourTypeExists(int id)
        {
            return _context.TourTypes.Any(e => e.Id == id);
        }
    }
}
