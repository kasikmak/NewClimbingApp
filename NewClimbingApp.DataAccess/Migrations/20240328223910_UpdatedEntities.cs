using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewClimbingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Crags_CragId",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "AscentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquiperId",
                table: "Routes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CragId",
                table: "Routes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsClimbed",
                table: "Routes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AscentId",
                table: "Users",
                column: "AscentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Crags_CragId",
                table: "Routes",
                column: "CragId",
                principalTable: "Crags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ascents_AscentId",
                table: "Users",
                column: "AscentId",
                principalTable: "Ascents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Crags_CragId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ascents_AscentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AscentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AscentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsClimbed",
                table: "Routes");

            migrationBuilder.AlterColumn<int>(
                name: "EquiperId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CragId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Crags_CragId",
                table: "Routes",
                column: "CragId",
                principalTable: "Crags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
