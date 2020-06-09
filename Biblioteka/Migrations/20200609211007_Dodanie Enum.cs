using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekaDb.Migrations
{
    public partial class DodanieEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rodzaje",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 0, null, "Książka" },
                    { 1, null, "DVD" },
                    { 2, null, "CD" },
                    { 3, null, "Vinyl" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rodzaje",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Rodzaje",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rodzaje",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rodzaje",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
