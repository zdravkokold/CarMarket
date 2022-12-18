using CarMarket.Services.Admins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarMarket.Areas.Admin.Constants.AdminConstants;

namespace CarMarket.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class UsersController : AdminController
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }


        [HttpGet]
        [Route("/Admin/Users/ShowAllUsers")]
        public async Task<IActionResult> ShowAllUsers()
        {
            var model = userService.All();

            return View(model);
        }
    }
}
