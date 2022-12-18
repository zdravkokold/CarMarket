using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarket.Services.Migrations
{
    public partial class edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef52907-78ed-4267-9d0d-3f8f410e9954", "AQAAAAEAACcQAAAAELftIN/lUAkp140CBh6vpecWnUkZXGSIT/49jwyj91/XyKhxC83Ec2TLP7Pa2MrDLA==", "cc6ce07f-9857-4390-bf6e-e1b1dc8f2281" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                columns: new[] { "Balance", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 50000, "80b61d72-bf5c-4abe-a9e2-ab172c551cc3", "AQAAAAEAACcQAAAAEKopbNHB+fapoZLVpdNp81au4MB9mp8aRDBKDxzjz4EM3yP0WkvhJwOSeL9F1hXvyA==", "0baae85b-254a-4a2d-8d62-391f385d3edd" });
        }
    }
}
