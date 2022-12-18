using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarket.Services.Migrations
{
    public partial class seedCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05eab603-4cb3-4bb2-bb9c-3c50e4e64c24", "AQAAAAEAACcQAAAAEDPNuIaQSdvJhbRw++wIZ1jKFWywbrj535cp3/bMBgCPja8Q9jr92CmsxXIJB95+xA==", "c851ec9c-f9a9-4a4b-b32f-9221f33b5848" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "EuroStandardId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 2, "White", 2, 5, 145, "https://upload.wikimedia.org/wikipedia/commons/9/94/VW_Golf_2.0_TDI_BlueMotion_Technology_Highline_%28VII%29_%E2%80%93_Frontansicht%2C_28._Juli_2013%2C_M%C3%BCnster.jpg", "VW", 11567, "Golf 7", 18400, 2018 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 4, "White", 2, 5, 255, "https://www.autoclub.bg/wp-content/uploads/2022/07/2023-toyota-supra-with-manual-gearbox-europe.jpg", "Toyota", 41234, "Supra", 44600, 2016 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 2, "Gold", 1, 5, 189, "https://paultan.org/image/2022/03/2022-Mazda-3-3-e1648438220538.png", "Mazda", 22478, "3", 25700, 2019 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 4, "Grey", 2, 5, 346, "https://www.topgear.com/sites/default/files/2022/09/2024%20Mustang%2006.jpg", "Ford", 8743, "Mustang", 31000, 2020 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "DealerId", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "OwnerId", "Price", "YearProduced" },
                values: new object[,]
                {
                    { 6, 3, "Blue", 2, 4, 6, 256, "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1615375317/autoexpress/2021/03/Hyundai%20Tucson%202021%20front%20driving.jpg", "Huyndai", 11, "Tucson", "3c5e88ea-215a-4da6-9273-03a27d2e6c79", 40000, 2022 },
                    { 7, 5, "Red", 2, 1, 6, 178, "https://cdn.motor1.com/images/mgl/kXQZM/s1/mercedes-benz-e-klasse-cabriolet-2020.jpg", "Mercedes", 1391, "E Class", "3c5e88ea-215a-4da6-9273-03a27d2e6c79", 21200, 2021 },
                    { 8, 1, "Red", 2, 1, 6, 355, "https://www.motortrend.com/uploads/2022/10/2023-BMW-M5-exterior-8.jpg", "BMW", 49, "M5", "3c5e88ea-215a-4da6-9273-03a27d2e6c79", 34000, 2022 },
                    { 9, 3, "White", 2, 2, 6, 878, "https://www.mercedes-benz.co.th/en/passengercars/mercedes-benz-cars/models/gle/suv-v167/amg/line-comparison/_jcr_content/comparisonslider/par/comparisonslide/exteriorImage.MQ6.12.20210819205221.jpeg", "Mercedes", 709, "GLE", "3c5e88ea-215a-4da6-9273-03a27d2e6c79", 78200, 2022 },
                    { 10, 1, "Black", 2, 1, 6, 900, "https://cdn.motor1.com/images/mgl/nGzgl/s1/2021-bugatti-chiron-front.jpg", "Bugatti", 17, "Chiron", "3c5e88ea-215a-4da6-9273-03a27d2e6c79", 4100000, 2022 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef52907-78ed-4267-9d0d-3f8f410e9954", "AQAAAAEAACcQAAAAELftIN/lUAkp140CBh6vpecWnUkZXGSIT/49jwyj91/XyKhxC83Ec2TLP7Pa2MrDLA==", "cc6ce07f-9857-4390-bf6e-e1b1dc8f2281" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "EuroStandardId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 3, "Blue", 4, 6, 256, "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1615375317/autoexpress/2021/03/Hyundai%20Tucson%202021%20front%20driving.jpg", "Huyndai", 11, "Tucson", 40000, 2022 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 1, "Red", 1, 6, 355, "https://www.motortrend.com/uploads/2022/10/2023-BMW-M5-exterior-8.jpg", "BMW", 49, "M5", 34000, 2022 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 3, "White", 2, 6, 878, "https://www.mercedes-benz.co.th/en/passengercars/mercedes-benz-cars/models/gle/suv-v167/amg/line-comparison/_jcr_content/comparisonslider/par/comparisonslide/exteriorImage.MQ6.12.20210819205221.jpeg", "Mercedes", 709, "GLE", 78200, 2022 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "EuroStandardId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 1, "Black", 1, 6, 900, "https://cdn.motor1.com/images/mgl/nGzgl/s1/2021-bugatti-chiron-front.jpg", "Bugatti", 17, "Chiron", 4100000, 2022 });
        }
    }
}
