using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewClimbingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAscent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Style",
                table: "Ascents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Ascents");
        }
    }
}
