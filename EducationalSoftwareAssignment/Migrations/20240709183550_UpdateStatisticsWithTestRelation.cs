using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationalSoftwareAssignment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatisticsWithTestRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Tests_TestId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_TestId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Statistics");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Test_Id",
                table: "Statistics",
                column: "Test_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Tests_Test_Id",
                table: "Statistics",
                column: "Test_Id",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Tests_Test_Id",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_Test_Id",
                table: "Statistics");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Statistics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TestId",
                table: "Statistics",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Tests_TestId",
                table: "Statistics",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
