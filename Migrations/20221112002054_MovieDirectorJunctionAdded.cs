using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegansMatineeX.Migrations
{
    public partial class MovieDirectorJunctionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCasts_Director_DirectorID",
                table: "MovieCasts");

            migrationBuilder.DropIndex(
                name: "IX_MovieCasts_DirectorID",
                table: "MovieCasts");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "MovieCasts");

            migrationBuilder.CreateTable(
                name: "MovieDirectors",
                columns: table => new
                {
                    MovieDirectorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    DirectorID = table.Column<int>(type: "int", nullable: false),
                    Rank2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => x.MovieDirectorID);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Director_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Director",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_DirectorID",
                table: "MovieDirectors",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_MovieID",
                table: "MovieDirectors",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.AddColumn<int>(
                name: "DirectorID",
                table: "MovieCasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieCasts_DirectorID",
                table: "MovieCasts",
                column: "DirectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCasts_Director_DirectorID",
                table: "MovieCasts",
                column: "DirectorID",
                principalTable: "Director",
                principalColumn: "ID");
        }
    }
}
