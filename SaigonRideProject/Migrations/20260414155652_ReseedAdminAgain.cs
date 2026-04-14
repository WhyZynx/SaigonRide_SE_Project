using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class ReseedAdminAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id",
                    "FullName",
                    "Email",
                    "PasswordHash",
                    "UserType",
                    "Role",
                    "IsVerified",
                    "PassportStatus"
                },
                values: new object[]
                {
                    1,
                    "System Admin",
                    "admin@saigonride.com",
                    "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=",
                    "Local",
                    "Admin",
                    true,
                    "Approved"
                });
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
