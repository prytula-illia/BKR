using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updateentitiesmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserLogin",
                table: "UserStatistics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserStatisticsId",
                table: "PracticalTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PracticalTasks_UserStatisticsId",
                table: "PracticalTasks",
                column: "UserStatisticsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticalTasks_UserStatistics_UserStatisticsId",
                table: "PracticalTasks",
                column: "UserStatisticsId",
                principalTable: "UserStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticalTasks_UserStatistics_UserStatisticsId",
                table: "PracticalTasks");

            migrationBuilder.DropIndex(
                name: "IX_PracticalTasks_UserStatisticsId",
                table: "PracticalTasks");

            migrationBuilder.DropColumn(
                name: "UserLogin",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "UserStatisticsId",
                table: "PracticalTasks");
        }
    }
}
