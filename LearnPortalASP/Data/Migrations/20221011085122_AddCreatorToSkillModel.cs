using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnPortalASP.Data.Migrations
{
    public partial class AddCreatorToSkillModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Skills",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatorUserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Skills", x => x.Id);
            //    });

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserName",
                table: "Skills"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropTable(
        //        name: "Skills");
        }
    }
}
