using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarMarket.Services.Constants.DataConstants.Car;

namespace CarMarket.Services.Models.Car
{
    public class CarModel
    {
        public int Id { get; set; }

        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength)]
        public string Make { get; set; }

        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; }

        [Display(Name = "Horsepower")]
        [Range(MinHorsePower, MaxHorsePower)]
        public int HorsePower { get; set; }

        [Range(MinPrice, MaxPrice)]
        public int Price { get; set; }

        [Display(Name = "Year Produced")]
        [Range(MinYearProduced, MaxYearProduced)]
        public int YearProduced { get; set; }

        [Range(MinCarMileage, MaxCarMileage)]
        public int Mileage { get; set; }

        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; }

        [Display(Name = "Image URL")]
        [StringLength(ImageURLMaxLength, MinimumLength = ImageURLMinLength)]
        public string ImageURL { get; set; }

        [Display(Name = "Category")]
        [Range(1, 5)]
        public int CategoryId { get; set; }

        [Display(Name = "Engine Type")]
        [Range(1, 4)]
        public int EngineTypeId { get; set; }

        [Display(Name = "Euro Standard")]
        [Range(1, 6)]
        public int EuroStandardId { get; set; }

        public bool IsBought { get; set; }

        public IEnumerable<CarCategoryModel> Categories { get; set; } = new List<CarCategoryModel>();
        public IEnumerable<CarEngineTypeModel> EngineTypes { get; set; } = new List<CarEngineTypeModel>();
        public IEnumerable<CarEuroStandardModel> EuroStandards { get; set; } = new List<CarEuroStandardModel>();


    }
}
