using CarMarket.Services.Contracts;
using CarMarket.Services.Data;
using CarMarket.Services.Data.Entities;
using CarMarket.Services.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Services
{
    public class CarService : ICarService
    {
        private readonly CarMarketDbContext data;
        public CarService(CarMarketDbContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return data.Categories.Select(c => c.Name).Distinct().ToList();
        }

        public async Task<IEnumerable<string>> AllEngineTypesNames()
        {
            return data.EngineTypes.Select(c => c.Name).Distinct().ToList();
        }

        public async Task<IEnumerable<string>> AllEuroStandardsNames()
        {
            return data.EuroStandards.Select(c => c.Name).Distinct().ToList();
        }

        public async Task Buy(int carId, string currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return data.Categories.Any(c => c.Id == categoryId);
        }

        public async Task<int> Create(CarModel model, int dealerId)
        {
            var car = new Car()
            {
                Make = model.Make,
                Model = model.Model,
                HorsePower = model.HorsePower,
                Price = model.Price,
                YearProduced = model.YearProduced,
                Mileage = model.Mileage,
                Color = model.Color,
                ImageURL = model.ImageURL,
                DealerId = dealerId,
                CategoryId = model.CategoryId,
                EuroStandardId = model.EuroStandardId,
                EngineTypeId = model.EngineTypeId
            };

            await data.Cars.AddAsync(car);
            await data.SaveChangesAsync();

            return car.Id;
        }

        public async Task Delete(int carId)
        {
            var car = data.Cars.FirstOrDefault(c => c.Id == carId);

            data.Remove(car);
            data.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return data.Cars.Any(c => c.Id == id);
        }

        public async Task<int> GetCarCategoryId(int carId)
        {
            Car car = data.Cars.Any(c => c.Id == carId);
            return await car.CategoryId;
        }

        public async Task<bool> HasDealerWithId(int carId, string currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsOwned(int carId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsOwnedByUserWithId(int carId, string currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task Sell(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
