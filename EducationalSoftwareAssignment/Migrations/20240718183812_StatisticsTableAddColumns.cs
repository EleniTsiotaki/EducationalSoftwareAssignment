using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalSoftwareAssignment.Migrations
{
    /// <inheritdoc />
    public partial class StatisticsTableAddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectA",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectB",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectC",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectD",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectE",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrectA",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "IsCorrectB",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "IsCorrectC",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "IsCorrectD",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "IsCorrectE",
                table: "Statistics");
        }
    }
}
