using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quixpenses.App.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class TransactionSum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "sum",
                table: "transactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "sum",
                table: "transactions",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
