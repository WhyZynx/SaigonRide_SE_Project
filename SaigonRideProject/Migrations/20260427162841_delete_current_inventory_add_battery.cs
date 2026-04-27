using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class delete_current_inventory_add_battery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentInventory",
                table: "Stations");

            migrationBuilder.AddColumn<int>(
                name: "BatteryLevel",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$YDNxh.hYt5mH/rTpCv7Y7OvAhzBHKJ2D1FN8xh8HeiR0AwyThrFgy");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "BatteryLevel",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 85, "Available" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 70, "InUse" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "BatteryLevel",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 40, "Maintenance" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "BatteryLevel",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 92, "Available" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 60, "InUse" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 75, "Available" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 30, "Maintenance" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11,
                column: "BatteryLevel",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                column: "BatteryLevel",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 80, "Available" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 65, "InUse" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BatteryLevel", "Status" },
                values: new object[] { 95, "Available" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 16,
                column: "BatteryLevel",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                column: "BatteryLevel",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 18,
                column: "BatteryLevel",
                value: 92);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                column: "BatteryLevel",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20,
                column: "BatteryLevel",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21,
                column: "BatteryLevel",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 22,
                column: "BatteryLevel",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 23,
                column: "BatteryLevel",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 24,
                column: "BatteryLevel",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 25,
                column: "BatteryLevel",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 26,
                column: "BatteryLevel",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 27,
                column: "BatteryLevel",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 28,
                column: "BatteryLevel",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 29,
                column: "BatteryLevel",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 30,
                column: "BatteryLevel",
                value: 95);

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[,]
                {
                    { 31, 88, "BK-601", 500m, 7, "Available", "Bike" },
                    { 32, 90, "BK-602", 500m, 7, "Available", "Bike" },
                    { 33, 85, "BK-603", 500m, 7, "Available", "Bike" },
                    { 34, 25, "SC-601", 1500m, 7, "Maintenance", "E-Scooter" },
                    { 35, 95, "SC-602", 1500m, 7, "Available", "E-Scooter" },
                    { 36, 90, "BK-701", 500m, 8, "Available", "Bike" },
                    { 37, 85, "BK-702", 500m, 8, "Available", "Bike" },
                    { 38, 80, "BK-703", 500m, 8, "Available", "Bike" },
                    { 39, 70, "SC-701", 1500m, 8, "InUse", "E-Scooter" },
                    { 40, 95, "SC-702", 1500m, 8, "Available", "E-Scooter" },
                    { 41, 88, "BK-801", 500m, 9, "Available", "Bike" },
                    { 42, 90, "BK-802", 500m, 9, "Available", "Bike" },
                    { 43, 85, "BK-803", 500m, 9, "Available", "Bike" },
                    { 44, 95, "SC-801", 1500m, 9, "Available", "E-Scooter" },
                    { 45, 90, "SC-802", 1500m, 9, "Available", "E-Scooter" },
                    { 46, 80, "BK-901", 500m, 10, "Available", "Bike" },
                    { 47, 85, "BK-902", 500m, 10, "Available", "Bike" },
                    { 48, 90, "BK-903", 500m, 10, "Available", "Bike" },
                    { 49, 95, "SC-901", 1500m, 10, "Available", "E-Scooter" },
                    { 50, 60, "SC-902", 1500m, 10, "InUse", "E-Scooter" }
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

            migrationBuilder.AddColumn<int>(
                name: "CurrentInventory",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrentInventory",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrentInventory",
                value: 14);

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
                column: "CurrentInventory",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CurrentInventory",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CurrentInventory",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CurrentInventory",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CurrentInventory",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CurrentInventory",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CurrentInventory",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 11,
                column: "CurrentInventory",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 12,
                column: "CurrentInventory",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$1Ysqg/vfp3ozZmLRjrkq4.MD2mK/h/Wz8K2VgqRq4Nn9atjE8MRGy");

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
                keyValue: 5,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                column: "Status",
                value: "Maintenance");
        }
    }
}
