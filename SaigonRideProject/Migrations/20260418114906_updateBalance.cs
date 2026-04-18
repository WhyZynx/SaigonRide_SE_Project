using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class updateBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "CurrentInventory" },
                values: new object[] { "District 1", 20, 10 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CurrentInventory" },
                values: new object[] { "Vo Van Tan", 8 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Capacity", "CurrentInventory" },
                values: new object[] { "Dien Bien Phu", 15, 7 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CurrentInventory" },
                values: new object[] { "Vo Nguyen Giap", 12 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "CurrentInventory" },
                values: new object[] { "Cong Hoa", 9 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Address",
                value: "Nguyen Van Linh");

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name", "Status" },
                values: new object[,]
                {
                    { 7, "Phan Xich Long", 15, 7, 10.798999999999999, 106.68000000000001, "Phu Nhuan Station", "Active" },
                    { 8, "Quang Trung", 18, 10, 10.837999999999999, 106.66800000000001, "Go Vap Station", "Active" },
                    { 9, "Tran Hung Dao", 14, 6, 10.755000000000001, 106.67, "District 5 Station", "Active" },
                    { 10, "Su Van Hanh", 14, 7, 10.7705, 106.66500000000001, "District 10 Station", "Active" },
                    { 11, "Lu Gia", 16, 8, 10.789999999999999, 106.63, "Tan Phu Station", "Active" },
                    { 12, "Kinh Duong Vuong", 20, 11, 10.76, 106.59999999999999, "Binh Tan Station", "Active" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Balance", "IsLocked" },
                values: new object[] { 0m, false });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PlateNumber", "PricePerMinute", "VehicleType" },
                values: new object[] { "BK-103", 500m, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-101", 1500m, 2, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-102", 1500m, 2, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PlateNumber", "PricePerMinute", "VehicleType" },
                values: new object[] { "BK-201", 500m, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-202", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-203", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "SC-201", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "SC-202", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-301", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-302", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-303", 500m, 4, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-301", 1500m, 4, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-302", 1500m, 4, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-401", 5 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-402", 500m, 5, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-403", 500m, 5, "Bike" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[,]
                {
                    { 24, "SC-401", 1500m, 5, "Available", "E-Scooter" },
                    { 25, "SC-402", 1500m, 5, "Available", "E-Scooter" },
                    { 26, "BK-501", 500m, 6, "Available", "Bike" },
                    { 27, "BK-502", 500m, 6, "Available", "Bike" },
                    { 28, "BK-503", 500m, 6, "Available", "Bike" },
                    { 29, "SC-501", 1500m, 6, "Available", "E-Scooter" },
                    { 30, "SC-502", 1500m, 6, "Available", "E-Scooter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId",
                unique: true,
                filter: "[Status] = 'InProgress'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals");

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "CurrentInventory" },
                values: new object[] { "Le Loi, District 1, HCMC", 15, 5 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CurrentInventory" },
                values: new object[] { "Vo Van Tan, District 3, HCMC", 6 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Capacity", "CurrentInventory" },
                values: new object[] { "Dien Bien Phu, Binh Thanh, HCMC", 12, 4 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CurrentInventory" },
                values: new object[] { "Vo Nguyen Giap, Thu Duc City", 10 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "CurrentInventory" },
                values: new object[] { "Cong Hoa, Tan Binh, HCMC", 7 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Address",
                value: "Nguyen Van Linh, District 7");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PlateNumber", "PricePerMinute", "VehicleType" },
                values: new object[] { "SC-101", 1500m, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-201", 500m, 3, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-202", 500m, 3, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PlateNumber", "PricePerMinute", "VehicleType" },
                values: new object[] { "SC-201", 1500m, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-301", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-302", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "SC-301", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "SC-302", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-401", 5 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-402", 5 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-401", 1500m, 5, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-501", 500m, 6, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-502", 500m, 6, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-503", 6 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-501", 1500m, 6, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-502", 1500m, 6, "E-Scooter" });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");
        }
    }
}
