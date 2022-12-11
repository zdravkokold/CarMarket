using CarMarket.Services.Models.Car;

namespace CarMarket.Web.Models
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 3;

        public string? Category { get; set; }
        public string? EngineType { get; set; }
        public string? EuroStandard { get; set; }

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
