using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCT.EF.Migrations
{
    public partial class insertImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "makbuzlar",
                newName: "Description");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "makbuzlar",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "makbuzlar");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "makbuzlar",
                newName: "description");
        }
    }
}
