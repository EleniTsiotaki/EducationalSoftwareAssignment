using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalSoftwareAssignment.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsUnlockedFieldInTestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUnlocked",
                table: "Tests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsUnlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsUnlocked",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUnlocked",
                table: "Tests");
        }
    }
}
