using Microsoft.EntityFrameworkCore.Migrations;

namespace Aps.Repository.Migrations
{
    public partial class CreateRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Disciplines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Disciplines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_StudentId",
                table: "Disciplines",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherID",
                table: "Disciplines",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Students_StudentId",
                table: "Disciplines",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Teachers_TeacherID",
                table: "Disciplines",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Students_StudentId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Teachers_TeacherID",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_StudentId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_TeacherID",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Disciplines");
        }
    }
}
