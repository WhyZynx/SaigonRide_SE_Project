using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "IsVerified", "PassportImageUrl", "PassportNumber", "PassportStatus", "PasswordHash", "Role", "UserType" },
                values: new object[] { 1, "admin@saigonride.com", "System Admin", true, null, null, "Approved", "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", "Admin", "Local" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
