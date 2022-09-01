using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basicFunctions_DB.Migrations
{
    public partial class FixMaterialsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookFormat",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Materials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Materials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Resolution",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "BookFormat",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Materials");
        }
    }
}
