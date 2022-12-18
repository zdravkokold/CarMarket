using CarMarket.Services.Data;
using CarMarket.Services.Data.Entities;
using CarMarket.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected CarMarketDbContext data;
        public ApplicationUser Owner { get; private set; }
        public Dealer Dealer { get; private set; }
        public Car BoughtCar { get; private set; }
        private void SeedDatabase()
        {
            Owner = new ApplicationUser()
            {
                Id = "OwnerId",
                Email = "erik@mail.com",
                FirstName = "Erik",
                LastName = "Koldzhiev",
                UserName = "erikkold" 
            };
            data.Users.Add(Owner);

            Dealer = new Dealer()
            {
                PhoneNumber = "0878980000",
                User = new ApplicationUser()
                {
                    Id = "TestUserId",
                    Email = "test@mail.com",
                    FirstName = "Test",
                    LastName = "Tester",
                    UserName = "tester"
                }
            };
            data.Dealers.Add(Dealer);

            BoughtCar = new Car()
            {
                Make = "Audi",
                Model = "A3",
                Mileage = 9000,
                HorsePower = 150,
                Price = 8000,
                YearProduced = 2020,
                Color = "Black",
                Dealer = Dealer,
                Owner = Owner,
                ImageURL = "https://lkswebprdcdnep4.azureedge.net/api/image/stock/c6820736-93cd-4289-b7b6-443f83cc0203?w=1200",
                Category = new Category() { Name = "Hatchback" },
                EngineType = new EngineType() { Name = "Diesel" },
                EuroStandard = new EuroStandard() { Name = "EURO 4" }
            };
            data.Cars.Add(BoughtCar);

            Car notBoughtCar = new Car()
            {
                Make = "Tesla",
                Model = "Model 3",
                Mileage = 500,
                HorsePower = 400,
                Price = 40000,
                YearProduced = 2022,
                Color = "Black",
                Dealer = Dealer,
                Owner = Owner,
                ImageURL = "https://cdn.shopify.com/s/files/1/1724/5219/articles/black-tesla-model-3-aftermarket-carbon-fiber-trunk-wing-spoiler-upgrade-matte-wm-3_1280x.jpg?v=1553278752",
                Category = new Category() { Name = "Sedan" },
                EngineType = new EngineType() { Name = "Electric" },
                EuroStandard = new EuroStandard() { Name = "EURO 6" }
            };
            data.Cars.Add(notBoughtCar);
            data.SaveChanges();
        }

        [OneTimeSetUp]
        public void SetUpBase()
        {
            data = DatabaseMock.Instance;
            SeedDatabase();
        }


        [OneTimeTearDown]
        public void TearDownBase() => data.Dispose();        
    }
}
