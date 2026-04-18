using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class Reseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude" },
                values: new object[] { "Nguyen Hue Street, District 1, HCMC", 10, 2, 10.776899999999999, 106.7009 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude" },
                values: new object[] { "Vo Van Tan Street, District 3, HCMC", 10, 2, 10.782, 106.68899999999999 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude" },
                values: new object[] { "Ben Thanh, District 1, HCMC", 20, 10, 10.772, 106.69799999999999 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude" },
                values: new object[] { "Vo Van Tan, District 3, HCMC", 15, 5, 10.7798, 106.687 });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name", "Status" },
                values: new object[] { 3, "Dien Bien Phu, Binh Thanh, HCMC", 25, 20, 10.801, 106.715, "Binh Thanh Station", "Active" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { 4, 1500m, 2, "Available", "E-Scooter" });
        }
    }
}
