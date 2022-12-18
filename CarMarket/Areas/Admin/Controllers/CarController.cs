using CarMarket.Areas.Admin.Controllers;
using CarMarket.Services.Cars;
using CarMarket.Services.Dealers;
using CarMarket.Web.Areas.Admin.Models;
using CarMarket.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarMarket.Areas.Admin.Constants.AdminConstants;

namespace CarMarket.Web.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class CarController : AdminController
    {
        private readonly ICarService carService;
        private readonly IDealerService dealerService;

        public CarController(ICarService carService, IDealerService dealerService)
        {
            this.carService = carService;
            this.dealerService = dealerService;
        }

        [HttpGet]
        [Route("/Admin/Car/Mine")]
        public async Task<IActionResult> Mine()
        {
            var myCars = new MyCarsViewModel();
            var adminId = User.Id();
            myCars.BoughtCars = carService.AllCarsByUserId(adminId);
            var dealerId = dealerService.GetDealerId(adminId);
            myCars.AddedCars = carService.AllCarsByDealerId(dealerId);

            return View(myCars);
        }
    }
}
