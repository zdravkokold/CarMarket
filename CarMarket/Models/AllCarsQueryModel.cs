using CarMarket.Services.Models.Car;
using System.ComponentModel.DataAnnotations;

namespace CarMarket.Web.Models
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 3;
        
        [Display(Name = "Category")]
        public string? Category { get; set; }

        [Display(Name = "Engine Type")]
        public string? EngineType { get; set; }

        [Display(Name = "Euro Standard")]
        public string? EuroStandard { get; set; }

        [Display(Name = "Search")]
        public string? SearchTerm { get; set; }

        public CarSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalCarsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> EuroStandards { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> EngineTypes { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<CarModel> Cars { get; set; } = Enumerable.Empty<CarModel>();
    }
}
