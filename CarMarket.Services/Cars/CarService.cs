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

        public async Task<IEnumerable<CarModel>> AllCarsByDealerId(int id)
        {
            return data.Cars.Where(c => c.DealerId == id)
                .Select(c => new CarModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    Mileage = c.Mileage,
                    HorsePower = c.HorsePower,
                    Price = c.Price,
                    YearProduced = c.YearProduced,
                    Color = c.Color,
                    ImageURL = c.ImageURL,
                    CategoryId = c.CategoryId,
                    EngineTypeId = c.EngineTypeId,
                    EuroStandardId = c.EuroStandardId
                })
                .ToList();
        }

        public async Task<IEnumerable<CarModel>> AllCarsByUserId(string userId)
        {
            return data.Cars.Where(x => x.OwnerId == userId)
                .Select(c => new CarModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    Mileage = c.Mileage,
                    HorsePower = c.HorsePower,
                    Price = c.Price,
                    YearProduced = c.YearProduced,
                    Color = c.Color,
                    ImageURL = c.ImageURL,
                    CategoryId = c.CategoryId,
                    EngineTypeId = c.EngineTypeId,
                    EuroStandardId = c.EuroStandardId
                })
                .ToList();
        }

        public async Task<IEnumerable<CarCategoryModel>> AllCategories()
        {
            return data.Categories.ToList()
            .OrderBy(c => c.Name)
            .Select(c => new CarCategoryModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return data.Categories.Select(c => c.Name).Distinct().ToList();
        }

        public async Task<IEnumerable<CarEngineTypeModel>> AllEngineTypes()
        {
            return data.EngineTypes.ToList()
            .OrderBy(c => c.Name)
            .Select(c => new CarEngineTypeModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
        }

        public async Task<IEnumerable<string>> AllEngineTypesNames()
        {
            return data.EngineTypes.Select(c => c.Name).Distinct().ToList();
        }

        public async Task<IEnumerable<CarEuroStandardModel>> AllEuroStandards()
        {
            return data.EngineTypes.ToList()
            .OrderBy(c => c.Name)
            .Select(c => new CarEuroStandardModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
        }

        public async Task<IEnumerable<string>> AllEuroStandardsNames()
        {
            return data.EuroStandards.Select(c => c.Name).Distinct().ToList();
        }

        public async Task Buy(int carId, string currentUserId)
        {
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);

            if (car != null && car.OwnerId != null)
            {
                throw new ArgumentException("Car is already bought");
            }
            car.OwnerId = currentUserId;

            ApplicationUser user = data.Users.FirstOrDefault(x => x.Id == currentUserId);
            user.Balance -= car.Price;

            await data.SaveChangesAsync();
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
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);

            data.Remove(car);
            await data.SaveChangesAsync();
        }

        public async Task Edit(int carId, CarModel model)
        {
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);

            car.Make = model.Make;
            car.Model = model.Model;
            car.HorsePower = model.HorsePower;
            car.Price = model.Price;
            car.YearProduced = model.YearProduced;
            car.Mileage = model.Mileage;
            car.Color = model.Color;
            car.ImageURL = model.ImageURL;
            car.CategoryId = model.CategoryId;
            car.EuroStandardId = model.EuroStandardId;
            car.EngineTypeId = model.EngineTypeId;

            await data.SaveChangesAsync();
        }

        public async Task<bool> EngineTypeExists(int engineTypeId)
        {
            return data.EngineTypes.Any(c => c.Id == engineTypeId);
        }

        public async Task<bool> EuroStandardExists(int euroStandardId)
        {
            return data.EuroStandards.Any(c => c.Id == euroStandardId);
        }

        public async Task<bool> Exists(int id)
        {
            return data.Cars.Any(c => c.Id == id);
        }

        public async Task<int> GetCarCategoryId(int carId)
        {
            return (data.Cars.FirstOrDefault(c => c.Id == carId)).CategoryId;
        }

        public async Task<int> GetCarEngineTypeId(int carId)
        {
            return (data.Cars.FirstOrDefault(c => c.Id == carId)).EngineTypeId;
        }

        public async Task<int> GetCarEuroStandardId(int carId)
        {
            return (data.Cars.FirstOrDefault(c => c.Id == carId)).EuroStandardId;
        }

        public async Task<bool> HasDealerWithId(int carId, string currentUserId)
        {
            bool result = false;

            var car = data.Cars.Where(c => c.Id == carId).FirstOrDefault();

            if (car?.Dealer != null && car.Dealer.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> IsOwned(int carId)
        {
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);
            return car.OwnerId != null;
        }

        public async Task<bool> IsOwnedByUserWithId(int carId, string currentUserId)
        {
            bool result = false;

            Car car = data.Cars.Where(c => c.Id == carId).FirstOrDefault();

            if (car != null && car.OwnerId == currentUserId)
            {
                result = true;
            }
            return result;
        }

        public async Task Sell(int carId)
        {
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);

            string userId = car.Owner.Id;

            ApplicationUser user = data.Users.FirstOrDefault(x => x.Id == userId);
            user.Balance += car.Price;

            car.OwnerId = null;

            await data.SaveChangesAsync();
        }
    }
}
