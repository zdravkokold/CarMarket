using CarMarket.Services.Data;
using CarMarket.Services.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarMarket.Services.Constants.DataConstants.Car;

namespace CarMarket.Services.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength)]
        public string Make { get; set; }

        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; }

        [Required]
        [Range(MinHorsePower, MaxYearProduced)]
        public int HorsePower { get; set; }

        [Required]
        [MinLength(MinPrice)]
        public int Price { get; set; }

        [Required]
        [Range(MinYearProduced, MaxYearProduced)]
        public int YearProduced { get; set; }

        [Required]
        [Range(MinCarMileage, MaxCarMileage)]
        public int Mileage { get; set; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; }


        [Required]
        [StringLength(ImageURLMaxLength, MinimumLength = ImageURLMinLength)]
        public string ImageURL { get; set; }

        [Required]
        [Range(1, 5)]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }


        [Required]
        [Range(1, 4)]
        public int EngineTypeId { get; set; }

        [ForeignKey(nameof(EngineTypeId))]
        public virtual EngineType EngineType { get; set; }


        [Required]
        [Range(1, 6)]
        public int EuroStandardId { get; set; }

        [ForeignKey(nameof(EuroStandardId))]
        public virtual EuroStandard EuroStandard { get; set; } 


        [Required]
        public int DealerId { get; set; }

        [ForeignKey(nameof(DealerId))]
        public virtual Dealer Dealer { get; set; }


        public string? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual ApplicationUser? Owner { get; set; }
    }
}
