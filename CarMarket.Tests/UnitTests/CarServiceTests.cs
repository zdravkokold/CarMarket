using CarMarket.Services.Cars;
using CarMarket.Services.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Tests.UnitTests
{
    public class CarServiceTests : UnitTestsBase
    {
        private ICarService carService;

        [OneTimeSetUp]
        public void SetUp() => carService = new CarService(data);

        [Test]
        public void AllCategories_ShouldReturnCorrectCategories()
        {
            var result = carService.AllCategories();

            var dbCategories = data.Categories;
            Assert.AreEqual(result.Count(), dbCategories.Count());

            var categoryNames = dbCategories.Select(c => c.Name);
            Assert.That(categoryNames.Contains(result.FirstOrDefault().Name));
        }

        [Test]
        public void AllEngineTypes_ShouldReturnCorrectEngineTypes()
        {
            var result = carService.AllEngineTypes();

            var dbEngines = data.EngineTypes;
            Assert.AreEqual(result.Count(), dbEngines.Count());

            var engineTypeNames = dbEngines.Select(c => c.Name);
            Assert.That(engineTypeNames.Contains(result.FirstOrDefault().Name));
        }

        [Test]
        public void AllEuroStandards_ShouldReturnCorrectEuroStandards()
        {
            var result = carService.AllEuroStandards();

            var dbEuros = data.EuroStandards;
            Assert.AreEqual(result.Count(), dbEuros.Count());

            var euroNames = dbEuros.Select(c => c.Name);
            Assert.That(euroNames.Contains(result.FirstOrDefault().Name));
        }

        [Test]
        public void AllCategoriesNames_ShouldReturnCorrectResult()
        {
            var result = carService.AllCategoriesNames();

            var dbCategories = data.Categories;
            Assert.AreEqual(result.Count(), dbCategories.Count());

            var categoryNames = dbCategories.Select(c => c.Name);
            Assert.That(categoryNames.Contains(result.FirstOrDefault()));
        }

        [Test]
        public void AllEngineTypesNames_ShouldReturnCorrectResult()
        {
            var result = carService.AllEngineTypesNames();

            var dbEngines = data.EngineTypes;
            Assert.AreEqual(result.Count(), dbEngines.Count());

            var names = dbEngines.Select(c => c.Name);
            Assert.That(names.Contains(result.FirstOrDefault()));
        }

        [Test]
        public void AllEuroStandardsNames_ShouldReturnCorrectResult()
        {
            var result = carService.AllEuroStandardsNames();

            var dbEuros = data.EuroStandards;
            Assert.AreEqual(result.Count(), dbEuros.Count());

            var names = dbEuros.Select(c => c.Name);
            Assert.That(names.Contains(result.FirstOrDefault()));
        }

        [Test]
        public void CategoryExists_ShouldReturnTrue_WithValidId()
        {
            var id = data.Categories.FirstOrDefault().Id;

            var result = carService.CategoryExists(id);
            Assert.IsTrue(result);
        }

        [Test]
        public void EngineTypeExists_ShouldReturnTrue_WithValidId()
        {
            var id = data.EngineTypes.FirstOrDefault().Id;

            var result = carService.EngineTypeExists(id);
            Assert.IsTrue(result);
        }

        [Test]
        public void EuroStandardExists_ShouldReturnTrue_WithValidId()
        {
            var id = data.EuroStandards.FirstOrDefault().Id;

            var result = carService.EuroStandardExists(id);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestGetCategoryId()
        {
            int carId = BoughtCar.Id;
            var result = carService.GetCarCategoryId(carId);
            Assert.IsNotNull(result);

            int id = BoughtCar.Category.Id;
            Assert.AreEqual(id, result);
        }

        [Test]
        public void TestGetEngineTypeId()
        {
            int carId = BoughtCar.Id;
            var result = carService.GetCarEngineTypeId(carId);
            Assert.IsNotNull(result);

            int id = BoughtCar.EngineType.Id;
            Assert.AreEqual(id, result);
        }

        [Test]
        public void TestGetEuroStandardId()
        {
            int carId = BoughtCar.Id;
            var result = carService.GetCarEuroStandardId(carId);
            Assert.IsNotNull(result);

            int id = BoughtCar.EuroStandard.Id;
            Assert.AreEqual(id, result);
        }

        [Test]

        public void HasAgentWithId_ShouldReturnTrue_WithValidId()
        {
            var id = this.BoughtCar.Id;
            var userId = this.BoughtCar.Dealer.User.Id;
            var result = this.carService.HasDealerWithId(id, userId);

            Assert.IsTrue(result);
        }

        [Test]
        public void Exists_ShouldReturnTrue_WithValidId()
        {
            var id = this.BoughtCar.Id;
            var result = this.carService.Exists(id);

            Assert.IsTrue(result);
        }

        [Test]
        public void All_ShouldReturnCorrectCars()
        {
            var searchTerm = "udi";

            var result = this.carService.All(null, null, null, searchTerm);

            var carInDb = this.data.Cars
            .Where(x => x.Make.ToLower().Contains(searchTerm.ToLower()) ||
                        x.Model.ToLower().Contains(searchTerm.ToLower()));

            Assert.AreEqual(result.TotalCarsCount, carInDb.Count());

            var resultcar = result.Cars.FirstOrDefault();
            Assert.IsNotNull(result);

            var carrInDb = carInDb.FirstOrDefault();

            Assert.Multiple(() =>
            {
                Assert.That(resultcar.Make, Is.EqualTo(carrInDb.Make));
                Assert.That(resultcar.Model, Is.EqualTo(carrInDb.Model));
            });

        }

        [Test]
        public void Test_IsBought_ShouldBeTrue()
        {
            var result = carService.IsBought(BoughtCar.Id);
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_IsBoughtByUserWithId_ShouldBeTrue()
        {
            var id = BoughtCar.Id;
            bool bought = carService.IsBoughtByUserWithId(id, "OwnerId");
            Assert.IsTrue(bought);
        }

        [Test]
        public void Test_LastThreeCars()
        {
            var result = carService.LastThreeCars();

            var carInDB = this.data.Cars
            .OrderByDescending(h => h.Id)
            .Take(3);

            Assert.That(result.Count(), Is.EqualTo(carInDB.Count()));

            var firstCarInDb = carInDB
            .FirstOrDefault();

            var firstResultCar = result.FirstOrDefault();
            Assert.That(firstResultCar.Id, Is.EqualTo(firstCarInDb.Id));
            Assert.That(firstResultCar.Make, Is.EqualTo(firstCarInDb.Make));
        }

        [Test]
        public void Test_AllCars()
        {
            var result = carService.AllCars();

            var carInDB = this.data.Cars
            .OrderByDescending(h => h.Id);

            Assert.That(result.Count(), Is.EqualTo(carInDB.Count()));

            var firstCarInDb = carInDB
            .FirstOrDefault();

            var firstResultCar = result.FirstOrDefault();
            Assert.That(firstResultCar.Id, Is.EqualTo(firstCarInDb.Id));
            Assert.That(firstResultCar.Make, Is.EqualTo(firstCarInDb.Make));
        }

        [Test]
        public void Buy_ShouldWork()
        {
            Car car = new Car()
            {
                Make = "Honda",
                Model = "Civic",
                Mileage = 90000,
                HorsePower = 120,
                Price = 3000,
                YearProduced = 2000,
                Color = "Black",
                Dealer = Dealer,
                ImageURL = "https://romi",
                Category = new Category() { Name = "Hatchback" },
                EngineType = new EngineType() { Name = "Petrol" },
                EuroStandard = new EuroStandard() { Name = "EURO 4" }
            };

            data.Cars.Add(car);
            data.SaveChanges();

            carService.Buy(car.Id, Owner.Id);            
            var newCarInDb = data.Cars.Find(car.Id);

            Assert.IsNotNull(newCarInDb);
            Assert.AreEqual(car.OwnerId, Owner.Id);
        }

        [Test]
        public void Sell_ShouldWork()
        {
            Car car = new Car()
            {
                Make = "Nissan",
                Model = "Altima",
                Mileage = 90000,
                HorsePower = 120,
                Price = 3000,
                YearProduced = 2000,
                Color = "Black",
                Dealer = Dealer,
                ImageURL = "https://romi",
                Category = new Category() { Name = "Hatchback" },
                EngineType = new EngineType() { Name = "Petrol" },
                EuroStandard = new EuroStandard() { Name = "EURO 4" }
            };

            data.Cars.Add(car);
            data.SaveChanges();

            carService.Buy(car.Id, Owner.Id);
            Assert.IsNotNull(car.OwnerId);

            carService.Sell(car.Id);
            Assert.IsNull(car.OwnerId);
        }

        [Test]
        public void Delete_ShouldWork()
        {
            Car car = new Car()
            {
                Make = "Nissan",
                Model = "Altima",
                Mileage = 88000,
                HorsePower = 120,
                Price = 3000,
                YearProduced = 2000,
                Color = "Black",
                Dealer = Dealer,
                ImageURL = "https://romi",
                Category = new Category() { Name = "Hatchback" },
                EngineType = new EngineType() { Name = "Petrol" },
                EuroStandard = new EuroStandard() { Name = "EURO 4" }
            };

            data.Cars.Add(car);
            data.SaveChanges();
            Assert.IsNotNull(data.Cars.Find(car.Id));

            carService.Delete(car.Id);
            Assert.IsNull(data.Cars.Find(car.Id));
        }

        [Test]
        public void CarDetailsById_ShouldWork_WithValidId()
        {
            var id = BoughtCar.Id;
            var result = carService.CarDetailsById(id);
            Assert.IsNotNull(result);

            var carInDb = data.Cars.Find(id);
            Assert.AreEqual(carInDb.Id, result.Id);
            Assert.AreEqual(carInDb.Make, result.Make);
        }

        [Test]
        public void AllCarsByDealerId_ShouldWork_WithValidId()
        {
            var id = Dealer.Id;
            var result = carService.AllCarsByDealerId(id);
            Assert.IsNotNull(result);

            var carInDb = data.Cars.Where(x => x.DealerId == id);

            Assert.AreEqual(carInDb.Count(), result.Count());
        }

        [Test]
        public void AllCarsByUserId_ShouldWork_WithValidId()
        {
            var id = Owner.Id;
            var result = carService.AllCarsByUserId(id);
            Assert.IsNotNull(result);

            var carInDb = data.Cars.Where(x => x.OwnerId == id);

            Assert.AreEqual(carInDb.Count(), result.Count());
        }
    }
}
