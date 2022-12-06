using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegansMatineeX.Migrations
{
    public partial class workingOnFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorMovie");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DirectorMovie",
                columns: table => new
                {
                    DirectorsID = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovie", x => new { x.DirectorsID, x.MoviesMovieID });
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Director_DirectorsID",
                        column: x => x.DirectorsID,
                        principalTable: "Director",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Movie_MoviesMovieID",
                        column: x => x.MoviesMovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovie_MoviesMovieID",
                table: "DirectorMovie",
                column: "MoviesMovieID");
        }
    }
}
