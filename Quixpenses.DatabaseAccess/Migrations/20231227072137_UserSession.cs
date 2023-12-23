using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quixpenses.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users_sessions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    command_type = table.Column<string>(type: "text", nullable: true),
                    command = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_sessions_users_id",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users_sessions");
        }
    }
}
