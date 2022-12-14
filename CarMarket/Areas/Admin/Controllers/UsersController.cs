using CarMarket.Services.Admins;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        //[Route("/Admin/[User]/[All]/{id?}")]
        [HttpPost]
        public async Task<IActionResult> AllUsers()
        {
            var model = await userService.All();

            return View("AllUsers", model);
        }
    }
}
