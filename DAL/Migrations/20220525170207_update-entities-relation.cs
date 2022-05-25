using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updateentitiesrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerPracticalTask");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This course is supposed to teach new users basic knowlage about .NET and C# language.", ".NET Course" },
                    { 2, "This course is supposed to teach new users basic knowlage about Java.", "Java Course" },
                    { 3, "This course is supposed to teach new users basic knowlage about C++ language.", "C++ Course" },
                    { 4, "This course is supposed to teach new users basic knowlage about HTML markup language.", "HTML Course" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TaskId",
                table: "Answers",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_PracticalTasks_TaskId",
                table: "Answers",
                column: "TaskId",
                principalTable: "PracticalTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_PracticalTasks_TaskId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_TaskId",
                table: "Answers");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "AnswerPracticalTask",
                columns: table => new
                {
                    AnswersId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerPracticalTask", x => new { x.AnswersId, x.TasksId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerPracticalTask_TasksId",
                table: "AnswerPracticalTask",
                column: "TasksId");
        }
    }
}
