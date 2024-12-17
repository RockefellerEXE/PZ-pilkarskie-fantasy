using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kluby",
                columns: table => new
                {
                    KlubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKlubu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kluby", x => x.KlubId);
                });

            migrationBuilder.CreateTable(
                name: "Mecze",
                columns: table => new
                {
                    MeczId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataMeczu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wynik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DruzynaDomowa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DruzynaWyjazdowa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecze", x => x.MeczId);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    UzytkownikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Punkty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.UzytkownikId);
                });

            migrationBuilder.CreateTable(
                name: "Zawodnicy",
                columns: table => new
                {
                    ZawodnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Narodowosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    punkty = table.Column<int>(type: "int", nullable: false),
                    cena = table.Column<double>(type: "float", nullable: false),
                    posiadanie = table.Column<int>(type: "int", nullable: false),
                    KlubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zawodnicy", x => x.ZawodnikId);
                    table.ForeignKey(
                        name: "FK_Zawodnicy_Kluby_KlubId",
                        column: x => x.KlubId,
                        principalTable: "Kluby",
                        principalColumn: "KlubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatystykiZawodnikow",
                columns: table => new
                {
                    StatystykaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZawodnikId = table.Column<int>(type: "int", nullable: false),
                    MeczId = table.Column<int>(type: "int", nullable: false),
                    Minuty = table.Column<int>(type: "int", nullable: false),
                    Bramki = table.Column<int>(type: "int", nullable: false),
                    Asysty = table.Column<int>(type: "int", nullable: false),
                    BramkiSamobojcze = table.Column<int>(type: "int", nullable: false),
                    KarneWykonane = table.Column<int>(type: "int", nullable: false),
                    KarneZmarnowane = table.Column<int>(type: "int", nullable: false),
                    ZoltaKartka = table.Column<int>(type: "int", nullable: false),
                    CzerwonaKartka = table.Column<int>(type: "int", nullable: false),
                    StrzalyObronione = table.Column<int>(type: "int", nullable: false),
                    Punkty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatystykiZawodnikow", x => x.StatystykaId);
                    table.ForeignKey(
                        name: "FK_StatystykiZawodnikow_Mecze_MeczId",
                        column: x => x.MeczId,
                        principalTable: "Mecze",
                        principalColumn: "MeczId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatystykiZawodnikow_Zawodnicy_ZawodnikId",
                        column: x => x.ZawodnikId,
                        principalTable: "Zawodnicy",
                        principalColumn: "ZawodnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatystykiZawodnikow_MeczId",
                table: "StatystykiZawodnikow",
                column: "MeczId");

            migrationBuilder.CreateIndex(
                name: "IX_StatystykiZawodnikow_ZawodnikId",
                table: "StatystykiZawodnikow",
                column: "ZawodnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zawodnicy_KlubId",
                table: "Zawodnicy",
                column: "KlubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatystykiZawodnikow");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Mecze");

            migrationBuilder.DropTable(
                name: "Zawodnicy");

            migrationBuilder.DropTable(
                name: "Kluby");
        }
    }
}
