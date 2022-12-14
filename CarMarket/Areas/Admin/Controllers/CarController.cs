using CarMarket.Areas.Admin.Controllers;
using CarMarket.Services.Cars;
using CarMarket.Services.Dealers;
using CarMarket.Web.Areas.Admin.Models;
using CarMarket.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.Web.Areas.Admin.Controllers
{
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
        public async Task<IActionResult> Mine()
        {
            var myCars = new MyCarsViewModel();
            var adminId = User.Id();
            myCars.BoughtCars = await carService.AllCarsByUserId(adminId);
            var dealerId = await dealerService.GetDealerId(adminId);
            myCars.AddedCars = await carService.AllCarsByDealerId(dealerId);

            return View(myCars);
        }
    }
}
