using CarMarket.Services.Constants;
using CarMarket.Services.Dealers;
using CarMarket.Services.Models.Dealer;
using CarMarket.Web.Extensions;
using static CarMarket.Areas.Admin.Constants.AdminConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.Web.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        private readonly IDealerService dealerService;

        public DealerController(IDealerService dealerService)
        {
            this.dealerService = dealerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (dealerService.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a dealer!";

                return RedirectToAction("Index", "Home");
            }

            var model = new BecomeDealerModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeDealerModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (dealerService.ExistsById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a dealer!";

                if (User.IsInRole(AdminRoleName))
                {
                    return RedirectToAction("Home", "Home", new { area = AreaName });
                }

                return RedirectToAction("Index", "Home");
            }

            if (dealerService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "The phone already exists!";

                return RedirectToAction("Index", "Home");
            }

            if (dealerService.UserHasCars(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You must not have cars to become a dealer!";

                return RedirectToAction("Index", "Home");
            }

            dealerService.Create(userId, model.PhoneNumber);
            TempData[MessageConstant.SuccessMessage] = "You have successfully become a dealer!!";

            return RedirectToAction("Index", "Home");
        }
    }
}
