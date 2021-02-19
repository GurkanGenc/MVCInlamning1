//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using SchoolApp.Data;
//using SchoolApp.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SchoolApp.Controllers
//{
//    // This is the new Register back-end
//    public class CreateUserController : Controller
//    {
//        private readonly SignInManager<AppUser> _signInManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly UserManager<AppUser> _userManager;

//        public CreateUserController(
//            SignInManager<AppUser> signInManager,
//            RoleManager<IdentityRole> roleManager,
//            UserManager<AppUser> userManager)
//        {
//            _signInManager = signInManager;
//            _roleManager = roleManager;
//            _userManager = userManager;
//        }

//        public IActionResult Index()
//        {
//            if (!_userManager.Users.Any())
//                return View();

//            return RedirectToAction("Index", "Home");
//        }

//        // When a form send(post), this will be used and it will be created a user.
//        [HttpPost]
//        public async Task<IActionResult> Index(CreateUserViewModel model)
//        {
//            if (ModelState.IsValid) // Checks if there is any available model or not
//            {
//                var user = new AppUser // This is the exact same thing in Register OnPostAsync method!
//                {
//                    UserName = "admin@domain.com", // model.Email can be used instead of "admin@domain.com".
//                    Email = "admin@domain.com",
//                    FirstName = "Admin",
//                    LastName = "Account"
//                };

//                var result = await _userManager.CreateAsync(user, "BytMig123!"); // model.Password can be used here also.

//                if (result.Succeeded)
//                {
//                    await _roleManager.CreateAsync(new IdentityRole("Admin")); // Creates roles.
//                    await _roleManager.CreateAsync(new IdentityRole("Teacher"));
//                    await _roleManager.CreateAsync(new IdentityRole("Student"));

//                    await _userManager.AddToRoleAsync(user, "Admin"); // Gives the first user Admin role.
//                    await _signInManager.SignInAsync(user, isPersistent: false);
//                    return RedirectToAction("Index", "Home");
//                }

//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError(string.Empty, error.Description);
//                }
//            };

//            return View();
//        }
//    }
//}


// It seems it is useless, it can be DELETED