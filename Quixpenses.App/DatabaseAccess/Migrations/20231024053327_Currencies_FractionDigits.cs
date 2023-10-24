using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quixpenses.App.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class Currencies_FractionDigits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "EUR",
                column: "fraction_digits",
                value: 2);

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "USD",
                column: "fraction_digits",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "EUR",
                column: "fraction_digits",
                value: 100);

            migrationBuilder.UpdateData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "USD",
                column: "fraction_digits",
                value: 100);
        }
    }
}
