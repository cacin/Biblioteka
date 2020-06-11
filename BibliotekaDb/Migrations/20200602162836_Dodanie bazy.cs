using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekaDb.Migrations
{
    public partial class Dodaniebazy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pozycje",
                columns: table => new
                {
                    PozycjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "varchar(200)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Rok = table.Column<int>(nullable: false),
                    Rodzaj = table.Column<string>(type: "varchar(20)", nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozycje", x => x.PozycjaId);
                });

            migrationBuilder.CreateTable(
                name: "Rodzaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historia",
                columns: table => new
                {
                    HisoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOd = table.Column<DateTimeOffset>(nullable: false),
                    DataDo = table.Column<DateTime>(nullable: true),
                    Osoba = table.Column<string>(nullable: true),
                    PozycjaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historia", x => x.HisoriaID);
                    table.ForeignKey(
                        name: "FK_Historia_Pozycje_PozycjaId",
                        column: x => x.PozycjaId,
                        principalTable: "Pozycje",
                        principalColumn: "PozycjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historia_PozycjaId",
                table: "Historia",
                column: "PozycjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historia");

            migrationBuilder.DropTable(
                name: "Rodzaje");

            migrationBuilder.DropTable(
                name: "Pozycje");
        }
    }
}
