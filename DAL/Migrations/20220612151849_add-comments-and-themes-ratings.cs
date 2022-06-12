using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addcommentsandthemesratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_StudyingMaterials_StudyingMaterialId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_StudyingMaterialId",
                table: "Comments",
                newName: "IX_Comments_StudyingMaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommentRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Like = table.Column<bool>(type: "bit", nullable: false),
                    Dislike = table.Column<bool>(type: "bit", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentRating_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThemeRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThemeRating_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRating_CommentId",
                table: "CommentRating",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeRating_ThemeId",
                table: "ThemeRating",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_StudyingMaterials_StudyingMaterialId",
                table: "Comments",
                column: "StudyingMaterialId",
                principalTable: "StudyingMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_StudyingMaterials_StudyingMaterialId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CommentRating");

            migrationBuilder.DropTable(
                name: "ThemeRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_StudyingMaterialId",
                table: "Comment",
                newName: "IX_Comment_StudyingMaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_StudyingMaterials_StudyingMaterialId",
                table: "Comment",
                column: "StudyingMaterialId",
                principalTable: "StudyingMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
