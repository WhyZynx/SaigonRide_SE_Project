using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlateNumberforvehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name" },
                values: new object[] { "Le Loi, District 1, HCMC", 15, 5, 10.772, 106.69799999999999, "Ben Thanh Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name" },
                values: new object[] { "Vo Van Tan, District 3, HCMC", 15, 6, 10.782500000000001, 106.69, "District 3 Hub" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name", "Status" },
                values: new object[,]
                {
                    { 3, "Dien Bien Phu, Binh Thanh, HCMC", 12, 4, 10.803100000000001, 106.715, "Binh Thanh Station", "Active" },
                    { 4, "Vo Nguyen Giap, Thu Duc City", 20, 10, 10.85, 106.77, "Thu Duc Station", "Active" },
                    { 5, "Cong Hoa, Tan Binh, HCMC", 18, 7, 10.801, 106.652, "Tan Binh Station", "Active" },
                    { 6, "Nguyen Van Linh, District 7", 15, 8, 10.7295, 106.721, "District 7 Station", "Active" }
                });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlateNumber",
                value: "BK-001");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlateNumber",
                value: "BK-002");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-003", 500m, 1, "Bike" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[,]
                {
                    { 4, "SC-001", 1500m, 1, "Available", "E-Scooter" },
                    { 5, "SC-002", 1500m, 1, "Available", "E-Scooter" },
                    { 6, "BK-101", 500m, 2, "Available", "Bike" },
                    { 7, "BK-102", 500m, 2, "Available", "Bike" },
                    { 8, "SC-101", 1500m, 2, "Available", "E-Scooter" },
                    { 9, "BK-201", 500m, 3, "Available", "Bike" },
                    { 10, "BK-202", 500m, 3, "Available", "Bike" },
                    { 11, "SC-201", 1500m, 3, "Available", "E-Scooter" },
                    { 12, "BK-301", 500m, 4, "Available", "Bike" },
                    { 13, "BK-302", 500m, 4, "Available", "Bike" },
                    { 14, "SC-301", 1500m, 4, "Available", "E-Scooter" },
                    { 15, "SC-302", 1500m, 4, "Available", "E-Scooter" },
                    { 16, "BK-401", 500m, 5, "Available", "Bike" },
                    { 17, "BK-402", 500m, 5, "Available", "Bike" },
                    { 18, "SC-401", 1500m, 5, "Available", "E-Scooter" },
                    { 19, "BK-501", 500m, 6, "Available", "Bike" },
                    { 20, "BK-502", 500m, 6, "Available", "Bike" },
                    { 21, "BK-503", 500m, 6, "Available", "Bike" },
                    { 22, "SC-501", 1500m, 6, "Available", "E-Scooter" },
                    { 23, "SC-502", 1500m, 6, "Available", "E-Scooter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name" },
                values: new object[] { "Nguyen Hue Street, District 1, HCMC", 10, 2, 10.776899999999999, 106.7009, "District 1 Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name" },
                values: new object[] { "Vo Van Tan Street, District 3, HCMC", 10, 2, 10.782, 106.68899999999999, "District 3 Station" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 1500m, 2, "E-Scooter" });
        }
    }
}
