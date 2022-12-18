using CarMarket.Services.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
            new Car()
            {
                Id = 1,
                Make = "Audi",
                Model = "A5",
                YearProduced = 2021,
                Mileage = 224,
                HorsePower = 288,
                Color = "Grey",
                ImageURL = "https://www.topgear.com/sites/default/files/2021/08/A1911776_large.jpg",
                Price = 21600,
                CategoryId = 5,
                EngineTypeId = 2,
                EuroStandardId = 5,
                DealerId = 2,
                OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
            },
            new Car()
            {
                Id = 2,
                Make = "VW",
                Model = "Golf 7",
                YearProduced = 2018,
                Mileage = 11567,
                HorsePower = 145,
                Color = "Red",
                ImageURL = "https://i.ytimg.com/vi/H9v116cyZtA/maxresdefault.jpg",
                Price = 24300,
                CategoryId = 2,
                EngineTypeId = 2,
                EuroStandardId = 5,
                DealerId = 2,
                OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
            },
             new Car()
             {
                 Id = 3,
                 Make = "Toyota",
                 Model = "Supra",
                 YearProduced = 2016,
                 Mileage = 41234,
                 HorsePower = 255,
                 Color = "White",
                 ImageURL = "https://www.autoclub.bg/wp-content/uploads/2022/07/2023-toyota-supra-with-manual-gearbox-europe.jpg",
                 Price = 44600,
                 CategoryId = 4,
                 EngineTypeId = 2,
                 EuroStandardId = 5,
                 DealerId = 2,
                 OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
             },
             new Car()
             {
                 Id = 4,
                 Make = "Mazda",
                 Model = "3",
                 YearProduced = 2019,
                 Mileage = 22478,
                 HorsePower = 189,
                 Color = "Gold",
                 ImageURL = "https://paultan.org/image/2022/03/2022-Mazda-3-3-e1648438220538.png",
                 Price = 25700,
                 CategoryId = 2,
                 EngineTypeId = 1,
                 EuroStandardId = 5,
                 DealerId = 2,
                 OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
             },
             new Car()
             {
                 Id = 5,
                 Make = "Ford",
                 Model = "Mustang",
                 YearProduced = 2020,
                 Mileage = 8743,
                 HorsePower = 346,
                 Color = "Grey",
                 ImageURL = "https://www.topgear.com/sites/default/files/2022/09/2024%20Mustang%2006.jpg",
                 Price = 31000,
                 CategoryId = 4,
                 EngineTypeId = 2,
                 EuroStandardId = 5,
                 DealerId = 2,
                 OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
             },
            new Car()
            {
                Id = 6,
                Make = "Huyndai",
                Model = "Tucson",
                YearProduced = 2022,
                Mileage = 11,
                HorsePower = 256,
                Color = "Blue",
                ImageURL = "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1615375317/autoexpress/2021/03/Hyundai%20Tucson%202021%20front%20driving.jpg",
                Price = 40000,
                CategoryId = 3,
                EngineTypeId = 4,
                EuroStandardId = 6,
                DealerId = 2,
                OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
            },
            new Car()
            {
                Id = 7,
                Make = "Mercedes",
                Model = "E Class",
                YearProduced = 2021,
                Mileage = 1391,
                HorsePower = 178,
                Color = "Red",
                ImageURL = "https://cdn.motor1.com/images/mgl/kXQZM/s1/mercedes-benz-e-klasse-cabriolet-2020.jpg",
                Price = 21200,
                CategoryId = 5,
                EngineTypeId = 1,
                EuroStandardId = 6,
                DealerId = 2,
                OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
            },
            new Car()
            {
                Id = 8,
                Make = "BMW",
                Model = "M5",
                YearProduced = 2022,
                Mileage = 49,
                HorsePower = 355,
                Color = "Red",
                ImageURL = "https://www.motortrend.com/uploads/2022/10/2023-BMW-M5-exterior-8.jpg",
                Price = 34000,
                CategoryId = 1,
                EngineTypeId = 1,
                EuroStandardId = 6,
                DealerId = 2,
                OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
            },
            
            new Car()
            {
                Id = 9,
                Make = "Mercedes",
                Model = "GLE",
                YearProduced = 2022,
                Mileage = 709,
                HorsePower = 878,
                Color = "White",
                ImageURL = "https://www.mercedes-benz.co.th/en/passengercars/mercedes-benz-cars/models/gle/suv-v167/amg/line-comparison/_jcr_content/comparisonslider/par/comparisonslide/exteriorImage.MQ6.12.20210819205221.jpeg",
                Price = 78200,
                CategoryId = 3,
                EngineTypeId = 2,
                EuroStandardId = 6,
                DealerId = 2,
                OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
            },
            new Car()
            {
                Id = 10,
                Make = "Bugatti",
                Model = "Chiron",
                YearProduced = 2022,
                Mileage = 17,
                HorsePower = 900,
                Color = "Black",
                ImageURL = "https://cdn.motor1.com/images/mgl/nGzgl/s1/2021-bugatti-chiron-front.jpg",
                Price = 4100000,
                CategoryId = 1,
                EngineTypeId = 1,
                EuroStandardId = 6,
                DealerId = 2,
                OwnerId = "3c5e88ea-215a-4da6-9273-03a27d2e6c79"
            }
            );
        }
        
    }
}
