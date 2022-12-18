using CarMarket.Services.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Cars
{
    public interface ICarService
    {
        IEnumerable<CarModel> LastThreeCars();        
        IEnumerable<CarModel> AllCars();        
        IEnumerable<CarCategoryModel> AllCategories();
        IEnumerable<CarEngineTypeModel> AllEngineTypes();
        IEnumerable<CarEuroStandardModel> AllEuroStandards();
        bool CategoryExists(int categoryId);
        bool EngineTypeExists(int engineTypeId);
        bool EuroStandardExists(int euroStandardId);

        CarsQueryModel All(
            string? category = null,
            string? engineType = null,
            string? euroStandard = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        IEnumerable<string> AllCategoriesNames();
        IEnumerable<string> AllEngineTypesNames();
        IEnumerable<string> AllEuroStandardsNames();
        IEnumerable<CarModel> AllCarsByDealerId(int id);
        IEnumerable<CarModel> AllCarsByUserId(string userId);
        CarDetailsModel CarDetailsById(int id);
        bool Exists(int id);
        bool HasDealerWithId(int carId, string currentUserId);
        int GetCarCategoryId(int carId);
        int GetCarEngineTypeId(int carId);
        int GetCarEuroStandardId(int carId);

        void Delete(int carId);

        bool IsBought(int carId);

        bool IsBoughtByUserWithId(int carId, string currentUserId);

        void Buy(int carId, string currentUserId);

        void Sell(int carId);
    }
}
