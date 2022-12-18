using CarMarket.Services.Models.Car;

namespace CarMarket.Web.Areas.Admin.Models
{
    public class MyCarsViewModel
    {
        public IEnumerable<CarModel> AddedCars { get; set; }
            = new List<CarModel>();

        public IEnumerable<CarModel> BoughtCars { get; set; }
            = new List<CarModel>();
    }
}
