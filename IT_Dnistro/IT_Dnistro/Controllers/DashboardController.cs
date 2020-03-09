//using System.Linq;
//using System.Threading.Tasks;
//using DataBase;
//using Microsoft.AspNetCore.Mvc;
//using IT_Dnistro.ViewModels;
//using Microsoft.AspNetCore.Identity;

//namespace IT_Dnistro.Controllers
//{
//    public class DashboardController : Controller
//    {
//        private readonly DatabaseContext _context;

//        public DashboardController(DatabaseContext context)
//        {
//            _context = context;
//        }

//        /// <summary>
//        /// повертає список учасників для таблиці
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        public IActionResult GetPartiсipants()
//        {
//            var items = _context.UserTours.Select(x => new ParticipantsViewModel()
//            {
//                UserId = x.User.Id,
//                TourId = x.TourId,
//                FullName = x.User.UserName,
//                PhoneNumber = x.User.PhoneNumber,
//                Email = x.User.Email,
//                TourName = x.Tour.TourName
//            }).ToList();

//            return View(items);
//        }

//        /// <summary>
//        /// додає нового учасника в поїздку
//        /// </summary>
//        /// <returns></returns>
//        [HttpPost]
//        public async Task<IActionResult> AddParticipant(/*Todo create new partis view model*/)
//        {

//            return View();
//        }

//        /// <summary>
//        /// видаляє учасника з поїздки
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        public IActionResult RemoveParticipant(int id, int tourId)
//        {
//            return View();
//        }

     
//    }
//}
