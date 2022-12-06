using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegansMatineeX.Migrations
{
    public partial class TouchUp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_DirectorID",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_DirectorID",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorID",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorID",
                table: "Movie",
                column: "DirectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_DirectorID",
                table: "Movie",
                column: "DirectorID",
                principalTable: "Director",
                principalColumn: "ID");
        }
    }
}
