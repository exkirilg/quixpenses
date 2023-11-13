using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quixpenses.App.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_settings_id",
                table: "users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "users_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_settings_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_user_settings_id",
                table: "users",
                column: "user_settings_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_settings_currency_id",
                table: "users_settings",
                column: "currency_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_users_settings_user_settings_id",
                table: "users",
                column: "user_settings_id",
                principalTable: "users_settings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_users_settings_user_settings_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "users_settings");

            migrationBuilder.DropIndex(
                name: "ix_users_user_settings_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "user_settings_id",
                table: "users");
        }
    }
}
