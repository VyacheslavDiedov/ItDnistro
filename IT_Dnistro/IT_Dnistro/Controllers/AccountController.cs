using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IT_Dnistro.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using IT_Dnistro.Models; // пространство имен UserContext и класса User
using DataBase;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IT_Dnistro.Controllers
{
    public class AccountController : Controller
    {
        private DatabaseContext db;
        public AccountController(DatabaseContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.EMail == model.EMail && u.Password == model.Password).ConfigureAwait(false);
                if (user != null)
                {
                    await Authenticate(model.EMail); // аутентификация

                    return RedirectToAction("Dnictro", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.EMail == model.EMail);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.Users.Add(new User
                    {
                        EMail = model.EMail, 
                        Password = model.Password,
                        BirthDate = model.BirthDate,
                        City = model.City,
                        Country = model.Country,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Gender = model.Gender,
                        Phone = model.Phone
                    });
                    await db.SaveChangesAsync();

                    await Authenticate(model.EMail); // аутентификация

                    return RedirectToAction("Dnictro", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
