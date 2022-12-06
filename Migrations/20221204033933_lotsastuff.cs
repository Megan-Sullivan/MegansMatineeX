using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegansMatineeX.Migrations
{
    public partial class lotsastuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Director_DirectorsID",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Director_DirectorID",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.AddColumn<int>(
                name: "ProductionID",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovieProducer",
                columns: table => new
                {
                    MoviesMovieID = table.Column<int>(type: "int", nullable: false),
                    ProducersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProducer", x => new { x.MoviesMovieID, x.ProducersID });
                    table.ForeignKey(
                        name: "FK_MovieProducer_Movie_MoviesMovieID",
                        column: x => x.MoviesMovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProducer_Producer_ProducersID",
                        column: x => x.ProducersID,
                        principalTable: "Producer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    ProductionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProducerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.ProductionID);
                    table.ForeignKey(
                        name: "FK_Productions_Producer_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SiteAssignments",
                columns: table => new
                {
                    ProducerID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAssignments", x => x.ProducerID);
                    table.ForeignKey(
                        name: "FK_SiteAssignments_Producer_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ProductionID",
                table: "Movie",
                column: "ProductionID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducer_ProducersID",
                table: "MovieProducer",
                column: "ProducersID");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_ProducerID",
                table: "Productions",
                column: "ProducerID");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsID",
                table: "DirectorMovie",
                column: "DirectorsID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Productions_ProductionID",
                table: "Movie",
                column: "ProductionID",
                principalTable: "Productions",
                principalColumn: "ProductionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors",
                column: "DirectorID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsID",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Productions_ProductionID",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MovieProducer");

            migrationBuilder.DropTable(
                name: "Productions");

            migrationBuilder.DropTable(
                name: "SiteAssignments");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ProductionID",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "ProductionID",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Director_DirectorsID",
                table: "DirectorMovie",
                column: "DirectorsID",
                principalTable: "Director",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Director_DirectorID",
                table: "MovieDirectors",
                column: "DirectorID",
                principalTable: "Director",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
