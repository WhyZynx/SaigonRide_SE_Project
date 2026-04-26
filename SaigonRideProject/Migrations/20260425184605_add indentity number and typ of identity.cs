using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class addindentitynumberandtypofidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportImageUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "Users",
                newName: "IdentityNumber");

            migrationBuilder.AlterColumn<string>(
                name: "PassportStatus",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "None");

            migrationBuilder.AlterColumn<string>(
                name: "OtpCode",
                table: "OtpVerifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "OtpVerifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 12 });

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

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 10 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 12 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 20, 13 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 25, 17 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdentityImageUrl", "IdentityNumber", "IdentityType", "PasswordHash" },
                values: new object[] { "", "000000000", "CCCD", "$2a$11$1oeY.v3kea2o9GSosNw9k.2oEXFj0DxshTE6jKyH9FzZOX4sItmJi" });

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
                value: "Reserved");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                column: "Status",
                value: "Reserved");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                column: "Status",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                column: "Status",
                value: "Reserved");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21,
                column: "Status",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 24,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 27,
                column: "Status",
                value: "Reserved");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 29,
                column: "Status",
                value: "InUse");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerifications_Email_OtpCode",
                table: "OtpVerifications",
                columns: new[] { "Email", "OtpCode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_OtpVerifications_Email_OtpCode",
                table: "OtpVerifications");

            migrationBuilder.DropColumn(
                name: "IdentityImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IdentityNumber",
                table: "Users",
                newName: "PassportNumber");

            migrationBuilder.AlterColumn<string>(
                name: "PassportStatus",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Pending");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PassportImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OtpCode",
                table: "OtpVerifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "OtpVerifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 20, 10 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 15, 8 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 15, 7 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 20, 12 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 9 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 15, 8 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 15, 7 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 18, 10 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 14, 6 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 14, 7 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 16, 8 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Capacity", "CurrentInventory" },
                values: new object[] { 20, 11 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PassportImageUrl", "PassportNumber", "PasswordHash" },
                values: new object[] { null, null, "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Available");

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
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 21,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 24,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 27,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 29,
                column: "Status",
                value: "Available");
        }
    }
}
