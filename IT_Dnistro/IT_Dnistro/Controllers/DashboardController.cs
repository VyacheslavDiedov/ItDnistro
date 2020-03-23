using System;
using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly DatabaseContext _context;

        public DashboardController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("participant")]
        public IActionResult GetParticipants()
        {
            var items = _context.Participants.Select(x => new ParticipantsViewModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                EMail = x.EMail,
                PhoneNumber = x.PhoneNumber,
                TourName = x.TourType.TourTypeName
            }).ToList();
            return View(items);
        }

        [HttpGet("add")]
        public IActionResult AddParticipant()
        {
            ViewData["TourTypeId"] = new SelectList(_context.TourTypes, "Id", "TourTypeName");
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddParticipant([FromForm]ParticipantsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Participant participant = new Participant()
                {
                    Id = model.Id,
                    FullName = model.FullName,
                    EMail = model.EMail,
                    PhoneNumber = model.PhoneNumber,
                    TourTypeId = model.TourTypeId
                };
                _context.Add(participant);
                var TourType = await _context.TourTypes.FindAsync(model.TourTypeId);
                TourType.Amount++;
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(GetParticipants));
            }
            return View(model);
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["TourTypeId"] = new SelectList(_context.TourTypes, "Id", "TourTypeName");
            if (id == null)
            {
                return NotFound();
            }

            var Participant = await _context.Participants.FindAsync(id);
            if (Participant == null)
            {
                return NotFound();
            }

            return View(Participant);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromForm]int id, [FromForm]Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync().ConfigureAwait(true);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(GetParticipants));
            }
            return View(participant);
        }


        [HttpPost("remove")]
        public async Task<IActionResult> RemoveParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            _context.Participants.Remove(participant);
            var TourType = await _context.TourTypes.FindAsync(participant.TourTypeId);
            TourType.Amount--;
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(GetParticipants));
        }
    }
}