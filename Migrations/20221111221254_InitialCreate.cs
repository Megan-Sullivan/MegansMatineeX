using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegansMatineeX.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectorDetails = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeadAct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadActName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeadActDetails = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAct", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LeadAct = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhereToWatch = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "MovieCast",
                columns: table => new
                {
                    MovieCastID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    LeadActID = table.Column<int>(type: "int", nullable: false),
                    DirectorID = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCast", x => x.MovieCastID);
                    table.ForeignKey(
                        name: "FK_MovieCast_Director_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Director",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCast_LeadAct_LeadActID",
                        column: x => x.LeadActID,
                        principalTable: "LeadAct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCast_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_DirectorID",
                table: "MovieCast",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_LeadActID",
                table: "MovieCast",
                column: "LeadActID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovieID",
                table: "MovieCast",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCast");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "LeadAct");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
