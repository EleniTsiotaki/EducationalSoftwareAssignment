using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalSoftwareAssignment.Migrations
{
    /// <inheritdoc />
    public partial class AddedModuleVisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Course11Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course12Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course13Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course21Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course22Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course23Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course31Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course32Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course33Visits",
                table: "Progress",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course11Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course12Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course13Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course21Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course22Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course23Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course31Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course32Visits",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "Course33Visits",
                table: "Progress");
        }
    }
}
