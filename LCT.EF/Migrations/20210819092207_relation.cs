using Microsoft.EntityFrameworkCore.Migrations;

namespace LCT.EF.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usersId",
                table: "makbuzlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_makbuzlar_usersId",
                table: "makbuzlar",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_makbuzlar_Users_usersId",
                table: "makbuzlar",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_makbuzlar_Users_usersId",
                table: "makbuzlar");

            migrationBuilder.DropIndex(
                name: "IX_makbuzlar_usersId",
                table: "makbuzlar");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "makbuzlar");
        }
    }
}
