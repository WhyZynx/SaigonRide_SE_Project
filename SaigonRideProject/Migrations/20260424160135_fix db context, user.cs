using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class fixdbcontextuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Users_UserId1",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_UserId1",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WalletTransactions");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId1",
                table: "Rentals",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Users_UserId1",
                table: "Rentals",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Users_UserId1",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserId1",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "WalletTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_UserId1",
                table: "WalletTransactions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Users_UserId1",
                table: "WalletTransactions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
