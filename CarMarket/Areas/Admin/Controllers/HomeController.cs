using CarMarket.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarMarket.Areas.Admin.Constants.AdminConstants;

namespace CarMarket.Web.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController : AdminController
    {
        public async Task<IActionResult> Home()
        {
            return View();
        }
    }
}
