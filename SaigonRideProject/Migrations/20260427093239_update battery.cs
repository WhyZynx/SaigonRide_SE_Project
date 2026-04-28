using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class updatebattery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "BatteryLevel",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 20, 0 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 0 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrentInventory",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 25, 0 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 0 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 0 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 15, 0 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$EMDNlMRrKrVFWpooIFhz7e4kh0nVVhXEUQT11DVS4DJf0RtOi5QiO");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "BatteryLevel",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 90, "Available" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 100, "InUse" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "VehicleType" },
                values: new object[] { 85, "BK-004", 500m, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BatteryLevel", "PlateNumber" },
                values: new object[] { 95, "SC-001" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 72, "SC-002", 1500m, 1, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { 15, "SC-003", 1500m, 1, "Maintenance", "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BatteryLevel", "PlateNumber" },
                values: new object[] { 100, "BK-101" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "Status", "VehicleType" },
                values: new object[] { 88, "BK-102", 500m, "Available", "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "Status", "VehicleType" },
                values: new object[] { 100, "BK-103", 500m, "InUse", "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 92, "BK-104", 2 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 80, "SC-101", 1500m, 2, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { 10, "SC-102", 1500m, 2, "Maintenance", "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 77, "SC-103", 2 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "Status", "VehicleType" },
                values: new object[] { 100, "BK-201", 500m, "Available", "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 95, "BK-202", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 100, "BK-203", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 89, "BK-204", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 60, "SC-201", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId", "Status" },
                values: new object[] { 18, "SC-202", 3, "Maintenance" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { 91, "SC-203", 1500m, 3, "Available", "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 100, "BK-301", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BatteryLevel", "PlateNumber", "StationId" },
                values: new object[] { 85, "BK-302", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 100, "BK-303", 500m, 4, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 93, "BK-304", 500m, 4, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 88, "SC-301", 1500m, 4, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { 12, "SC-302", 1500m, 4, "Maintenance", "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 74, "SC-303", 1500m, 4, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { 100, "BK-401", 500m, 5, "Available", "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { 90, "BK-402", 500m, 5, "Bike" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[,]
                {
                    { 31, 100, "BK-403", 500m, 5, "InUse", "Bike" },
                    { 32, 88, "BK-404", 500m, 5, "Available", "Bike" },
                    { 33, 70, "SC-401", 1500m, 5, "Available", "E-Scooter" },
                    { 34, 9, "SC-402", 1500m, 5, "Maintenance", "E-Scooter" },
                    { 35, 82, "SC-403", 1500m, 5, "Available", "E-Scooter" },
                    { 36, 100, "BK-501", 500m, 6, "Available", "Bike" },
                    { 37, 93, "BK-502", 500m, 6, "Available", "Bike" },
                    { 38, 100, "BK-503", 500m, 6, "InUse", "Bike" },
                    { 39, 87, "BK-504", 500m, 6, "Available", "Bike" },
                    { 40, 79, "SC-501", 1500m, 6, "Available", "E-Scooter" },
                    { 41, 14, "SC-502", 1500m, 6, "Maintenance", "E-Scooter" },
                    { 42, 90, "SC-503", 1500m, 6, "Available", "E-Scooter" },
                    { 43, 100, "BK-601", 500m, 7, "Available", "Bike" },
                    { 44, 95, "BK-602", 500m, 7, "Available", "Bike" },
                    { 45, 100, "BK-603", 500m, 7, "InUse", "Bike" },
                    { 46, 85, "SC-601", 1500m, 7, "Available", "E-Scooter" },
                    { 47, 17, "SC-602", 1500m, 7, "Maintenance", "E-Scooter" },
                    { 48, 76, "SC-603", 1500m, 7, "Available", "E-Scooter" },
                    { 49, 100, "BK-701", 500m, 8, "Available", "Bike" },
                    { 50, 92, "SC-701", 1500m, 8, "Available", "E-Scooter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DropColumn(
                name: "BatteryLevel",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 25, 18 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 20, 14 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrentInventory",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 30, 20 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 22, 15 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 20, 13 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 11 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 22, 16 });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Address", "Capacity", "CurrentInventory", "Latitude", "Longitude", "Name", "Status" },
                values: new object[,]
                {
                    { 9, "Tran Hung Dao", 18, 10, 10.755000000000001, 106.67, "District 5 Station", "Active" },
                    { 10, "Su Van Hanh", 18, 12, 10.7705, 106.66500000000001, "District 10 Station", "Active" },
                    { 11, "Lu Gia", 20, 13, 10.789999999999999, 106.63, "Tan Phu Station", "Active" },
                    { 12, "Kinh Duong Vuong", 25, 17, 10.76, 106.59999999999999, "Binh Tan Station", "Active" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$.5FEYzTiy5zp99Wna5rx0OPC6X11VDiooG7aXzcZa5VIn72HxvpLO");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PlateNumber", "PricePerMinute", "VehicleType" },
                values: new object[] { "SC-001", 1500m, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "PlateNumber",
                value: "SC-002");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-101", 500m, 2, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { "BK-102", 500m, 2, "InUse", "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "PlateNumber",
                value: "BK-103");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PlateNumber", "PricePerMinute", "Status", "VehicleType" },
                values: new object[] { "SC-101", 1500m, "Maintenance", "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PlateNumber", "PricePerMinute", "Status", "VehicleType" },
                values: new object[] { "SC-102", 1500m, "Available", "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-201", 3 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-202", 500m, 3, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { "BK-203", 500m, 3, "InUse", "Bike" });

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
                columns: new[] { "PlateNumber", "PricePerMinute", "Status", "VehicleType" },
                values: new object[] { "SC-202", 1500m, "Maintenance", "E-Scooter" });

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
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-303", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "SC-301", 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PlateNumber", "StationId", "Status" },
                values: new object[] { "SC-302", 4, "Available" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { "BK-401", 500m, 5, "Maintenance", "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-402", 5 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PlateNumber", "StationId" },
                values: new object[] { "BK-403", 5 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-401", 1500m, 5, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-402", 1500m, 5, "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-501", 500m, 6, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { "BK-502", 500m, 6, "Available", "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "BK-503", 500m, 6, "Bike" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[] { "SC-501", 1500m, 6, "InUse", "E-Scooter" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "PlateNumber", "PricePerMinute", "StationId", "VehicleType" },
                values: new object[] { "SC-502", 1500m, 6, "E-Scooter" });
        }
    }
}
