using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class Fixcascadewaletuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Users_UserId",
                table: "WalletTransactions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XLID8GkxlHOkD2e4h/dLBuIi91xiqXtby.PwG2j44az8sVS7xOvYO");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Users_UserId",
                table: "WalletTransactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Users_UserId",
                table: "WalletTransactions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$1BNknxqDbHtGeRNxCYJFsO05B01VsUh0ORVrr1xeqN0yJS7nhlT2a");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Users_UserId",
                table: "WalletTransactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
