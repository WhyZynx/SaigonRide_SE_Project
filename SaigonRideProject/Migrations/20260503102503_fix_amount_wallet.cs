using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaigonRideProject.Migrations
{
    /// <inheritdoc />
    public partial class fix_amount_wallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Sifzrgh6QYJx1JIyqscOmOw76opL3m065U1gtmveY3HVGJ55ta7.y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$CEhf64ejND1DTrfEhN/a6uff1eL/opnYlfWBGk/gojQDqJ.5fPnVS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$gYriambXfI1Jbx9ALLpD8OF8lQW1Ar/DluYmaAbKmDTsf9DFUA71q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$v/Zju6gwiU8iF5.CMCpon.OzGAPllB9vrsA5mCRDBOi04YVljFpj6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$okvPPgPpzX8xKzBuhoqb5uYRYLsJtOBy93fIjt8Jre2y0g5DZRFW6");

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 9000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 15000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 20000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 30000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Amount",
                value: 25000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Amount",
                value: 40000m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: -9000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: -15000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: -20000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: -30000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Amount",
                value: -25000m);

            migrationBuilder.UpdateData(
                table: "WalletTransactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Amount",
                value: -40000m);
        }
    }
}
