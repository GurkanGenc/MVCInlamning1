using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Data;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    [Authorize(Roles = "Admin")] // Just admin can reach.
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //Categorizes the users according to their roles
            ViewBag.Admins = await _userManager.GetUsersInRoleAsync("Admin");
            ViewBag.Teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            ViewBag.Students = await _userManager.GetUsersInRoleAsync("Student");

            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid) // Checks if there is any available model or not
            {
                var user = new AppUser // This is the exact same thing in Register OnPostAsync method!
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(user, "BytMig123!"); // model.Password can be used here also.

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role); // Gives the first user Admin role.

                    return RedirectToAction("Index", "Users");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            };

            return View();
        }
    }
}
