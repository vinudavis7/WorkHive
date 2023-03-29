using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HourlyRate",
                table: "User",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
