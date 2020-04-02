using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataBase;
using IT_Dnistro.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace IT_Dnistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> manager)
        {
            _userManager = manager;
        }
        [HttpGet("index")]
        public IActionResult Index() => View(_userManager.Users.ToList());

        [HttpGet("create")]
        public IActionResult Create() => View();

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm]CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = model.UserName, Email = model.Email, PhoneNumber = model.Phone };
                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id).ConfigureAwait(true);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Phone = user.PhoneNumber };
            return View(model);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromForm]EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByIdAsync(model.Id).ConfigureAwait(true);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    user.PhoneNumber = model.Phone;

                    var result = await _userManager.UpdateAsync(user).ConfigureAwait(true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id).ConfigureAwait(true);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user).ConfigureAwait(true);
            }
            return RedirectToAction("Index");
        }
    }
}
