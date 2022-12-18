using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarket.Services.Migrations
{
    public partial class editedCarDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffaebd6a-3538-4b82-8aaf-bfadfbf2af73", "AQAAAAEAACcQAAAAEEUjCmrOnT444rHvh9rvRHfmfqPZxI0CD9VjsdWAIoClJE1hscbAWdD2ik9PNmOdWw==", "39fe7308-5805-446e-8b9a-cd009a17f03b" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "ImageURL", "Price" },
                values: new object[] { "Red", "https://i.ytimg.com/vi/H9v116cyZtA/maxresdefault.jpg", 24300 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 2,
                columns: new[] { "Color", "ImageURL", "Price" },
                values: new object[] { "White", "https://upload.wikimedia.org/wikipedia/commons/9/94/VW_Golf_2.0_TDI_BlueMotion_Technology_Highline_%28VII%29_%E2%80%93_Frontansicht%2C_28._Juli_2013%2C_M%C3%BCnster.jpg", 18400 });
        }
    }
}
