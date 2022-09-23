using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basicFunctions_DB.Migrations
{
    public partial class addreferencetocousesinmaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CourseId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "CourseMaterial",
                columns: table => new
                {
                    CourseMaterialsId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaterial", x => new { x.CourseMaterialsId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CourseMaterial_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMaterial_Materials_CourseMaterialsId",
                        column: x => x.CourseMaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_CoursesId",
                table: "CourseMaterial",
                column: "CoursesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMaterial");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
