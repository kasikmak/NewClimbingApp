using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewClimbingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ascentRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ascents_AscentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AscentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AscentId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "AscentUser",
                columns: table => new
                {
                    AscentsId = table.Column<int>(type: "int", nullable: false),
                    ClimbersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AscentUser", x => new { x.AscentsId, x.ClimbersId });
                    table.ForeignKey(
                        name: "FK_AscentUser_Ascents_AscentsId",
                        column: x => x.AscentsId,
                        principalTable: "Ascents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AscentUser_Users_ClimbersId",
                        column: x => x.ClimbersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AscentUser_ClimbersId",
                table: "AscentUser",
                column: "ClimbersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AscentUser");

            migrationBuilder.AddColumn<int>(
                name: "AscentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AscentId",
                table: "Users",
                column: "AscentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ascents_AscentId",
                table: "Users",
                column: "AscentId",
                principalTable: "Ascents",
                principalColumn: "Id");
        }
    }
}
