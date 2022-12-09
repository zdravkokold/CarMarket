using CarMarket.Services.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarModel>> LastThreeCars();        
        Task<IEnumerable<CarCategoryModel>> AllCategories();
        Task<IEnumerable<CarEngineTypeModel>> AllEngineTypes();
        Task<IEnumerable<CarEuroStandardModel>> AllEuroStandards();
        Task<bool> CategoryExists(int categoryId);
        Task<bool> EngineTypeExists(int engineTypeId);
        Task<bool> EuroStandardExists(int euroStandardId);

        Task<int> Create(CarModel model, int agentId);

        Task<CarsQueryModel> All(
            string? category = null,
            string? engineType = null,
            string? euroStandard = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();
        Task<IEnumerable<string>> AllEngineTypesNames();
        Task<IEnumerable<string>> AllEuroStandardsNames();

        Task<IEnumerable<CarModel>> AllCarsByDealerId(int id);

        Task<IEnumerable<CarModel>> AllCarsByUserId(string userId);

        Task<CarDetailsModel> CarDetailsById(int id);

        Task<bool> Exists(int id);

        Task Edit(int carId, CarModel model);

        Task<bool> HasDealerWithId(int carId, string currentUserId);

        Task<int> GetCarCategoryId(int carId);
        Task<int> GetCarEngineTypeId(int carId);
        Task<int> GetCarEuroStandardId(int carId);

        Task Delete(int carId);

        Task<bool> IsOwned(int carId);

        Task<bool> IsOwnedByUserWithId(int carId, string currentUserId);

        Task Buy(int carId, string currentUserId);

        Task Sell(int carId);
    }
}
