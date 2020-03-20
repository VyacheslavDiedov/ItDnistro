using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using IT_Dnistro.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(GetParticipants));
            }
            return View(model);
        }


        [HttpPost("remove")]
        public async Task<IActionResult> RemoveParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return RedirectToAction(nameof(GetParticipants));
        }
    }
}