using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT_Dnistro.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DatabaseContext _context;

        public DashboardController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// повертає список учасників для таблиці
        /// </summary>

        [HttpGet]
        [Route("gg")]
        public IActionResult GetPartiсipants()
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

        /// <summary>
        /// додає нового учасника в поїздку
        /// </summary>

        public IActionResult AddParticipant()
        {
            ViewData["TourTypeId"] = new SelectList(_context.TourTypes, "Id", "TourTypeName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddParticipant(ParticipantsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Participant participant = new Participant()
                {
                    Id = model.Id,FullName = model.FullName,EMail = model.EMail,PhoneNumber = model.PhoneNumber,
                    TourTypeId = model.TourTypeId
                };
                _context.Add(participant);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(GetPartiсipants));
            }
            return View(model);
        }

        /// <summary>
        /// видаляє учасника з поїздки
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RemoveParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(GetPartiсipants));
        }


    }
}