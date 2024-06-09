using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewClimbingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RouteUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "GradeAsFloat",
                table: "Routes",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeAsFloat",
                table: "Routes");
        }
    }
}
