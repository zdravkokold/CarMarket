using CarMarket.Services.Cars;
using CarMarket.Services.Constants;
using CarMarket.Services.Dealers;
using CarMarket.Services.Models.Car;
using CarMarket.Web.Extensions;
using CarMarket.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;
using static CarMarket.Areas.Admin.Constants.AdminConstants;

namespace CarMarket.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {

        private readonly ICarService carService;

        private readonly IDealerService dealerService;

        public CarController(ICarService carService, IDealerService dealerService)
        {
            this.carService = carService;
            this.dealerService = dealerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllCarsQueryModel query)
        {
            var result = carService.All(
                query.Category,
                query.EngineType,
                query.EuroStandard,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsPerPage);

            query.TotalCarsCount = result.TotalCarsCount;
            query.Categories = carService.AllCategoriesNames();
            query.EngineTypes = carService.AllEngineTypesNames();
            query.EuroStandards = carService.AllEuroStandardsNames();
            query.Cars = result.Cars;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Mine", "Car", new { area = AreaName });
            }

            IEnumerable<CarModel> myCars;
            var userId = User.Id();

            if (dealerService.ExistsById(userId))
            {
                int dealerId = dealerService.GetDealerId(userId);
                myCars = carService.AllCarsByDealerId(dealerId);
            }
            else
            {
                myCars = carService.AllCarsByUserId(userId);
            }

            return View(myCars);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((carService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = carService.CarDetailsById(id);

            return View(model);
        }        

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((carService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "That car does not exist!";

                return RedirectToAction(nameof(All));
            }

            if ((carService.HasDealerWithId(id, User.Id())) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "That car is not yours!";

                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var car = carService.CarDetailsById(id);
            var model = new CarDetailsModel()
            {
                Id = id,
                CategoryId = car.CategoryId,
                EngineTypeId = car.EngineTypeId,
                EuroStandardId = car.EuroStandardId,
                Make = car.Make,
                Model = car.Model,
                Mileage = car.Mileage,
                HorsePower = car.HorsePower,
                Price = car.Price,
                YearProduced = car.YearProduced,
                Color = car.Color,
                ImageURL = car.ImageURL,
                IsBought = car.IsBought
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CarDetailsModel model)
        {
            if (carService.Exists(id) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "That car does not exist!";

                return RedirectToAction(nameof(All));
            }

            if ((carService.HasDealerWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            carService.Delete(id);

            TempData[MessageConstant.SuccessMessage] = "You have successfully deleted a car!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            if ((carService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "That car does not exist!";

                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRoleName) && dealerService.ExistsById(User.Id()))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (carService.IsBought(id))
            {
                TempData[MessageConstant.ErrorMessage] = "That car is already bought!";

                return RedirectToAction(nameof(All));
            }

            carService.Buy(id, User.Id());

            TempData[MessageConstant.SuccessMessage] = "You have successfully bought a car!";

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Sell(int id)
        {
            if ((carService.Exists(id)) == false ||
                (carService.IsBought(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((carService.IsBoughtByUserWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            carService.Sell(id);

            TempData[MessageConstant.SuccessMessage] = "You have successfully sold a car!";

            return RedirectToAction(nameof(Mine));
        }
    }
}
