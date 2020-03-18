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

        [HttpGet("partiсipant")]
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

        [HttpPut("participant")]
        public IActionResult AddParticipant()
        {
            ViewData["Testik"] = new SelectList(_context.Tours, "Id","TourName");
            ViewData["Testik2"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        [HttpPost("participant")]
        public async Task<IActionResult> AddParticipant(AddParticipantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.HowFoundUs == null)
                {
                    model.HowFoundUs = "null";
                }

                UserTour userTour = new UserTour{ User = model.User, TourId = model.TourId, HowFoundUs = model.HowFoundUs};
                _context.Add(userTour);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction(nameof(GetPartiсipants));
            }
            return View(model);
        }

        [HttpDelete("participant")]
        public IActionResult RemoveParticipant(int id, int tourId)
        {
            return View();
        }
    }
}