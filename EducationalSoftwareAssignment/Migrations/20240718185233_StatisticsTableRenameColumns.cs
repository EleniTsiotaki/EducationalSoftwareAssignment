using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalSoftwareAssignment.Migrations
{
    /// <inheritdoc />
    public partial class StatisticsTableRenameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCorrectE",
                table: "Statistics",
                newName: "Answer5");

            migrationBuilder.RenameColumn(
                name: "IsCorrectD",
                table: "Statistics",
                newName: "Answer4");

            migrationBuilder.RenameColumn(
                name: "IsCorrectC",
                table: "Statistics",
                newName: "Answer3");

            migrationBuilder.RenameColumn(
                name: "IsCorrectB",
                table: "Statistics",
                newName: "Answer2");

            migrationBuilder.RenameColumn(
                name: "IsCorrectA",
                table: "Statistics",
                newName: "Answer1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer5",
                table: "Statistics",
                newName: "IsCorrectE");

            migrationBuilder.RenameColumn(
                name: "Answer4",
                table: "Statistics",
                newName: "IsCorrectD");

            migrationBuilder.RenameColumn(
                name: "Answer3",
                table: "Statistics",
                newName: "IsCorrectC");

            migrationBuilder.RenameColumn(
                name: "Answer2",
                table: "Statistics",
                newName: "IsCorrectB");

            migrationBuilder.RenameColumn(
                name: "Answer1",
                table: "Statistics",
                newName: "IsCorrectA");
        }
    }
}
