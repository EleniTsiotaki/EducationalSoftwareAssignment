using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalSoftwareAssignment.Migrations
{
    /// <inheritdoc />
    public partial class AddProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    TotalGrade = table.Column<float>(type: "REAL", nullable: false),
                    AverageGrade = table.Column<decimal>(type: "TEXT", nullable: false),
                    SucceededTests = table.Column<int>(type: "INTEGER", nullable: false),
                    FailedTests = table.Column<int>(type: "INTEGER", nullable: false),
                    BegginerTests = table.Column<int>(type: "INTEGER", nullable: false),
                    IntermediateTests = table.Column<int>(type: "INTEGER", nullable: false),
                    AdvancedTests = table.Column<int>(type: "INTEGER", nullable: false),
                    BeginnerAverage = table.Column<double>(type: "REAL", nullable: false),
                    IntermediateAverage = table.Column<double>(type: "REAL", nullable: false),
                    AdvancedAverage = table.Column<double>(type: "REAL", nullable: false),
                    TotalTime = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Progress");
        }
    }
}
