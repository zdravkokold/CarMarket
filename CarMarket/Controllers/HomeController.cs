using CarMarket.Areas.Admin.Controllers;
using CarMarket.Models;
using CarMarket.Services.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static CarMarket.Areas.Admin.Constants.AdminConstants;

namespace CarMarket.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Home", "Home", new { area = AreaName }); 
            }

            var model = carService.AllCars();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}