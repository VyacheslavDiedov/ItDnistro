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
            var items = _context.UserTours.Select(x => new ParticipantsViewModel()
            {
                UserId = x.User.Id,
                TourId = x.TourId,
                FullName = x.User.UserName,
                PhoneNumber = x.User.PhoneNumber,
                Email = x.User.Email,
                TourName = x.Tour.TourName
            }).ToList();

            return View(items);
        }

        /// <summary>
        /// додає нового учасника в поїздку
        /// </summary>
        /// <returns></returns>

        public IActionResult AddParticipant()
        {
            ViewData["Testik"] = new SelectList(_context.Tours, "Id","TourName");
            ViewData["Testik2"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        [HttpPost]
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

        /// <summary>
        /// видаляє учасника з поїздки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RemoveParticipant(int id, int tourId)
        {
            return View();
        }


    }
}