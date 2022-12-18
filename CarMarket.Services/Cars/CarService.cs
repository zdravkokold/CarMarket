using CarMarket.Services.Data.Entities;
using CarMarket.Services.Models.Car;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CarMarket.Services.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace CarMarket.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly CarMarketDbContext data;
        public CarService(CarMarketDbContext data)
        {
            this.data = data;
        }

        public CarsQueryModel All(
            string? category = null, 
            string? engineType = null,
            string? euroStandard = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int carsPerPage = 1)
        {
            var result = new CarsQueryModel();
            List<Car> cars = data.Cars.ToList();

            if (string.IsNullOrEmpty(category) == false)
            {
                cars = cars.Where(h => h.Category.Name == category).ToList();
            }

            if (string.IsNullOrEmpty(engineType) == false)
            {
                cars = cars.Where(h => h.EngineType.Name == engineType).ToList();
            }

            if (string.IsNullOrEmpty(euroStandard) == false)
            {
                cars = cars.Where(h => h.EuroStandard.Name == euroStandard).ToList();
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {                
                cars = cars
                .Where(x => x.Make.ToLower().Contains(searchTerm.ToLower()) ||
                            x.Model.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
            }

            cars = sorting switch
            {
                CarSorting.Price => cars.OrderBy(h => h.Price).ToList(),
                CarSorting.NotBoughtFirst => cars.Where(h => h.OwnerId == null).ToList(),
                _ => cars.OrderByDescending(h => h.Id).ToList()
            };

            result.Cars = cars
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .Select(c => new CarModel()
                {
                    Id = c.Id,
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
                    EuroStandardId = c.EuroStandardId,
                    IsBought = c.OwnerId != null
                })
                .ToList();

            result.TotalCarsCount = cars.Count();

            return result;
        }

        public IEnumerable<CarModel> AllCars()
        {
            return data.Cars
            .OrderByDescending(x => x.Id)
            .Select(h => new CarModel()
            {
                Id = h.Id,
                Make = h.Make,
                Model = h.Model,
                HorsePower = h.HorsePower,
                Price = h.Price,
                YearProduced = h.YearProduced,
                Mileage = h.Mileage,
                Color = h.Color,
                ImageURL = h.ImageURL,
                CategoryId = h.CategoryId,
                EuroStandardId = h.EuroStandardId,
                EngineTypeId = h.EngineTypeId,
                IsBought = h.OwnerId != null
            })
            .ToList();
        }

        public IEnumerable<CarModel> AllCarsByDealerId(int id)
        {
            return data.Cars.Where(c => c.DealerId == id)
                .Select(c => new CarModel()
                {
                    Id = c.Id,
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
                    EuroStandardId = c.EuroStandardId,
                    IsBought = c.OwnerId != null
                })
                .ToList();
        }

        public IEnumerable<CarModel> AllCarsByUserId(string userId)
        {
            return data.Cars.Where(x => x.OwnerId == userId)
                .Select(c => new CarModel()
                {
                    Id = c.Id,
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
                    EuroStandardId = c.EuroStandardId,
                    IsBought = c.OwnerId != null
                })
                .ToList();
        }

        public IEnumerable<CarCategoryModel> AllCategories()
        {
            return data.Categories
            .OrderBy(c => c.Id)
            .Select(c => new CarCategoryModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
        }

        public IEnumerable<string> AllCategoriesNames()
        {
            return data.Categories.Select(c => c.Name).Distinct().ToList();
        }

        public IEnumerable<CarEngineTypeModel> AllEngineTypes()
        {
            return data.EngineTypes
            .OrderBy(c => c.Id)
            .Select(c => new CarEngineTypeModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
        }

        public IEnumerable<string> AllEngineTypesNames()
        {
            return data.EngineTypes.Select(c => c.Name).Distinct().ToList();
        }

        public IEnumerable<CarEuroStandardModel> AllEuroStandards()
        {
            return data.EuroStandards
            .OrderBy(c => c.Id)
            .Select(c => new CarEuroStandardModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
        }

        public IEnumerable<string> AllEuroStandardsNames()
        {
            return data.EuroStandards.Select(c => c.Name).Distinct().ToList();
        }

        public void Buy(int carId, string currentUserId)
        {
            Car car = data.Cars.Find(carId);

            if (car != null && car.OwnerId != null)
            {
                throw new ArgumentException("Car is already bought");
            }
            car.OwnerId = currentUserId;                                  

            data.SaveChanges();
        }

        public CarDetailsModel CarDetailsById(int id)
        {
            return data.Cars.Where(x => x.Id == id)
                .Select(c => new CarDetailsModel()
                {
                    Id = c.Id,
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
                    EuroStandardId = c.EuroStandardId,
                    IsBought = c.OwnerId != null,
                    Category = c.Category.Name,
                    EuroStandard = c.EuroStandard.Name,
                    EngineType = c.EngineType.Name,
                    Dealer = new Models.Dealer.DealerModel()
                    {
                        Email = c.Dealer.User.Email,
                        PhoneNumber = c.Dealer.PhoneNumber
                    }
                })
                .First();
        }

        public bool CategoryExists(int categoryId)
        {
            return data.Categories.Any(c => c.Id == categoryId);
        }        

        public void Delete(int carId)
        {
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);

            data.Cars.Remove(car);
            data.SaveChanges();
        }

        public bool EngineTypeExists(int engineTypeId)
        {
            return data.EngineTypes.Any(c => c.Id == engineTypeId);
        }

        public bool EuroStandardExists(int euroStandardId)
        {
            return data.EuroStandards.Any(c => c.Id == euroStandardId);
        }

        public bool Exists(int id)
        {
            return data.Cars.Any(c => c.Id == id);
        }

        public int GetCarCategoryId(int carId)
        {
            return (data.Cars.FirstOrDefault(c => c.Id == carId)).CategoryId;
        }

        public int GetCarEngineTypeId(int carId)
        {
            return (data.Cars.FirstOrDefault(c => c.Id == carId)).EngineTypeId;
        }

        public int GetCarEuroStandardId(int carId)
        {
            return (data.Cars.FirstOrDefault(c => c.Id == carId)).EuroStandardId;
        }

        public bool HasDealerWithId(int carId, string currentUserId)
        {
            bool result = false;

            var car = data.Cars.FirstOrDefault(c => c.Id == carId);

            if (car?.Dealer != null && car.Dealer.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public bool IsBought(int carId)
        {
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);
            return car.OwnerId != null;
        }

        public bool IsBoughtByUserWithId(int carId, string currentUserId)
        {
            bool result = false;

            Car car = data.Cars.Where(c => c.Id == carId).FirstOrDefault();

            if (car != null && car.OwnerId == currentUserId)
            {
                result = true;
            }
            return result;
        }

        public IEnumerable<CarModel> LastThreeCars()
        {
            return data.Cars
            .OrderByDescending(x => x.Id)
            .Select(h => new CarModel()
            {
                Id = h.Id,
                Make = h.Make,
                Model = h.Model,
                HorsePower = h.HorsePower,
                Price = h.Price,
                YearProduced = h.YearProduced,
                Mileage = h.Mileage,
                Color = h.Color,
                ImageURL = h.ImageURL,
                CategoryId = h.CategoryId,
                EuroStandardId = h.EuroStandardId,
                EngineTypeId = h.EngineTypeId,
                IsBought = h.OwnerId != null
            })
            .Take(3)
            .ToList();
        }

        public void Sell(int carId)
        {
            Car car = data.Cars.FirstOrDefault(c => c.Id == carId);

            string userId = car.Owner.Id;

            car.OwnerId = null;

            data.SaveChanges();
        }
    }
}
