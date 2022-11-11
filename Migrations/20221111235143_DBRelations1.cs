using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegansMatineeX.Migrations
{
    public partial class DBRelations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Director_DirectorID",
                table: "MovieCast");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_LeadAct_LeadActID",
                table: "MovieCast");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Movie_MovieID",
                table: "MovieCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.RenameTable(
                name: "MovieCast",
                newName: "MovieCasts");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_MovieID",
                table: "MovieCasts",
                newName: "IX_MovieCasts_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_LeadActID",
                table: "MovieCasts",
                newName: "IX_MovieCasts_LeadActID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_DirectorID",
                table: "MovieCasts",
                newName: "IX_MovieCasts_DirectorID");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorID",
                table: "MovieCasts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCasts",
                table: "MovieCasts",
                column: "MovieCastID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCasts_Director_DirectorID",
                table: "MovieCasts",
                column: "DirectorID",
                principalTable: "Director",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCasts_LeadAct_LeadActID",
                table: "MovieCasts",
                column: "LeadActID",
                principalTable: "LeadAct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCasts_Movie_MovieID",
                table: "MovieCasts",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCasts_Director_DirectorID",
                table: "MovieCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCasts_LeadAct_LeadActID",
                table: "MovieCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCasts_Movie_MovieID",
                table: "MovieCasts");

            migrationBuilder.DropTable(
                name: "DirectorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCasts",
                table: "MovieCasts");

            migrationBuilder.RenameTable(
                name: "MovieCasts",
                newName: "MovieCast");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCasts_MovieID",
                table: "MovieCast",
                newName: "IX_MovieCast_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCasts_LeadActID",
                table: "MovieCast",
                newName: "IX_MovieCast_LeadActID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCasts_DirectorID",
                table: "MovieCast",
                newName: "IX_MovieCast_DirectorID");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorID",
                table: "MovieCast",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                column: "MovieCastID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Director_DirectorID",
                table: "MovieCast",
                column: "DirectorID",
                principalTable: "Director",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_LeadAct_LeadActID",
                table: "MovieCast",
                column: "LeadActID",
                principalTable: "LeadAct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Movie_MovieID",
                table: "MovieCast",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
