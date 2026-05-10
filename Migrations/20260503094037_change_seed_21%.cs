using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class change_seed_21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Capacity",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$S7qYoQUvSWsM42h/Ixkdhu2aGaFuMm6NsHWRMh.kp8A5cy2FCyp6.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$GKDgIEYGnwIEYF.UXTjNX.VvjPAEW2I2ML5Z4dXZ621UNo.Q2MpFe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$jADm7D71v5BOa2n7y5YtHuwUC11aGOZROaoA6c35alGk1zlSv/Qzq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$QyHHzI990yZxe1Tmg0zRCuvikOKlUx2jhkHiz1.QwLYI1Wz1lvOuO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$vgg17ewC.oP9EE7kDIoMXe2DIAFaYWU4nsKD.7ajbpIlkPrCVF5zO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Capacity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ZquWWPbxP/YzNXZv9850kORUIz0gd52C2Yd9UyqktyXcIVz8QRA0O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$DWWHf4wqhnt.2GYIYU16EOR8zzSVypM2eDmsWnan2WAgKcrT3jMIi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$IBYjTWgqQJZcUQPoaeRkQOY0hevfc5QBMxkSIbKwpgYRdy7rMyya.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$53E1tV4K54IvlC8eItxJsefboWkdQxwgHas7bjHn63S77kxdvJDFG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$A8msskRCffxmU3oGfyIWh.UJs4MGcO7gb2sOwUUB70qwqzMUYYTF2");
        }
    }
}
