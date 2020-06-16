using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekaDb.Migrations
{
    public partial class DodanieUzytkonika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uzytkownik",
                table: "Pozycje",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "Index_uzytkownik",
                table: "Pozycje",
                column: "Uzytkownik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_uzytkownik",
                table: "Pozycje");

            migrationBuilder.DropColumn(
                name: "Uzytkownik",
                table: "Pozycje");
        }
    }
}
