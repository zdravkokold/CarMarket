using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarket.Services.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80b61d72-bf5c-4abe-a9e2-ab172c551cc3", "AQAAAAEAACcQAAAAEKopbNHB+fapoZLVpdNp81au4MB9mp8aRDBKDxzjz4EM3yP0WkvhJwOSeL9F1hXvyA==", "0baae85b-254a-4a2d-8d62-391f385d3edd" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 5, "Grey", 2, 288, "https://www.topgear.com/sites/default/files/2021/08/A1911776_large.jpg", "Audi", 224, "A5", 21600, 2021 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 3, "White", 878, "https://www.mercedes-benz.co.th/en/passengercars/mercedes-benz-cars/models/gle/suv-v167/amg/line-comparison/_jcr_content/comparisonslider/par/comparisonslide/exteriorImage.MQ6.12.20210819205221.jpeg", "Mercedes", 709, "GLE", 78200, 2022 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price" },
                values: new object[] { 1, "Black", 1, 900, "https://cdn.motor1.com/images/mgl/nGzgl/s1/2021-bugatti-chiron-front.jpg", "Bugatti", 17, "Chiron", 4100000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5970504-56b6-466b-a66d-693623efab5a", "AQAAAAEAACcQAAAAEFaDA5W2Imx2fJlIhyBRvA3LhXDJVG0TccImq9cYk4UCts+g2RC1VD4bzq4OpFk08A==", "21dc8820-0097-4273-b154-eb699be6f47b" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 1, "Black", 1, 900, "https://cdn.motor1.com/images/mgl/nGzgl/s1/2021-bugatti-chiron-front.jpg", "Bugatti", 17, "Chiron", 4100000, 2022 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Color", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price", "YearProduced" },
                values: new object[] { 5, "Grey", 288, "https://www.topgear.com/sites/default/files/2021/08/A1911776_large.jpg", "Audi", 224, "A5", 21600, 2021 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Color", "EngineTypeId", "HorsePower", "ImageURL", "Make", "Mileage", "Model", "Price" },
                values: new object[] { 3, "Red", 2, 878, "https://www.mercedes-benz.co.th/en/passengercars/mercedes-benz-cars/models/gle/suv-v167/amg/line-comparison/_jcr_content/comparisonslider/par/comparisonslide/exteriorImage.MQ6.12.20210819205221.jpeg", "Mercedes", 709, "GLE", 78200 });
        }
    }
}
