using CarMarket.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public async Task<IActionResult> Home()
        {
            return View();
        }
    }
}
