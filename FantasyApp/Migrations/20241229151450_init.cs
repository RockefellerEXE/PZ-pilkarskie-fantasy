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
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kluby", x => x.KlubId);
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
                    KlubId = table.Column<int>(type: "int", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Punkty = table.Column<int>(type: "int", nullable: false)
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
                name: "Druzyny",
                columns: table => new
                {
                    DruzynaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    NazwaDruzyny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budzet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Druzyny", x => x.DruzynaId);
                    table.ForeignKey(
                        name: "FK_Druzyny_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "UzytkownikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkladDruzyny",
                columns: table => new
                {
                    DruzynaId = table.Column<int>(type: "int", nullable: false),
                    ZawodnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkladDruzyny", x => new { x.DruzynaId, x.ZawodnikId });
                    table.ForeignKey(
                        name: "FK_SkladDruzyny_Druzyny_DruzynaId",
                        column: x => x.DruzynaId,
                        principalTable: "Druzyny",
                        principalColumn: "DruzynaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkladDruzyny_Zawodnicy_ZawodnikId",
                        column: x => x.ZawodnikId,
                        principalTable: "Zawodnicy",
                        principalColumn: "ZawodnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatystykiZawodnikow",
                columns: table => new
                {
                    StatystykiZawodnikowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DruzynaId = table.Column<int>(type: "int", nullable: false),
                    ZawodnikId = table.Column<int>(type: "int", nullable: false),
                    Bramki = table.Column<int>(type: "int", nullable: false),
                    Asysty = table.Column<int>(type: "int", nullable: false),
                    ZolteKartki = table.Column<int>(type: "int", nullable: false),
                    CzerwoneKartki = table.Column<int>(type: "int", nullable: false),
                    KarneSpowodowane = table.Column<int>(type: "int", nullable: false),
                    KarneWywalczone = table.Column<int>(type: "int", nullable: false),
                    KarneZmarnowane = table.Column<int>(type: "int", nullable: false),
                    StrzalyObronione = table.Column<int>(type: "int", nullable: false),
                    Punkty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatystykiZawodnikow", x => x.StatystykiZawodnikowId);
                    table.ForeignKey(
                        name: "FK_StatystykiZawodnikow_Druzyny_DruzynaId",
                        column: x => x.DruzynaId,
                        principalTable: "Druzyny",
                        principalColumn: "DruzynaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatystykiZawodnikow_Zawodnicy_ZawodnikId",
                        column: x => x.ZawodnikId,
                        principalTable: "Zawodnicy",
                        principalColumn: "ZawodnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfery",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DruzynaId = table.Column<int>(type: "int", nullable: false),
                    ZawodnikId = table.Column<int>(type: "int", nullable: false),
                    TypTransferu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfery", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK_Transfery_Druzyny_DruzynaId",
                        column: x => x.DruzynaId,
                        principalTable: "Druzyny",
                        principalColumn: "DruzynaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfery_Zawodnicy_ZawodnikId",
                        column: x => x.ZawodnikId,
                        principalTable: "Zawodnicy",
                        principalColumn: "ZawodnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kluby",
                columns: new[] { "KlubId", "Nazwa" },
                values: new object[,]
                {
                    { 1, "FC Barcelona" },
                    { 2, "Real Madrid" },
                    { 3, "Manchester United" }
                });

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "UzytkownikId", "Email", "Haslo", "Login", "Punkty" },
                values: new object[,]
                {
                    { 1, "user1@example.com", "password1", "user1", 0 },
                    { 2, "user2@example.com", "password2", "user2", 0 },
                    { 3, "user3@example.com", "password3", "user3", 0 }
                });

            migrationBuilder.InsertData(
                table: "Druzyny",
                columns: new[] { "DruzynaId", "Budzet", "NazwaDruzyny", "UzytkownikId" },
                values: new object[,]
                {
                    { 1, 100, "Drużyna A", 1 },
                    { 2, 100, "Drużyna B", 2 },
                    { 3, 100, "Drużyna C", 3 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "Imie", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 1, 50m, "Marc", 1, "Ter Stegen", "Bramkarz", 100 },
                    { 2, 55m, "Thibaut", 2, "Courtois", "Bramkarz", 95 },
                    { 3, 40m, "Gerard", 1, "Pique", "Obrońca", 80 },
                    { 4, 42m, "David", 2, "Alaba", "Obrońca", 85 },
                    { 5, 60m, "Bruno", 3, "Fernandes", "Pomocnik", 110 },
                    { 6, 55m, "Pedri", 1, "Gonzalez", "Pomocnik", 105 },
                    { 7, 70m, "Marcus", 3, "Rashford", "Napastnik", 120 },
                    { 8, 75m, "Karim", 2, "Benzema", "Napastnik", 130 }
                });

            migrationBuilder.InsertData(
                table: "SkladDruzyny",
                columns: new[] { "DruzynaId", "ZawodnikId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "DruzynaId", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, 1, 0, 0, 0, 5, 0, 1, 0 },
                    { 2, 1, 1, 0, 2, 0, 0, 0, 5, 0, 2, 0 },
                    { 3, 1, 1, 0, 1, 0, 0, 0, 5, 0, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Transfery",
                columns: new[] { "TransferId", "DruzynaId", "TypTransferu", "ZawodnikId" },
                values: new object[,]
                {
                    { 1, 1, "Kupno", 1 },
                    { 2, 1, "Kupno", 3 },
                    { 3, 2, "Kupno", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Druzyny_UzytkownikId",
                table: "Druzyny",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_SkladDruzyny_ZawodnikId",
                table: "SkladDruzyny",
                column: "ZawodnikId");

            migrationBuilder.CreateIndex(
                name: "IX_StatystykiZawodnikow_DruzynaId",
                table: "StatystykiZawodnikow",
                column: "DruzynaId");

            migrationBuilder.CreateIndex(
                name: "IX_StatystykiZawodnikow_ZawodnikId",
                table: "StatystykiZawodnikow",
                column: "ZawodnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfery_DruzynaId",
                table: "Transfery",
                column: "DruzynaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfery_ZawodnikId",
                table: "Transfery",
                column: "ZawodnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zawodnicy_KlubId",
                table: "Zawodnicy",
                column: "KlubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkladDruzyny");

            migrationBuilder.DropTable(
                name: "StatystykiZawodnikow");

            migrationBuilder.DropTable(
                name: "Transfery");

            migrationBuilder.DropTable(
                name: "Druzyny");

            migrationBuilder.DropTable(
                name: "Zawodnicy");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Kluby");
        }
    }
}
