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

        [Required]
        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength)]
        public string Make { get; set; }

        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Horsepower")]
        [Range(MinHorsePower, MaxHorsePower)]
        public int HorsePower { get; set; }

        [Required]
        [Range(MinPrice, MaxPrice)]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Year Produced")]
        [Range(MinYearProduced, MaxYearProduced)]
        public int YearProduced { get; set; }

        [Required]
        [Range(MinCarMileage, MaxCarMileage)]
        public int Mileage { get; set; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; }


        [Required]
        [Display(Name = "Image URL")]
        [StringLength(ImageURLMaxLength, MinimumLength = ImageURLMinLength)]
        public string ImageURL { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Engine Type")]
        public int EngineTypeId { get; set; }

        [Required]
        [Display(Name = "Euro Standard")]
        public int EuroStandardId { get; set; }

        public bool IsBought { get; set; }

        public IEnumerable<CarCategoryModel> Categories { get; set; } = new List<CarCategoryModel>();
        public IEnumerable<CarEngineTypeModel> EngineTypes { get; set; } = new List<CarEngineTypeModel>();
        public IEnumerable<CarEuroStandardModel> EuroStandards { get; set; } = new List<CarEuroStandardModel>();


    }
}
