using CarMarket.Services.Data;
using CarMarket.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarMarket.Services.Data.Entities;

namespace CarMarket.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName
                
            };

            if (! await roleManager.RoleExistsAsync("Administrator") &&
                ! await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Administrator" });
                await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
            }            

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> CreateRoles()
        //{
        //    await roleManager.CreateAsync(new IdentityRole("Administrator"));
        //    await roleManager.CreateAsync(new IdentityRole("User"));
        //
        //    return RedirectToAction("Index", "Home");
        //}
        //
        //public async Task<IActionResult> AddUsersToRoles()
        //{
        //    string email1 = "stamo.petkov@gmail.com";
        //    string email2 = "pesho@abv.bg";
        //
        //    var user = await userManager.FindByEmailAsync(email1);
        //    var user2 = await userManager.FindByEmailAsync(email2);
        //
        //    await userManager.AddToRoleAsync(user, RoleConstants.Manager);
        //    await userManager.AddToRolesAsync(user2, new string[] { RoleConstants.Supervisor, RoleConstants.Manager });
        //
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
