using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalSoftwareAssignment.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnFromProgressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BegginerTests",
                table: "Progress",
                newName: "BeginnerTests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BeginnerTests",
                table: "Progress",
                newName: "BegginerTests");
        }
    }
}
