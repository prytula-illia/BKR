using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class removetaskstatistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticalTasks_UserStatistics_UserStatisticsId",
                table: "PracticalTasks");

            migrationBuilder.DropIndex(
                name: "IX_PracticalTasks_UserStatisticsId",
                table: "PracticalTasks");

            migrationBuilder.DropColumn(
                name: "UserStatisticsId",
                table: "PracticalTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
