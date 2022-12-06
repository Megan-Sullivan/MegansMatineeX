using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegansMatineeX.Migrations
{
    public partial class NewDbInitializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsID",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Producer",
                newName: "ProducerName");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ProducerName",
                table: "Producer",
                newName: "CompanyName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsID",
                table: "DirectorMovie",
                column: "DirectorsID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorID",
                table: "MovieDirectors",
                column: "DirectorID",
                principalTable: "Directors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
