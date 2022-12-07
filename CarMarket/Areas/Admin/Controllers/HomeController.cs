using CarMarket.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
