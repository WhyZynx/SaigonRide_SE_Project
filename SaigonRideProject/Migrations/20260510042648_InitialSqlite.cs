using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtpVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    OtpCode = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpVerifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdentityNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IdentityImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IdentityType = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "None"),
                    PassportStatus = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Pending"),
                    Balance = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    IsLocked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleType = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    PricePerMinute = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    StationId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BatteryLevel = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 100)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Method = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    PickupStationId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReturnStationId = table.Column<int>(type: "INTEGER", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BaseAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: false),
                    FinalAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Stations_PickupStationId",
                        column: x => x.PickupStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Stations_ReturnStationId",
                        column: x => x.ReturnStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Method = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Pending"),
                    RentalId = table.Column<int>(type: "INTEGER", nullable: false),
                    QrCodeUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Address", "Capacity", "Latitude", "Longitude", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "District 1", 25, 10.772, 106.69799999999999, "Ben Thanh Station", "Active" },
                    { 2, "Vo Van Tan", 26, 10.782500000000001, 106.69, "District 3 Hub", "Active" },
                    { 3, "Dien Bien Phu", 5, 10.803100000000001, 106.715, "Binh Thanh Station", "Active" },
                    { 4, "Vo Nguyen Giap", 24, 10.85, 106.77, "Thu Duc Station", "Active" },
                    { 5, "Cong Hoa", 22, 10.801, 106.652, "Tan Binh Station", "Active" },
                    { 6, "Nguyen Van Linh", 20, 10.7295, 106.721, "District 7 Station", "Active" },
                    { 7, "Phan Xich Long", 18, 10.798999999999999, 106.68000000000001, "Phu Nhuan Station", "Active" },
                    { 8, "Quang Trung", 22, 10.837999999999999, 106.66800000000001, "Go Vap Station", "Active" },
                    { 9, "Tran Hung Dao", 18, 10.755000000000001, 106.67, "District 5 Station", "Active" },
                    { 10, "Su Van Hanh", 18, 10.7705, 106.66500000000001, "District 10 Station", "Active" },
                    { 11, "Lu Gia", 20, 10.789999999999999, 106.63, "Tan Phu Station", "Active" },
                    { 12, "Kinh Duong Vuong", 25, 10.76, 106.59999999999999, "Binh Tan Station", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "Email", "FullName", "IdentityImageUrl", "IdentityNumber", "IdentityType", "IsLocked", "IsVerified", "PassportStatus", "PasswordHash", "Role", "UserType" },
                values: new object[,]
                {
                    { 1, 0m, "admin@saigonride.com", "System Admin", "", "000000000", "CCCD", false, true, "Approved", "$2a$11$ezOfuiqbBU74noyChjdUeuy5vx44Dmqm62ERnQDl5dqLhPTKp/.K6", "Admin", "Local" },
                    { 2, 500000m, "nguyenvana@gmail.com", "Nguyen Van A", null, null, "None", false, true, "Pending", "$2a$11$tyLSpWmGvuFr3PWTtInbNeDRVHUb9Y7XoXQKsWkWyyQSU1ctFeV2G", "User", "Local" },
                    { 3, 300000m, "tranthib@gmail.com", "Tran Thi B", null, null, "None", false, true, "Pending", "$2a$11$RWLRTFtTEahesPi02mxgpOfbMOwZgu9no8aQilhnt5nWnH1G4YFnK", "User", "Local" },
                    { 4, 1000000m, "johnsmith@gmail.com", "John Smith", null, null, "None", false, true, "Pending", "$2a$11$BZ0hqIXcA7Ryu47oU4IQPONZ8Ov5LsflaXS7ogP.jBlmVih5R0RW2", "User", "Tourist" },
                    { 5, 800000m, "emilybrown@gmail.com", "Emily Brown", null, null, "None", false, true, "Pending", "$2a$11$XBO.jOXFamBoi2Qf2yxdrurFzmvRZP0Y1HW5mr8oPCOwqkn3LBNIe", "User", "Tourist" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BatteryLevel", "PlateNumber", "PricePerMinute", "StationId", "Status", "VehicleType" },
                values: new object[,]
                {
                    { 1, 90, "BK-001", 500m, 1, "Available", "Bike" },
                    { 2, 85, "BK-002", 500m, 1, "Available", "Bike" },
                    { 3, 70, "BK-003", 500m, 1, "InUse", "Bike" },
                    { 4, 95, "SC-001", 1500m, 1, "Available", "E-Scooter" },
                    { 5, 40, "SC-002", 1500m, 1, "Maintenance", "E-Scooter" },
                    { 6, 88, "BK-101", 500m, 2, "Available", "Bike" },
                    { 7, 92, "BK-102", 500m, 2, "Available", "Bike" },
                    { 8, 60, "BK-103", 500m, 2, "InUse", "Bike" },
                    { 9, 75, "SC-101", 1500m, 2, "Available", "E-Scooter" },
                    { 10, 19, "SC-102", 1500m, 2, "Maintenance", "E-Scooter" },
                    { 11, 90, "BK-201", 500m, 3, "Available", "Bike" },
                    { 12, 85, "BK-202", 500m, 3, "Available", "Bike" },
                    { 13, 80, "BK-203", 500m, 3, "Available", "Bike" },
                    { 14, 65, "SC-201", 1500m, 3, "InUse", "E-Scooter" },
                    { 15, 95, "SC-202", 1500m, 3, "Available", "E-Scooter" },
                    { 16, 88, "BK-301", 500m, 4, "Available", "Bike" },
                    { 17, 70, "BK-302", 500m, 4, "InUse", "Bike" },
                    { 18, 92, "BK-303", 500m, 4, "Available", "Bike" },
                    { 19, 10, "SC-301", 1500m, 4, "Maintenance", "E-Scooter" },
                    { 20, 90, "SC-302", 1500m, 4, "Available", "E-Scooter" },
                    { 21, 20, "BK-401", 500m, 5, "Maintenance", "Bike" },
                    { 22, 80, "BK-402", 500m, 5, "Available", "Bike" },
                    { 23, 85, "BK-403", 500m, 5, "Available", "Bike" },
                    { 24, 60, "SC-401", 1500m, 5, "InUse", "E-Scooter" },
                    { 25, 95, "SC-402", 1500m, 5, "Available", "E-Scooter" },
                    { 26, 90, "BK-501", 500m, 6, "Available", "Bike" },
                    { 27, 85, "BK-502", 500m, 6, "Available", "Bike" },
                    { 28, 80, "BK-503", 500m, 6, "Available", "Bike" },
                    { 29, 65, "SC-501", 1500m, 6, "InUse", "E-Scooter" },
                    { 30, 95, "SC-502", 1500m, 6, "Available", "E-Scooter" },
                    { 31, 88, "BK-601", 500m, 7, "Available", "Bike" },
                    { 32, 90, "BK-602", 500m, 7, "Available", "Bike" },
                    { 33, 85, "BK-603", 500m, 7, "Available", "Bike" },
                    { 34, 16, "SC-601", 1500m, 7, "Maintenance", "E-Scooter" },
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

            migrationBuilder.InsertData(
                table: "WalletTransactions",
                columns: new[] { "Id", "Amount", "CreatedAt", "Method", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 9000m, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "MoMo", "Payment", 2 },
                    { 2, 15000m, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "VNPay", "Payment", 3 },
                    { 3, 20000m, new DateTime(2026, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ApplePay", "Payment", 4 },
                    { 4, 30000m, new DateTime(2026, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "PayPal", "Payment", 5 },
                    { 5, 25000m, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Payment", 2 },
                    { 6, 40000m, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Payment", 4 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BaseAmount", "DiscountPercent", "EndTime", "FinalAmount", "PaymentMethod", "PickupStationId", "ReturnStationId", "StartTime", "Status", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 10000m, 10m, new DateTime(2026, 5, 2, 0, 20, 0, 0, DateTimeKind.Unspecified), 9000m, null, 1, 2, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 2, 1 },
                    { 2, 15000m, 0m, new DateTime(2026, 5, 1, 0, 15, 0, 0, DateTimeKind.Unspecified), 15000m, null, 2, 3, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 4, 6 },
                    { 3, 20000m, 10m, new DateTime(2026, 4, 30, 0, 30, 0, 0, DateTimeKind.Unspecified), 18000m, null, 3, 4, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 3, 11 },
                    { 4, 0m, 0m, null, 0m, null, 4, 5, new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 5, 16 },
                    { 5, 12000m, 15m, new DateTime(2026, 4, 26, 0, 25, 0, 0, DateTimeKind.Unspecified), 10000m, null, 5, 6, new DateTime(2026, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 2, 21 },
                    { 6, 30000m, 10m, new DateTime(2026, 4, 18, 0, 40, 0, 0, DateTimeKind.Unspecified), 27000m, null, 6, 7, new DateTime(2026, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 4, 26 },
                    { 7, 50000m, 10m, new DateTime(2026, 4, 3, 0, 50, 0, 0, DateTimeKind.Unspecified), 45000m, null, 7, 8, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 3, 31 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerifications_Email_OtpCode",
                table: "OtpVerifications",
                columns: new[] { "Email", "OtpCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RentalId",
                table: "Payments",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PickupStationId",
                table: "Rentals",
                column: "PickupStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ReturnStationId",
                table: "Rentals",
                column: "ReturnStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId",
                unique: true,
                filter: "[Status] = 'InProgress'");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_VehicleId",
                table: "Rentals",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_StationId",
                table: "Vehicles",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_UserId",
                table: "WalletTransactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpVerifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
