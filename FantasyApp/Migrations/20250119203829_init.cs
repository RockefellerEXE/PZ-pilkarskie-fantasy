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
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Punkty = table.Column<int>(type: "int", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
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
                    Budzet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PozostaleTransfrery = table.Column<int>(type: "int", nullable: false)
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
                name: "HistoriaCen",
                columns: table => new
                {
                    HistoriaCenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZawodnikId = table.Column<int>(type: "int", nullable: false),
                    Kolejka = table.Column<int>(type: "int", nullable: false),
                    CenaPrzed = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaCen", x => x.HistoriaCenId);
                    table.ForeignKey(
                        name: "FK_HistoriaCen_Zawodnicy_ZawodnikId",
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
                        name: "FK_StatystykiZawodnikow_Zawodnicy_ZawodnikId",
                        column: x => x.ZawodnikId,
                        principalTable: "Zawodnicy",
                        principalColumn: "ZawodnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkladDruzyny",
                columns: table => new
                {
                    DruzynaId = table.Column<int>(type: "int", nullable: false),
                    ZawodnikId = table.Column<int>(type: "int", nullable: false),
                    PozycjaWDruzynie = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { 1, "Lech Poznań" },
                    { 2, "Raków Częstochowa" },
                    { 3, "Jagiellonia Białystok" },
                    { 4, "Legia Warszawa" },
                    { 5, "Cracovia" },
                    { 6, "Górnik Zabrze" },
                    { 7, "Motor Lublin" },
                    { 8, "Pogoń Szczecin" },
                    { 9, "Widzew Łódź" },
                    { 10, "GKS Katowice" },
                    { 11, "Piast Gliwice" },
                    { 12, "Radomiak Radom" },
                    { 13, "Stal Mielec" },
                    { 14, "Zagłębie Lubin" },
                    { 15, "Puszcza Niepołomice" },
                    { 16, "Korona Kielce" },
                    { 17, "Lechia Gdańsk" },
                    { 18, "Śląsk Wrocław" }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 1, 6.5m, 1, "Mrozek", "Bramkarz", 0 },
                    { 2, 5m, 1, "Bednarek", "Bramkarz", 0 },
                    { 3, 8.5m, 1, "Pereira", "Obrońca", 0 },
                    { 4, 7m, 1, "Gurgul", "Obrońca", 0 },
                    { 5, 6.5m, 1, "Milic", "Obrońca", 0 },
                    { 6, 6.5m, 1, "Douglas", "Obrońca", 0 },
                    { 7, 5.5m, 1, "Salamon", "Obrońca", 0 },
                    { 8, 4.5m, 1, "Andersson", "Obrońca", 0 },
                    { 9, 4.5m, 1, "Pingot", "Obrońca", 0 },
                    { 10, 4.5m, 1, "Hoffman", "Obrońca", 0 },
                    { 11, 4.5m, 1, "Mońka", "Obrońca", 0 },
                    { 12, 4m, 1, "Dagerstal", "Obrońca", 0 },
                    { 13, 4m, 1, "Wichtowski", "Obrońca", 0 },
                    { 14, 10.5m, 1, "Sousa", "Pomocnik", 0 },
                    { 15, 8.5m, 1, "Walemark", "Pomocnik", 0 },
                    { 16, 7m, 1, "Hotic", "Pomocnik", 0 },
                    { 17, 7m, 1, "Hakans", "Pomocnik", 0 },
                    { 18, 7m, 1, "Gholizadeh", "Pomocnik", 0 },
                    { 19, 6m, 1, "Kozubal", "Pomocnik", 0 },
                    { 20, 5m, 1, "Murawski", "Pomocnik", 0 },
                    { 21, 5m, 1, "Jagiełło", "Pomocnik", 0 },
                    { 22, 4.5m, 1, "Ba Loua", "Pomocnik", 0 },
                    { 23, 4m, 1, "S. Loncar", "Pomocnik", 0 },
                    { 24, 4m, 1, "Lisman", "Pomocnik", 0 },
                    { 25, 14m, 1, "Ishak", "Napastnik", 0 },
                    { 26, 6m, 1, "Szymczak", "Napastnik", 0 },
                    { 27, 5.5m, 1, "Fiabema", "Napastnik", 0 },
                    { 28, 5.5m, 2, "Abramowicz", "Bramkarz", 0 },
                    { 29, 4.5m, 2, "Stryjek", "Bramkarz", 0 },
                    { 30, 3m, 2, "Zynel", "Bramkarz", 0 },
                    { 31, 3m, 2, "Piekutkowski", "Bramkarz", 0 },
                    { 32, 3m, 2, "Suchocki", "Bramkarz", 0 },
                    { 33, 6.5m, 2, "Moutinho", "Obrońca", 0 },
                    { 34, 6m, 2, "Sacek", "Obrońca", 0 },
                    { 35, 5.5m, 2, "Skrzypczak", "Obrońca", 0 },
                    { 36, 5.5m, 2, "Dieguez", "Obrońca", 0 },
                    { 37, 5m, 2, "Stojinovic", "Obrońca", 0 },
                    { 38, 4.5m, 2, "Tomas Silva", "Obrońca", 0 },
                    { 39, 4.5m, 2, "Haliti", "Obrońca", 0 },
                    { 40, 4m, 2, "Polak", "Obrońca", 0 },
                    { 41, 4.5m, 2, "Kovacik", "Obrońca", 0 },
                    { 42, 9m, 2, "Hansen", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 43, 8m, 2, "Miki", "Pomocnik", 0 },
                    { 44, 8m, 2, "Curlinov", "Pomocnik", 0 },
                    { 45, 6m, 2, "Kubicki", "Pomocnik", 0 },
                    { 46, 6m, 2, "Nene", "Pomocnik", 0 },
                    { 47, 5.5m, 2, "Romanczuk", "Pomocnik", 0 },
                    { 48, 4.5m, 2, "Listkowski", "Pomocnik", 0 },
                    { 49, 4.5m, 2, "Nguiamba", "Pomocnik", 0 },
                    { 50, 3m, 2, "Kozłowski", "Pomocnik", 0 },
                    { 51, 3m, 2, "Stypułkowski", "Pomocnik", 0 },
                    { 52, 12m, 2, "Imaz", "Napastnik", 0 },
                    { 53, 10m, 2, "Pululu", "Napastnik", 0 },
                    { 54, 6.5m, 2, "Fadiga", "Napastnik", 0 },
                    { 55, 4.5m, 2, "Rybak", "Napastnik", 0 },
                    { 56, 3m, 2, "Pietuszewski", "Napastnik", 0 },
                    { 57, 3m, 2, "Wojdakowski", "Napastnik", 0 },
                    { 58, 7m, 3, "Trelowski", "Bramkarz", 0 },
                    { 59, 4.5m, 3, "Kuciak", "Bramkarz", 0 },
                    { 60, 8.5m, 3, "Carlos", "Obrońca", 0 },
                    { 61, 8m, 3, "Tudor", "Obrońca", 0 },
                    { 62, 7m, 3, "Svarnas", "Obrońca", 0 },
                    { 63, 7m, 3, "Mosór", "Obrońca", 0 },
                    { 64, 7m, 3, "Racovitan", "Obrońca", 0 },
                    { 65, 6.5m, 3, "Arsenic", "Obrońca", 0 },
                    { 66, 6.5m, 3, "Otieno", "Obrońca", 0 },
                    { 67, 6m, 3, "Rodin", "Obrońca", 0 },
                    { 68, 5.5m, 3, "Pestka", "Obrońca", 0 },
                    { 69, 5.5m, 3, "Rundic", "Obrońca", 0 },
                    { 70, 9.5m, 3, "Ivi", "Pomocnik", 0 },
                    { 71, 7.5m, 3, "Ameyaw", "Pomocnik", 0 },
                    { 72, 7m, 3, "Amorim", "Pomocnik", 0 },
                    { 73, 6.5m, 3, "Kocherhin", "Pomocnik", 0 },
                    { 74, 5.5m, 3, "Berggren", "Pomocnik", 0 },
                    { 75, 5m, 3, "Lamprou", "Pomocnik", 0 },
                    { 76, 5.5m, 3, "Plavsic", "Pomocnik", 0 },
                    { 77, 4.5m, 3, "Drachal", "Pomocnik", 0 },
                    { 78, 4.5m, 3, "Czyż", "Pomocnik", 0 },
                    { 79, 4.5m, 3, "Barath", "Pomocnik", 0 },
                    { 80, 4.5m, 3, "Lederman", "Pomocnik", 0 },
                    { 81, 3m, 3, "Nowakowski", "Pomocnik", 0 },
                    { 82, 7.5m, 3, "Brunes", "Napastnik", 0 },
                    { 83, 7m, 3, "Makuch", "Napastnik", 0 },
                    { 84, 5m, 3, "Diaz", "Napastnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 85, 4.5m, 3, "Walczak", "Napastnik", 0 },
                    { 86, 6m, 4, "Tobiasz", "Bramkarz", 0 },
                    { 87, 5m, 4, "Kobylak", "Bramkarz", 0 },
                    { 88, 3m, 4, "Mendes", "Bramkarz", 0 },
                    { 89, 3m, 4, "Banasik", "Bramkarz", 0 },
                    { 90, 8m, 4, "Vinagre", "Obrońca", 0 },
                    { 91, 7.5m, 4, "Wszołek", "Obrońca", 0 },
                    { 92, 6m, 4, "Kapuadi", "Obrońca", 0 },
                    { 93, 7m, 4, "Augustyniak", "Obrońca", 0 },
                    { 94, 6m, 4, "Pankov", "Obrońca", 0 },
                    { 95, 4.5m, 4, "Ziółkowski", "Obrońca", 0 },
                    { 96, 5m, 4, "Jędrzejczyk", "Obrońca", 0 },
                    { 97, 5m, 4, "Barcia", "Obrońca", 0 },
                    { 98, 4.5m, 4, "Burch", "Obrońca", 0 },
                    { 99, 4.5m, 4, "Kun", "Obrońca", 0 },
                    { 100, 3m, 4, "Leszczyński", "Obrońca", 0 },
                    { 101, 8m, 4, "Chodyna", "Pomocnik", 0 },
                    { 102, 8m, 4, "Kapustka", "Pomocnik", 0 },
                    { 103, 7.5m, 4, "Morishita", "Pomocnik", 0 },
                    { 104, 7m, 4, "Elitim", "Pomocnik", 0 },
                    { 105, 6.5m, 4, "Luquinhas", "Pomocnik", 0 },
                    { 106, 5m, 4, "Oyedele", "Pomocnik", 0 },
                    { 107, 5m, 4, "Goncalves", "Pomocnik", 0 },
                    { 108, 4.5m, 4, "Celhaka", "Pomocnik", 0 },
                    { 109, 4.5m, 4, "Urbański", "Pomocnik", 0 },
                    { 110, 3.5m, 4, "Adkonis", "Pomocnik", 0 },
                    { 111, 3m, 4, "Żewłakow", "Pomocnik", 0 },
                    { 112, 8.5m, 4, "Gual", "Napastnik", 0 },
                    { 113, 5.5m, 4, "Nsame", "Napastnik", 0 },
                    { 114, 5.5m, 4, "Alfarela", "Napastnik", 0 },
                    { 115, 5.5m, 4, "Pekhart", "Napastnik", 0 },
                    { 116, 3.5m, 4, "Szczepaniak", "Napastnik", 0 },
                    { 117, 3.5m, 4, "Majchrzak", "Napastnik", 0 },
                    { 118, 5.5m, 5, "Cojocaru", "Bramkarz", 0 },
                    { 119, 4m, 5, "Kamiński", "Bramkarz", 0 },
                    { 120, 6.5m, 5, "Wahlqvist", "Obrońca", 0 },
                    { 121, 6.5m, 5, "Koutris", "Obrońca", 0 },
                    { 122, 5.5m, 5, "Borges", "Obrońca", 0 },
                    { 123, 5m, 5, "Keramitsis", "Obrońca", 0 },
                    { 124, 5.5m, 5, "Zech", "Obrońca", 0 },
                    { 125, 4.5m, 5, "Malec", "Obrońca", 0 },
                    { 126, 4.5m, 5, "Lis", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 127, 3.5m, 5, "D.Loncar", "Obrońca", 0 },
                    { 128, 3.5m, 5, "Lisowski", "Obrońca", 0 },
                    { 129, 8m, 5, "Grosicki", "Pomocnik", 0 },
                    { 130, 7m, 5, "Vahan", "Pomocnik", 0 },
                    { 131, 6m, 5, "Łukasiak", "Pomocnik", 0 },
                    { 132, 6m, 5, "Gorgon", "Pomocnik", 0 },
                    { 133, 5m, 5, "Ulvestad", "Pomocnik", 0 },
                    { 134, 5m, 5, "Kurzawa", "Pomocnik", 0 },
                    { 135, 5m, 5, "Gamboa", "Pomocnik", 0 },
                    { 136, 4.5m, 5, "Przyborek", "Pomocnik", 0 },
                    { 137, 4m, 5, "Korczakowski", "Pomocnik", 0 },
                    { 138, 3.5m, 5, "Smoliński", "Pomocnik", 0 },
                    { 139, 3.5m, 5, "Wędrychowski", "Pomocnik", 0 },
                    { 140, 3m, 5, "Wojciechowski", "Pomocnik", 0 },
                    { 141, 3m, 5, "Bąk", "Pomocnik", 0 },
                    { 142, 10.5m, 5, "Koulouris", "Napastnik", 0 },
                    { 143, 4.5m, 5, "Paryzek", "Napastnik", 0 },
                    { 144, 3.5m, 5, "Klukowski", "Napastnik", 0 },
                    { 145, 5m, 6, "Ravas", "Bramkarz", 0 },
                    { 146, 4m, 6, "Madejski", "Bramkarz", 0 },
                    { 147, 3.5m, 6, "Burek", "Bramkarz", 0 },
                    { 148, 3m, 6, "Golonka", "Bramkarz", 0 },
                    { 149, 6.5m, 6, "Kakabadze", "Obrońca", 0 },
                    { 150, 6.5m, 6, "Olafsson", "Obrońca", 0 },
                    { 151, 6m, 6, "Ghita", "Obrońca", 0 },
                    { 152, 5.5m, 6, "Jugas", "Obrońca", 0 },
                    { 153, 5.5m, 6, "Glik", "Obrońca", 0 },
                    { 154, 5.5m, 6, "Hoskonen", "Obrońca", 0 },
                    { 155, 4.5m, 6, "Biedrzycki", "Obrońca", 0 },
                    { 156, 4.5m, 6, "Skovgaard", "Obrońca", 0 },
                    { 157, 3.5m, 6, "Janasik", "Obrońca", 0 },
                    { 158, 3m, 6, "Wójcik", "Obrońca", 0 },
                    { 159, 3m, 6, "Pestka", "Obrońca", 0 },
                    { 160, 8m, 6, "Hasic", "Pomocnik", 0 },
                    { 161, 7.5m, 6, "Maigaard", "Pomocnik", 0 },
                    { 162, 6m, 6, "Rózga", "Pomocnik", 0 },
                    { 163, 5m, 6, "Al-Ammari", "Pomocnik", 0 },
                    { 164, 5m, 6, "Rakoczy", "Pomocnik", 0 },
                    { 165, 5m, 6, "Sokołowski", "Pomocnik", 0 },
                    { 166, 4.5m, 6, "Atanasov", "Pomocnik", 0 },
                    { 167, 4.5m, 6, "Bochnak", "Pomocnik", 0 },
                    { 168, 4.5m, 6, "Bzdyl", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 169, 3m, 6, "Lachowicz", "Pomocnik", 0 },
                    { 170, 3m, 6, "Pomietło", "Pomocnik", 0 },
                    { 171, 13m, 6, "Kallman", "Napastnik", 0 },
                    { 172, 6.5m, 6, "Buren", "Napastnik", 0 },
                    { 173, 4.5m, 6, "Śmiglewski", "Napastnik", 0 },
                    { 174, 5.5m, 7, "Szromnik", "Bramkarz", 0 },
                    { 175, 4m, 7, "Majchrowicz", "Bramkarz", 0 },
                    { 176, 3m, 7, "Jeleń", "Bramkarz", 0 },
                    { 177, 3m, 7, "Soberka", "Bramkarz", 0 },
                    { 178, 7m, 7, "Janza", "Obrońca", 0 },
                    { 179, 6m, 7, "Josema", "Obrońca", 0 },
                    { 180, 6m, 7, "Janicki", "Obrońca", 0 },
                    { 181, 6m, 7, "Sanchez", "Obrońca", 0 },
                    { 182, 6m, 7, "Szala", "Obrońca", 0 },
                    { 183, 5.5m, 7, "Wojtuszek", "Obrońca", 0 },
                    { 184, 5.5m, 7, "Szcześniak", "Obrońca", 0 },
                    { 185, 4.5m, 7, "Olkowski", "Obrońca", 0 },
                    { 186, 3m, 7, "Barczak", "Obrońca", 0 },
                    { 187, 6.5m, 7, "Rasak", "Pomocnik", 0 },
                    { 188, 6.5m, 7, "Ambros", "Pomocnik", 0 },
                    { 189, 6.5m, 7, "Ismaheel", "Pomocnik", 0 },
                    { 190, 6m, 7, "Lukoszek", "Pomocnik", 0 },
                    { 191, 5.5m, 7, "Hellebrand", "Pomocnik", 0 },
                    { 192, 5m, 7, "Furukawa", "Pomocnik", 0 },
                    { 193, 4.5m, 7, "Nascimento", "Pomocnik", 0 },
                    { 194, 4.5m, 7, "Zielonka", "Pomocnik", 0 },
                    { 195, 3.5m, 7, "Tobolik", "Pomocnik", 0 },
                    { 196, 3m, 7, "Sarapata", "Pomocnik", 0 },
                    { 197, 8m, 7, "Zahovic", "Napastnik", 0 },
                    { 198, 7m, 7, "Podolski", "Napastnik", 0 },
                    { 199, 5.5m, 7, "Buksa", "Napastnik", 0 },
                    { 200, 5m, 7, "Bakis", "Napastnik", 0 },
                    { 201, 5m, 8, "Brkic", "Bramkarz", 0 },
                    { 202, 4.5m, 8, "Rosa", "Bramkarz", 0 },
                    { 203, 3m, 8, "Bartnik", "Bramkarz", 0 },
                    { 204, 3m, 8, "Jeż", "Bramkarz", 0 },
                    { 205, 5.5m, 8, "Luberecki", "Obrońca", 0 },
                    { 206, 5.5m, 8, "Rudol", "Obrońca", 0 },
                    { 207, 5.5m, 8, "Bartos", "Obrońca", 0 },
                    { 208, 5m, 8, "Najemski", "Obrońca", 0 },
                    { 209, 5m, 8, "Stolarski", "Obrońca", 0 },
                    { 210, 5m, 8, "Wojcik", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 211, 5m, 8, "Palacz", "Obrońca", 0 },
                    { 212, 3.5m, 8, "Romanowski", "Obrońca", 0 },
                    { 213, 3m, 8, "Kruk", "Obrońca", 0 },
                    { 214, 7m, 8, "Wolski", "Pomocnik", 0 },
                    { 215, 6.5m, 8, "M.Król", "Pomocnik", 0 },
                    { 216, 5.5m, 8, "Simon", "Pomocnik", 0 },
                    { 217, 5.5m, 8, "Caliskaner", "Pomocnik", 0 },
                    { 218, 5m, 8, "Samper", "Pomocnik", 0 },
                    { 219, 5m, 8, "Kubica", "Pomocnik", 0 },
                    { 220, 5m, 8, "van Hoeven", "Pomocnik", 0 },
                    { 221, 4.5m, 8, "Scalet", "Pomocnik", 0 },
                    { 222, 4m, 8, "Gąsior", "Pomocnik", 0 },
                    { 223, 4m, 8, "Wełniak", "Pomocnik", 0 },
                    { 224, 4m, 8, "R.Król", "Pomocnik", 0 },
                    { 225, 9m, 8, "Mraz", "Napastnik", 0 },
                    { 226, 8m, 8, "Ceglarz", "Napastnik", 0 },
                    { 227, 6.5m, 8, "Ndiaye", "Napastnik", 0 },
                    { 228, 3m, 8, "Śpiewak", "Napastnik", 0 },
                    { 229, 5m, 9, "Gikiewicz", "Bramkarz", 0 },
                    { 230, 4m, 9, "Krzywański", "Bramkarz", 0 },
                    { 231, 3.5m, 9, "Biegański", "Bramkarz", 0 },
                    { 232, 6m, 9, "Żyro", "Obrońca", 0 },
                    { 233, 6m, 9, "Kozlovsky", "Obrońca", 0 },
                    { 234, 5.5m, 9, "Ibiza", "Obrońca", 0 },
                    { 235, 5.5m, 9, "Silva", "Obrońca", 0 },
                    { 236, 5m, 9, "Krajewski", "Obrońca", 0 },
                    { 237, 5m, 9, "Kastrati", "Obrońca", 0 },
                    { 238, 4.5m, 9, "Hajrizi", "Obrońca", 0 },
                    { 239, 3.5m, 9, "Kwiatkowski", "Obrońca", 0 },
                    { 240, 8.5m, 9, "Pawłowski", "Pomocnik", 0 },
                    { 241, 7.5m, 9, "Kerk", "Pomocnik", 0 },
                    { 242, 7m, 9, "Alvarez", "Pomocnik", 0 },
                    { 243, 6.5m, 9, "Łukowski", "Pomocnik", 0 },
                    { 244, 6m, 9, "Cybulski", "Pomocnik", 0 },
                    { 245, 5.5m, 9, "Klimek", "Pomocnik", 0 },
                    { 246, 5m, 9, "Shehu", "Pomocnik", 0 },
                    { 247, 5m, 9, "Hanousek", "Pomocnik", 0 },
                    { 248, 4m, 9, "Diliberto", "Pomocnik", 0 },
                    { 249, 3.5m, 9, "Gong", "Pomocnik", 0 },
                    { 250, 3.5m, 9, "Nunes", "Pomocnik", 0 },
                    { 251, 3m, 9, "Gryzio", "Pomocnik", 0 },
                    { 252, 10.5m, 9, "Rondic", "Napastnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 253, 7m, 9, "Sypek", "Napastnik", 0 },
                    { 254, 5.5m, 9, "Hamulic", "Napastnik", 0 },
                    { 255, 4.5m, 9, "Sobol", "Napastnik", 0 },
                    { 256, 5m, 10, "Kudła", "Bramkarz", 0 },
                    { 257, 4m, 10, "Strączek", "Bramkarz", 0 },
                    { 258, 6.5m, 10, "Jędrych", "Obrońca", 0 },
                    { 259, 6m, 10, "Wasielewski", "Obrońca", 0 },
                    { 260, 6m, 10, "Czerwiński", "Obrońca", 0 },
                    { 261, 5.5m, 10, "Rogala", "Obrońca", 0 },
                    { 262, 5.5m, 10, "Klemenz", "Obrońca", 0 },
                    { 263, 5.5m, 10, "Kuusk", "Obrońca", 0 },
                    { 264, 5.5m, 10, "Komor", "Obrońca", 0 },
                    { 265, 3.5m, 10, "Jaroszek", "Obrońca", 0 },
                    { 266, 3m, 10, "Trepka", "Obrońca", 0 },
                    { 267, 7m, 10, "Błąd", "Pomocnik", 0 },
                    { 268, 6.5m, 10, "Nowak", "Pomocnik", 0 },
                    { 269, 6m, 10, "Galan", "Pomocnik", 0 },
                    { 270, 6m, 10, "Mak", "Pomocnik", 0 },
                    { 271, 5.5m, 10, "Repka", "Pomocnik", 0 },
                    { 272, 5.5m, 10, "Kowalczyk", "Pomocnik", 0 },
                    { 273, 5m, 10, "Milewski", "Pomocnik", 0 },
                    { 274, 5m, 10, "Marzec", "Pomocnik", 0 },
                    { 275, 3.5m, 10, "Antczak", "Pomocnik", 0 },
                    { 276, 3m, 10, "Baranowicz", "Pomocnik", 0 },
                    { 277, 3m, 10, "Bród", "Pomocnik", 0 },
                    { 278, 7.5m, 10, "Zrelak", "Napastnik", 0 },
                    { 279, 7.5m, 10, "Bergier", "Napastnik", 0 },
                    { 280, 4.5m, 10, "Arak", "Napastnik", 0 },
                    { 281, 5.5m, 11, "Plach", "Bramkarz", 0 },
                    { 282, 4m, 11, "Szymański", "Bramkarz", 0 },
                    { 283, 7m, 11, "Pyrka", "Obrońca", 0 },
                    { 284, 6m, 11, "Huk", "Obrońca", 0 },
                    { 285, 6m, 11, "Czerwiński", "Obrońca", 0 },
                    { 286, 5.5m, 11, "Drapiński", "Obrońca", 0 },
                    { 287, 5m, 11, "Munoz", "Obrońca", 0 },
                    { 288, 5m, 11, "Nobrega", "Obrońca", 0 },
                    { 289, 4.5m, 11, "Lewicki", "Obrońca", 0 },
                    { 290, 4.5m, 11, "Mokwa", "Obrońca", 0 },
                    { 291, 4.5m, 11, "Reiner", "Obrońca", 0 },
                    { 292, 3m, 11, "Liszewski", "Obrońca", 0 },
                    { 293, 3m, 11, "Pitan", "Obrońca", 0 },
                    { 294, 9m, 11, "Felix", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 295, 7m, 11, "Chrapek", "Pomocnik", 0 },
                    { 296, 6.5m, 11, "Kądzior", "Pomocnik", 0 },
                    { 297, 5.5m, 11, "Szczepański", "Pomocnik", 0 },
                    { 298, 5.5m, 11, "Dziczek", "Pomocnik", 0 },
                    { 299, 5m, 11, "Tomasiewicz", "Pomocnik", 0 },
                    { 300, 5m, 11, "Kostadinov", "Pomocnik", 0 },
                    { 301, 4m, 11, "Mucha", "Pomocnik", 0 },
                    { 302, 4m, 11, "Leśniak", "Pomocnik", 0 },
                    { 303, 3.5m, 11, "Karbowy", "Pomocnik", 0 },
                    { 304, 6.5m, 11, "Rosołek", "Napastnik", 0 },
                    { 305, 6.5m, 11, "Piasecki", "Napastnik", 0 },
                    { 306, 5.5m, 11, "Katsantonis", "Napastnik", 0 },
                    { 307, 5m, 12, "Mądrzyk", "Bramkarz", 0 },
                    { 308, 4m, 12, "Jałocha", "Bramkarz", 0 },
                    { 309, 6m, 12, "Jaunzems", "Obrońca", 0 },
                    { 310, 6m, 12, "Getinger", "Obrońca", 0 },
                    { 311, 5.5m, 12, "Senger", "Obrońca", 0 },
                    { 312, 5.5m, 12, "Matras", "Obrońca", 0 },
                    { 313, 5m, 12, "Esselink", "Obrońca", 0 },
                    { 314, 5m, 12, "Ehmann", "Obrońca", 0 },
                    { 315, 5m, 12, "Wołkowicz", "Obrońca", 0 },
                    { 316, 3.5m, 12, "Bagalianis", "Obrońca", 0 },
                    { 317, 3.5m, 12, "Pajnowski", "Obrońca", 0 },
                    { 318, 7m, 12, "Domański", "Pomocnik", 0 },
                    { 319, 7m, 12, "Wlazło", "Pomocnik", 0 },
                    { 320, 6m, 12, "Krykun", "Pomocnik", 0 },
                    { 321, 5.5m, 12, "Wolsztyński", "Pomocnik", 0 },
                    { 322, 5m, 12, "Guillaumier", "Pomocnik", 0 },
                    { 323, 5m, 12, "Dadok", "Pomocnik", 0 },
                    { 324, 5m, 12, "Hinokio", "Pomocnik", 0 },
                    { 325, 4.5m, 12, "Tkacz", "Pomocnik", 0 },
                    { 326, 4.5m, 12, "Gerbowski", "Pomocnik", 0 },
                    { 327, 4m, 12, "Knap", "Pomocnik", 0 },
                    { 328, 3.5m, 12, "Bukowski", "Pomocnik", 0 },
                    { 329, 8m, 12, "Shkurin", "Napastnik", 0 },
                    { 330, 5.5m, 12, "Assayag", "Napastnik", 0 },
                    { 331, 4.5m, 13, "Hładun", "Bramkarz", 0 },
                    { 332, 4m, 13, "Buric", "Bramkarz", 0 },
                    { 333, 3m, 13, "Matysek", "Bramkarz", 0 },
                    { 334, 7m, 13, "Wdowiak", "Obrońca", 0 },
                    { 335, 6m, 13, "Grzybek", "Obrońca", 0 },
                    { 336, 5.5m, 13, "Kłudka", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 337, 5.5m, 13, "Mata", "Obrońca", 0 },
                    { 338, 5m, 13, "Orlikowski", "Obrońca", 0 },
                    { 339, 5m, 13, "Ławniczak", "Obrońca", 0 },
                    { 340, 5m, 13, "Kopacz", "Obrońca", 0 },
                    { 341, 3m, 13, "Lepczyński", "Obrońca", 0 },
                    { 342, 5m, 13, "Nalepa", "Obrońca", 0 },
                    { 343, 4.5m, 13, "Jach", "Obrońca", 0 },
                    { 344, 6.5m, 13, "Mróz", "Pomocnik", 0 },
                    { 345, 6.5m, 13, "Szmyt", "Pomocnik", 0 },
                    { 346, 5.5m, 13, "Radwański", "Pomocnik", 0 },
                    { 347, 5m, 13, "Makowski", "Pomocnik", 0 },
                    { 348, 5m, 13, "Dąbrowski", "Pomocnik", 0 },
                    { 349, 5m, 13, "Kusztal", "Pomocnik", 0 },
                    { 350, 4.5m, 13, "Reguła", "Pomocnik", 0 },
                    { 351, 4.5m, 13, "Kolan", "Pomocnik", 0 },
                    { 352, 3.5m, 13, "Dziewiatowski", "Pomocnik", 0 },
                    { 353, 3.5m, 13, "Adamczyk", "Pomocnik", 0 },
                    { 354, 3m, 13, "Kocaba", "Pomocnik", 0 },
                    { 355, 7.5m, 13, "Kurminowski", "Napastnik", 0 },
                    { 356, 7m, 13, "Pieńko", "Napastnik", 0 },
                    { 357, 4.5m, 13, "Woźniak", "Napastnik", 0 },
                    { 358, 4m, 13, "Mikołajewski", "Napastnik", 0 },
                    { 359, 4.5m, 14, "Komar", "Bramkarz", 0 },
                    { 360, 4m, 14, "Perchel", "Bramkarz", 0 },
                    { 361, 6m, 14, "Craciun", "Obrońca", 0 },
                    { 362, 5.5m, 14, "Revenco", "Obrońca", 0 },
                    { 363, 5m, 14, "Yakuba", "Obrońca", 0 },
                    { 364, 5m, 14, "Szymonowicz", "Obrońca", 0 },
                    { 365, 5m, 14, "Siplak", "Obrońca", 0 },
                    { 366, 5m, 14, "Mroziński", "Obrońca", 0 },
                    { 367, 5m, 14, "K.Stępień", "Obrońca", 0 },
                    { 368, 4.5m, 14, "Sołowiej", "Obrońca", 0 },
                    { 369, 3.5m, 14, "Kieliś", "Obrońca", 0 },
                    { 370, 3m, 14, "Gil", "Obrońca", 0 },
                    { 371, 6m, 14, "Lee", "Pomocnik", 0 },
                    { 372, 5.5m, 14, "Blagaic", "Pomocnik", 0 },
                    { 373, 5m, 14, "M.Stępień", "Pomocnik", 0 },
                    { 374, 5m, 14, "Cholewiak", "Pomocnik", 0 },
                    { 375, 5m, 14, "Abramowicz", "Pomocnik", 0 },
                    { 376, 4.5m, 14, "Serafin", "Pomocnik", 0 },
                    { 377, 4.5m, 14, "Radecki", "Pomocnik", 0 },
                    { 378, 4m, 14, "Hajda", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 379, 4m, 14, "Walski", "Pomocnik", 0 },
                    { 380, 4m, 14, "Siemaszko", "Pomocnik", 0 },
                    { 381, 4m, 14, "Tomalski", "Pomocnik", 0 },
                    { 382, 3.5m, 14, "Pieprzyca", "Pomocnik", 0 },
                    { 383, 3.5m, 14, "Kogut", "Pomocnik", 0 },
                    { 384, 7m, 14, "Kosidis", "Napastnik", 0 },
                    { 385, 4.5m, 14, "Kidric", "Napastnik", 0 },
                    { 386, 3.5m, 14, "Okoniewski", "Napastnik", 0 },
                    { 387, 3.5m, 14, "Klisiewicz", "Napastnik", 0 },
                    { 388, 4.5m, 15, "Dziekoński", "Bramkarz", 0 },
                    { 389, 4m, 15, "Mamla", "Bramkarz", 0 },
                    { 390, 3m, 15, "Zapytowski", "Bramkarz", 0 },
                    { 391, 5m, 15, "Resta", "Obrońca", 0 },
                    { 392, 5m, 15, "Zwoźny", "Obrońca", 0 },
                    { 393, 5m, 15, "Matuszewski", "Obrońca", 0 },
                    { 394, 5m, 15, "Zator", "Obrońca", 0 },
                    { 395, 5m, 15, "Błanik", "Obrońca", 0 },
                    { 396, 4.5m, 15, "Pięczek", "Obrońca", 0 },
                    { 397, 4.5m, 15, "Trojak", "Obrońca", 0 },
                    { 398, 3.5m, 15, "Smolarczyk", "Obrońca", 0 },
                    { 399, 3.5m, 15, "Malarczyk", "Obrońca", 0 },
                    { 400, 3.5m, 15, "Kośmicki", "Obrońca", 0 },
                    { 401, 6m, 15, "Nuno", "Pomocnik", 0 },
                    { 402, 5.5m, 15, "Fornalczyk", "Pomocnik", 0 },
                    { 403, 5.5m, 15, "Nono", "Pomocnik", 0 },
                    { 404, 5m, 15, "Hofmayster", "Pomocnik", 0 },
                    { 405, 5m, 15, "Remacle", "Pomocnik", 0 },
                    { 406, 5m, 15, "Długosz", "Pomocnik", 0 },
                    { 407, 5m, 15, "Nagamatsu", "Pomocnik", 0 },
                    { 408, 4.5m, 15, "Trejo", "Pomocnik", 0 },
                    { 409, 4.5m, 15, "Godinho", "Pomocnik", 0 },
                    { 410, 4m, 15, "Kamiński", "Pomocnik", 0 },
                    { 411, 4m, 15, "Strzeboński", "Pomocnik", 0 },
                    { 412, 4m, 15, "Konstantyn", "Pomocnik", 0 },
                    { 413, 3.5m, 15, "Chojecki", "Pomocnik", 0 },
                    { 414, 6.5m, 15, "Dalmau", "Napastnik", 0 },
                    { 415, 6m, 15, "Shikavka", "Napastnik", 0 },
                    { 416, 3.5m, 15, "Bąk", "Napastnik", 0 },
                    { 417, 4m, 16, "Kikolski", "Bramkarz", 0 },
                    { 418, 3.5m, 16, "Koptas", "Bramkarz", 0 },
                    { 419, 5m, 16, "Ouattara", "Obrońca", 0 },
                    { 420, 5m, 16, "Henrique", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 421, 4.5m, 16, "Rossi", "Obrońca", 0 },
                    { 422, 4m, 16, "Mammadov", "Obrońca", 0 },
                    { 423, 4m, 16, "Cichocki", "Obrońca", 0 },
                    { 424, 4m, 16, "Jakubik", "Obrońca", 0 },
                    { 425, 5.5m, 16, "Wolski", "Pomocnik", 0 },
                    { 426, 5.5m, 16, "Grzesik", "Pomocnik", 0 },
                    { 427, 5m, 16, "Alves", "Pomocnik", 0 },
                    { 428, 5m, 16, "Donis", "Pomocnik", 0 },
                    { 429, 4.5m, 16, "Jordao", "Pomocnik", 0 },
                    { 430, 4.5m, 16, "Luizao", "Pomocnik", 0 },
                    { 431, 4.5m, 16, "Vagner", "Pomocnik", 0 },
                    { 432, 4.5m, 16, "Leandro", "Pomocnik", 0 },
                    { 433, 4m, 16, "Kaput", "Pomocnik", 0 },
                    { 434, 3.5m, 16, "Ramos", "Pomocnik", 0 },
                    { 435, 3.5m, 16, "Zimovski", "Pomocnik", 0 },
                    { 436, 3.5m, 16, "Capita", "Pomocnik", 0 },
                    { 437, 3m, 16, "Cielemęcki", "Pomocnik", 0 },
                    { 438, 10.5m, 16, "Rocha", "Napastnik", 0 },
                    { 439, 3.5m, 16, "Sarmiento", "Napastnik", 0 },
                    { 440, 4m, 17, "Sarnavskyi", "Bramkarz", 0 },
                    { 441, 3.5m, 17, "Weirauch", "Bramkarz", 0 },
                    { 442, 4.5m, 17, "Olsson", "Obrońca", 0 },
                    { 443, 4.5m, 17, "Piła", "Obrońca", 0 },
                    { 444, 4.5m, 17, "Pllana", "Obrońca", 0 },
                    { 445, 4m, 17, "Kałahur", "Obrońca", 0 },
                    { 446, 4m, 17, "Chindris", "Obrońca", 0 },
                    { 447, 3.5m, 17, "Gueho", "Obrońca", 0 },
                    { 448, 5.5m, 17, "Mena", "Pomocnik", 0 },
                    { 449, 5.5m, 17, "Khlan", "Pomocnik", 0 },
                    { 450, 5m, 17, "Kapic", "Pomocnik", 0 },
                    { 451, 4.5m, 17, "Zhelizko", "Pomocnik", 0 },
                    { 452, 4.5m, 17, "Tsarenko", "Pomocnik", 0 },
                    { 453, 4.5m, 17, "Neugebauer", "Pomocnik", 0 },
                    { 454, 4m, 17, "Buletsa", "Pomocnik", 0 },
                    { 455, 4m, 17, "D'Arrigo", "Pomocnik", 0 },
                    { 456, 4m, 17, "Wendt", "Pomocnik", 0 },
                    { 457, 4m, 17, "Wójtowicz", "Pomocnik", 0 },
                    { 458, 3m, 17, "Kardas", "Pomocnik", 0 },
                    { 459, 6m, 17, "Viunnyk", "Napastnik", 0 },
                    { 460, 5m, 17, "Bobcek", "Napastnik", 0 },
                    { 461, 4.5m, 17, "Sezonienko", "Napastnik", 0 },
                    { 462, 4m, 18, "Leszczyński", "Bramkarz", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
                    { 463, 3.5m, 18, "Loska", "Bramkarz", 0 },
                    { 464, 4.5m, 18, "Petkov", "Obrońca", 0 },
                    { 465, 4.5m, 18, "Petrov", "Obrońca", 0 },
                    { 466, 4.5m, 18, "Paluszek", "Obrońca", 0 },
                    { 467, 4.5m, 18, "Guercio", "Obrońca", 0 },
                    { 468, 4m, 18, "Bejger", "Obrońca", 0 },
                    { 469, 4m, 18, "Szota", "Obrońca", 0 },
                    { 470, 4m, 18, "Matsenko", "Obrońca", 0 },
                    { 471, 3.5m, 18, "Gerstenstein", "Obrońca", 0 },
                    { 472, 3m, 18, "Bartolewski", "Obrońca", 0 },
                    { 473, 3m, 18, "Kurowski", "Obrońca", 0 },
                    { 474, 5.5m, 18, "Samiec-Talar", "Pomocnik", 0 },
                    { 475, 5.5m, 18, "Schwarz", "Pomocnik", 0 },
                    { 476, 5m, 18, "Żukowski", "Pomocnik", 0 },
                    { 477, 4.5m, 18, "Jasper", "Pomocnik", 0 },
                    { 478, 4.5m, 18, "Cebula", "Pomocnik", 0 },
                    { 479, 4.5m, 18, "Ortiz", "Pomocnik", 0 },
                    { 480, 4m, 18, "Pokorny", "Pomocnik", 0 },
                    { 481, 3.5m, 18, "Baluta", "Pomocnik", 0 },
                    { 482, 3.5m, 18, "Rejczyk", "Pomocnik", 0 },
                    { 483, 3.5m, 18, "Ince", "Pomocnik", 0 },
                    { 484, 3.5m, 18, "Jezierski", "Pomocnik", 0 },
                    { 485, 3m, 18, "Sharabura", "Pomocnik", 0 },
                    { 486, 5.5m, 18, "Musiolik", "Napastnik", 0 },
                    { 487, 3.5m, 18, "Basse", "Napastnik", 0 },
                    { 488, 5m, 18, "Świerczok", "Napastnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "HistoriaCen",
                columns: new[] { "HistoriaCenId", "CenaPrzed", "Kolejka", "ZawodnikId" },
                values: new object[,]
                {
                    { 1, 7m, 19, 1 },
                    { 2, 6m, 19, 2 },
                    { 3, 9m, 19, 3 },
                    { 4, 9m, 20, 14 },
                    { 5, 7m, 19, 1 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 1, 0, 1, 0, 0, 1, 0, 13, 6, 1, 0 },
                    { 2, 2, 1, 0, 0, 0, 0, 14, 0, 2, 0 },
                    { 3, 1, 3, 0, 0, 0, 1, 19, 5, 3, 1 },
                    { 4, 0, 3, 0, 0, 1, 0, 17, 0, 4, 1 },
                    { 5, 1, 1, 0, 1, 0, 1, 7, 5, 5, 1 },
                    { 6, 0, 2, 0, 0, 0, 0, 14, 7, 6, 1 },
                    { 7, 0, 3, 0, 0, 0, 1, 15, 0, 7, 1 },
                    { 8, 1, 2, 0, 0, 0, 0, 24, 10, 8, 0 },
                    { 9, 1, 3, 0, 0, 1, 0, 25, 3, 9, 1 },
                    { 10, 2, 0, 0, 1, 0, 1, 1, 0, 10, 0 },
                    { 11, 0, 1, 0, 0, 1, 0, 5, 0, 11, 1 },
                    { 12, 3, 1, 0, 1, 1, 0, 23, 9, 12, 0 },
                    { 13, 3, 3, 0, 1, 0, 1, 27, 10, 13, 1 },
                    { 14, 0, 1, 0, 0, 1, 1, 6, 8, 14, 0 },
                    { 15, 1, 2, 0, 0, 0, 0, 15, 1, 15, 0 },
                    { 16, 1, 3, 0, 0, 0, 1, 15, 0, 16, 0 },
                    { 17, 0, 1, 0, 0, 1, 0, 8, 0, 17, 1 },
                    { 18, 2, 2, 1, 1, 1, 0, 24, 8, 18, 0 },
                    { 19, 1, 3, 0, 1, 0, 0, 20, 4, 19, 1 },
                    { 20, 3, 0, 1, 1, 1, 1, 10, 9, 20, 1 },
                    { 21, 0, 3, 0, 0, 1, 0, 22, 0, 21, 0 },
                    { 22, 0, 2, 0, 0, 1, 1, 13, 1, 22, 0 },
                    { 23, 3, 2, 0, 1, 1, 0, 28, 4, 23, 1 },
                    { 24, 3, 3, 0, 1, 0, 1, 30, 5, 24, 1 },
                    { 25, 0, 0, 0, 0, 1, 0, 10, 7, 25, 1 },
                    { 26, 2, 3, 0, 1, 0, 1, 25, 5, 26, 0 },
                    { 27, 3, 0, 0, 1, 1, 1, 10, 4, 27, 0 },
                    { 28, 3, 1, 0, 1, 1, 0, 19, 9, 28, 1 },
                    { 29, 0, 3, 0, 1, 0, 0, 12, 0, 29, 0 },
                    { 30, 1, 0, 0, 1, 0, 0, 7, 0, 30, 1 },
                    { 31, 1, 3, 0, 0, 1, 1, 18, 0, 31, 1 },
                    { 32, 0, 0, 0, 1, 0, 1, -2, 7, 32, 1 },
                    { 33, 2, 2, 0, 0, 0, 1, 22, 9, 33, 1 },
                    { 34, 3, 3, 0, 0, 0, 1, 24, 1, 34, 1 },
                    { 35, 3, 1, 0, 1, 1, 1, 25, 8, 35, 1 },
                    { 36, 3, 2, 0, 1, 0, 1, 25, 9, 36, 0 },
                    { 37, 1, 1, 0, 0, 0, 0, 14, 8, 37, 1 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 38, 0, 2, 1, 1, 1, 1, 7, 10, 38, 0 },
                    { 39, 2, 3, 0, 1, 1, 0, 32, 9, 39, 1 },
                    { 40, 3, 0, 0, 0, 1, 1, 17, 6, 40, 0 },
                    { 41, 1, 3, 1, 1, 1, 0, 22, 8, 41, 1 },
                    { 42, 2, 1, 0, 1, 1, 0, 16, 0, 42, 1 },
                    { 43, 2, 0, 0, 0, 1, 1, 14, 0, 43, 0 },
                    { 44, 3, 0, 0, 1, 1, 1, 14, 0, 44, 1 },
                    { 45, 2, 0, 1, 0, 1, 0, 8, 0, 45, 0 },
                    { 46, 1, 3, 0, 1, 0, 1, 14, 0, 46, 0 },
                    { 47, 1, 2, 0, 1, 1, 0, 20, 5, 47, 0 },
                    { 48, 0, 0, 0, 1, 0, 1, -5, 0, 48, 1 },
                    { 49, 0, 0, 0, 1, 0, 1, -2, 5, 49, 1 },
                    { 50, 2, 3, 0, 0, 1, 1, 26, 1, 50, 1 },
                    { 51, 1, 0, 0, 1, 1, 0, 3, 0, 51, 0 },
                    { 52, 1, 1, 0, 1, 0, 1, 7, 5, 52, 0 },
                    { 53, 2, 2, 0, 0, 0, 1, 17, 0, 53, 1 },
                    { 54, 1, 2, 0, 0, 0, 1, 14, 0, 54, 1 },
                    { 55, 1, 1, 0, 0, 1, 1, 15, 3, 55, 1 },
                    { 56, 3, 2, 0, 1, 1, 0, 27, 0, 56, 1 },
                    { 57, 0, 3, 0, 1, 0, 1, 21, 8, 57, 0 },
                    { 58, 2, 1, 0, 1, 0, 1, 7, 0, 58, 1 },
                    { 59, 0, 1, 0, 0, 1, 0, 10, 0, 59, 0 },
                    { 60, 2, 1, 0, 1, 1, 1, 22, 9, 60, 0 },
                    { 61, 1, 0, 0, 1, 0, 0, 7, 3, 61, 1 },
                    { 62, 1, 0, 0, 0, 1, 1, 8, 2, 62, 0 },
                    { 63, 1, 2, 1, 1, 1, 0, 16, 8, 63, 0 },
                    { 64, 1, 1, 0, 0, 0, 0, 8, 4, 64, 0 },
                    { 65, 1, 1, 0, 1, 0, 0, 10, 3, 65, 1 },
                    { 66, 2, 0, 0, 1, 1, 0, 16, 5, 66, 1 },
                    { 67, 1, 0, 0, 1, 1, 0, 11, 5, 67, 0 },
                    { 68, 0, 3, 0, 0, 0, 0, 19, 0, 68, 0 },
                    { 69, 2, 3, 0, 0, 1, 0, 29, 0, 69, 1 },
                    { 70, 2, 1, 0, 0, 1, 0, 18, 0, 70, 1 },
                    { 71, 2, 3, 0, 0, 0, 0, 21, 2, 71, 1 },
                    { 72, 1, 3, 0, 0, 0, 1, 18, 0, 72, 0 },
                    { 73, 2, 2, 0, 1, 1, 0, 22, 0, 73, 0 },
                    { 74, 2, 0, 0, 0, 1, 1, 5, 1, 74, 1 },
                    { 75, 3, 1, 0, 0, 0, 1, 15, 0, 75, 0 },
                    { 76, 3, 0, 0, 0, 0, 0, 14, 0, 76, 0 },
                    { 77, 1, 0, 0, 1, 1, 0, 7, 0, 77, 0 },
                    { 78, 2, 3, 0, 0, 1, 0, 26, 0, 78, 1 },
                    { 79, 3, 0, 0, 0, 0, 1, 15, 0, 79, 1 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 80, 1, 3, 0, 0, 0, 0, 17, 0, 80, 0 },
                    { 81, 1, 1, 0, 0, 0, 0, 5, 0, 81, 1 },
                    { 82, 2, 1, 0, 0, 0, 0, 21, 4, 82, 0 },
                    { 83, 0, 2, 0, 1, 1, 1, 9, 1, 83, 0 },
                    { 84, 1, 3, 0, 1, 0, 0, 21, 3, 84, 0 },
                    { 85, 1, 0, 0, 1, 0, 1, 5, 4, 85, 1 },
                    { 86, 0, 3, 0, 1, 1, 1, 16, 10, 86, 0 },
                    { 87, 3, 3, 0, 1, 1, 1, 23, 0, 87, 0 },
                    { 88, 0, 1, 0, 1, 1, 0, 11, 0, 88, 0 },
                    { 89, 2, 0, 0, 1, 1, 1, 8, 0, 89, 1 },
                    { 90, 3, 0, 0, 0, 1, 1, 19, 4, 90, 0 },
                    { 91, 0, 2, 0, 1, 1, 0, 18, 5, 91, 0 },
                    { 92, 3, 3, 0, 1, 0, 0, 24, 5, 92, 0 },
                    { 93, 2, 0, 1, 1, 1, 1, -1, 0, 93, 1 },
                    { 94, 3, 1, 0, 1, 0, 1, 19, 5, 94, 1 },
                    { 95, 1, 2, 0, 1, 0, 1, 7, 0, 95, 0 },
                    { 96, 3, 2, 0, 1, 1, 0, 25, 0, 96, 1 },
                    { 97, 0, 1, 0, 1, 1, 0, 9, 3, 97, 0 },
                    { 98, 3, 2, 0, 1, 1, 0, 24, 7, 98, 0 },
                    { 99, 3, 1, 0, 0, 1, 1, 18, 0, 99, 1 },
                    { 100, 3, 1, 1, 0, 1, 0, 27, 7, 100, 1 },
                    { 101, 0, 0, 1, 1, 0, 0, -4, 5, 101, 1 },
                    { 102, 3, 3, 0, 0, 0, 0, 25, 0, 102, 1 },
                    { 103, 0, 0, 0, 1, 1, 0, 2, 3, 103, 1 },
                    { 104, 1, 3, 0, 1, 1, 0, 23, 4, 104, 1 },
                    { 105, 0, 2, 0, 1, 1, 0, 14, 0, 105, 0 },
                    { 106, 3, 2, 0, 1, 0, 0, 25, 3, 106, 0 },
                    { 107, 1, 3, 0, 1, 1, 1, 21, 3, 107, 1 },
                    { 108, 2, 2, 0, 0, 1, 1, 19, 0, 108, 1 },
                    { 109, 2, 2, 0, 0, 1, 1, 21, 0, 109, 1 },
                    { 110, 3, 2, 0, 0, 1, 0, 31, 8, 110, 1 },
                    { 111, 0, 2, 0, 0, 0, 1, 10, 0, 111, 1 },
                    { 112, 1, 3, 0, 1, 0, 0, 19, 0, 112, 0 },
                    { 113, 1, 0, 0, 0, 0, 1, 3, 0, 113, 0 },
                    { 114, 1, 1, 0, 1, 0, 0, 13, 0, 114, 1 },
                    { 115, 0, 2, 0, 1, 1, 0, 14, 4, 115, 0 },
                    { 116, 3, 2, 1, 0, 0, 0, 16, 0, 116, 1 },
                    { 117, 3, 1, 0, 1, 1, 0, 26, 8, 117, 1 },
                    { 118, 0, 1, 0, 1, 1, 1, 3, 1, 118, 1 },
                    { 119, 3, 3, 0, 0, 0, 1, 27, 0, 119, 1 },
                    { 120, 0, 1, 0, 1, 1, 0, 7, 0, 120, 1 },
                    { 121, 2, 2, 0, 0, 1, 1, 23, 5, 121, 0 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 122, 2, 3, 0, 0, 0, 1, 28, 6, 122, 0 },
                    { 123, 0, 1, 0, 1, 1, 1, 7, 7, 123, 1 },
                    { 124, 3, 3, 0, 1, 0, 0, 35, 4, 124, 0 },
                    { 125, 0, 3, 0, 0, 0, 1, 17, 9, 125, 0 },
                    { 126, 3, 0, 0, 1, 0, 1, 5, 0, 126, 0 },
                    { 127, 3, 3, 0, 0, 0, 1, 29, 0, 127, 0 },
                    { 128, 1, 3, 0, 0, 0, 0, 25, 7, 128, 1 },
                    { 129, 3, 1, 0, 1, 1, 0, 20, 0, 129, 0 },
                    { 130, 2, 3, 0, 1, 0, 1, 20, 0, 130, 1 },
                    { 131, 2, 1, 0, 1, 0, 0, 11, 0, 131, 1 },
                    { 132, 1, 2, 0, 1, 1, 1, 14, 2, 132, 1 },
                    { 133, 3, 3, 0, 0, 1, 1, 31, 0, 133, 0 },
                    { 134, 2, 3, 0, 0, 1, 1, 25, 0, 134, 1 },
                    { 135, 1, 2, 0, 0, 1, 1, 13, 6, 135, 1 },
                    { 136, 0, 1, 0, 0, 0, 1, 6, 9, 136, 1 },
                    { 137, 2, 1, 0, 1, 1, 1, 14, 0, 137, 0 },
                    { 138, 2, 1, 0, 0, 1, 0, 23, 8, 138, 1 },
                    { 139, 2, 2, 0, 1, 1, 0, 21, 5, 139, 0 },
                    { 140, 1, 2, 0, 0, 1, 1, 15, 0, 140, 1 },
                    { 141, 2, 0, 0, 1, 1, 0, 15, 8, 141, 0 },
                    { 142, 1, 0, 0, 1, 1, 1, 2, 0, 142, 1 },
                    { 143, 1, 1, 0, 0, 1, 1, 9, 2, 143, 0 },
                    { 144, 2, 0, 0, 0, 0, 1, 7, 5, 144, 1 },
                    { 145, 2, 0, 0, 0, 0, 1, 11, 0, 145, 1 },
                    { 146, 3, 0, 0, 1, 1, 0, 15, 0, 146, 0 },
                    { 147, 1, 0, 0, 0, 0, 0, 2, 0, 147, 1 },
                    { 148, 3, 1, 0, 1, 0, 0, 16, 1, 148, 0 },
                    { 149, 3, 0, 0, 0, 0, 0, 16, 6, 149, 1 },
                    { 150, 3, 2, 0, 0, 1, 1, 24, 0, 150, 1 },
                    { 151, 1, 1, 0, 1, 0, 1, 6, 9, 151, 1 },
                    { 152, 1, 2, 0, 1, 1, 0, 15, 4, 152, 1 },
                    { 153, 1, 1, 0, 0, 1, 0, 14, 0, 153, 0 },
                    { 154, 1, 3, 0, 1, 0, 1, 19, 0, 154, 0 },
                    { 155, 1, 2, 0, 1, 1, 1, 18, 7, 155, 0 },
                    { 156, 0, 2, 0, 1, 0, 0, 11, 2, 156, 0 },
                    { 157, 3, 3, 0, 1, 0, 0, 28, 0, 157, 1 },
                    { 158, 0, 2, 0, 0, 1, 1, 11, 0, 158, 1 },
                    { 159, 2, 0, 0, 1, 1, 0, 8, 0, 159, 0 },
                    { 160, 2, 0, 0, 1, 1, 0, 14, 9, 160, 1 },
                    { 161, 1, 2, 0, 0, 1, 0, 16, 0, 161, 0 },
                    { 162, 1, 0, 1, 1, 1, 0, 3, 0, 162, 0 },
                    { 163, 3, 2, 0, 1, 0, 1, 25, 10, 163, 0 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 164, 0, 1, 0, 0, 0, 1, -1, 0, 164, 1 },
                    { 165, 3, 0, 0, 0, 0, 0, 12, 3, 165, 0 },
                    { 166, 1, 0, 0, 0, 1, 1, 2, 0, 166, 1 },
                    { 167, 0, 1, 1, 1, 0, 1, -4, 0, 167, 1 },
                    { 168, 0, 3, 0, 1, 0, 1, 13, 0, 168, 1 },
                    { 169, 1, 3, 0, 0, 0, 1, 18, 0, 169, 0 },
                    { 170, 3, 3, 0, 0, 0, 0, 30, 0, 170, 1 },
                    { 171, 0, 2, 0, 1, 1, 0, 9, 0, 171, 1 },
                    { 172, 1, 2, 0, 1, 1, 0, 23, 5, 172, 0 },
                    { 173, 0, 3, 0, 0, 1, 0, 19, 0, 173, 0 },
                    { 174, 0, 2, 0, 1, 0, 0, 15, 6, 174, 1 },
                    { 175, 2, 3, 0, 1, 0, 1, 18, 0, 175, 1 },
                    { 176, 0, 0, 0, 0, 0, 0, 10, 4, 176, 1 },
                    { 177, 1, 1, 0, 1, 0, 1, 12, 9, 177, 0 },
                    { 178, 3, 3, 0, 0, 1, 1, 35, 10, 178, 1 },
                    { 179, 2, 2, 0, 1, 1, 0, 23, 4, 179, 1 },
                    { 180, 0, 1, 0, 1, 0, 0, 4, 0, 180, 0 },
                    { 181, 1, 3, 0, 0, 1, 0, 23, 4, 181, 1 },
                    { 182, 3, 1, 0, 0, 1, 1, 24, 0, 182, 0 },
                    { 183, 2, 0, 1, 0, 0, 1, 4, 0, 183, 1 },
                    { 184, 2, 0, 0, 0, 1, 0, 14, 0, 184, 1 },
                    { 185, 0, 2, 0, 1, 0, 0, 12, 5, 185, 1 },
                    { 186, 2, 1, 0, 0, 0, 0, 10, 0, 186, 0 },
                    { 187, 2, 3, 0, 1, 0, 0, 28, 6, 187, 1 },
                    { 188, 2, 2, 0, 1, 1, 0, 18, 0, 188, 1 },
                    { 189, 2, 3, 0, 1, 1, 0, 27, 10, 189, 0 },
                    { 190, 0, 0, 0, 1, 1, 1, 2, 0, 190, 0 },
                    { 191, 1, 2, 0, 0, 1, 1, 16, 0, 191, 1 },
                    { 192, 2, 1, 0, 1, 0, 0, 13, 9, 192, 0 },
                    { 193, 3, 2, 0, 0, 1, 1, 23, 0, 193, 0 },
                    { 194, 1, 3, 0, 1, 0, 0, 18, 0, 194, 0 },
                    { 195, 0, 2, 0, 0, 1, 1, 15, 2, 195, 1 },
                    { 196, 2, 0, 0, 1, 1, 1, 9, 1, 196, 0 },
                    { 197, 3, 2, 0, 0, 0, 0, 25, 0, 197, 1 },
                    { 198, 0, 3, 0, 0, 0, 0, 16, 0, 198, 0 },
                    { 199, 3, 0, 0, 1, 0, 0, 9, 0, 199, 0 },
                    { 200, 2, 3, 0, 0, 1, 1, 22, 4, 200, 1 },
                    { 201, 3, 1, 0, 0, 0, 0, 17, 0, 201, 1 },
                    { 202, 0, 0, 0, 1, 1, 1, 3, 8, 202, 0 },
                    { 203, 1, 0, 1, 0, 1, 1, 3, 0, 203, 0 },
                    { 204, 1, 1, 0, 1, 1, 0, 11, 0, 204, 1 },
                    { 205, 3, 0, 0, 0, 1, 1, 20, 0, 205, 0 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 206, 1, 0, 0, 0, 1, 0, 11, 0, 206, 1 },
                    { 207, 3, 0, 0, 1, 1, 1, 10, 6, 207, 0 },
                    { 208, 2, 1, 0, 0, 0, 0, 16, 4, 208, 0 },
                    { 209, 1, 1, 0, 1, 0, 0, 9, 0, 209, 0 },
                    { 210, 1, 3, 0, 1, 1, 1, 19, 0, 210, 0 },
                    { 211, 3, 2, 0, 1, 0, 1, 23, 0, 211, 1 },
                    { 212, 2, 3, 0, 1, 0, 0, 25, 0, 212, 0 },
                    { 213, 0, 2, 0, 0, 1, 0, 16, 7, 213, 0 },
                    { 214, 2, 1, 0, 0, 0, 0, 12, 0, 214, 1 },
                    { 215, 0, 0, 0, 1, 1, 1, 4, 5, 215, 0 },
                    { 216, 1, 1, 0, 0, 1, 0, 9, 0, 216, 0 },
                    { 217, 1, 2, 0, 1, 1, 1, 12, 0, 217, 1 },
                    { 218, 0, 3, 0, 1, 1, 0, 20, 3, 218, 1 },
                    { 219, 1, 3, 0, 0, 0, 0, 24, 0, 219, 0 },
                    { 220, 0, 1, 0, 0, 1, 0, 5, 0, 220, 0 },
                    { 221, 0, 3, 0, 1, 1, 1, 16, 9, 221, 0 },
                    { 222, 3, 2, 0, 1, 1, 0, 27, 10, 222, 0 },
                    { 223, 2, 2, 0, 1, 1, 0, 18, 4, 223, 1 },
                    { 224, 1, 3, 0, 0, 1, 1, 23, 0, 224, 0 },
                    { 225, 2, 0, 0, 1, 0, 1, 2, 0, 225, 1 },
                    { 226, 1, 3, 0, 0, 1, 0, 30, 7, 226, 0 },
                    { 227, 2, 3, 0, 1, 1, 0, 28, 1, 227, 0 },
                    { 228, 0, 3, 0, 1, 1, 1, 12, 3, 228, 1 },
                    { 229, 0, 2, 0, 0, 1, 1, 12, 1, 229, 0 },
                    { 230, 1, 3, 0, 1, 1, 0, 21, 0, 230, 0 },
                    { 231, 1, 1, 0, 0, 1, 1, 13, 6, 231, 0 },
                    { 232, 3, 0, 1, 0, 0, 0, 19, 6, 232, 0 },
                    { 233, 0, 3, 0, 0, 0, 0, 15, 1, 233, 1 },
                    { 234, 1, 1, 0, 0, 1, 1, 5, 0, 234, 1 },
                    { 235, 0, 3, 0, 0, 1, 0, 19, 0, 235, 0 },
                    { 236, 1, 3, 0, 1, 1, 0, 23, 0, 236, 0 },
                    { 237, 1, 3, 0, 1, 0, 0, 16, 0, 237, 0 },
                    { 238, 0, 2, 0, 1, 1, 0, 14, 0, 238, 1 },
                    { 239, 0, 1, 0, 0, 0, 0, 7, 0, 239, 1 },
                    { 240, 3, 3, 0, 1, 0, 1, 32, 9, 240, 1 },
                    { 241, 1, 2, 0, 1, 0, 0, 18, 2, 241, 1 },
                    { 242, 2, 0, 0, 1, 1, 1, 11, 0, 242, 1 },
                    { 243, 3, 0, 0, 0, 0, 1, 12, 7, 243, 1 },
                    { 244, 2, 1, 0, 0, 1, 1, 15, 0, 244, 1 },
                    { 245, 3, 3, 0, 1, 1, 1, 24, 0, 245, 0 },
                    { 246, 2, 0, 0, 1, 1, 0, 12, 0, 246, 0 },
                    { 247, 0, 2, 0, 0, 1, 0, 11, 0, 247, 0 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 248, 1, 1, 0, 1, 0, 0, 3, 0, 248, 1 },
                    { 249, 1, 1, 0, 0, 1, 1, 10, 0, 249, 1 },
                    { 250, 2, 2, 0, 1, 0, 0, 19, 0, 250, 1 },
                    { 251, 1, 1, 0, 0, 1, 0, 14, 0, 251, 0 },
                    { 252, 1, 3, 0, 0, 1, 0, 29, 2, 252, 1 },
                    { 253, 2, 3, 0, 0, 1, 0, 27, 2, 253, 1 },
                    { 254, 2, 1, 0, 0, 1, 1, 12, 1, 254, 0 },
                    { 255, 2, 1, 0, 0, 0, 0, 14, 0, 255, 1 },
                    { 256, 1, 1, 0, 0, 0, 1, 7, 0, 256, 1 },
                    { 257, 0, 0, 0, 1, 0, 0, -4, 0, 257, 0 },
                    { 258, 2, 2, 0, 0, 0, 1, 15, 0, 258, 1 },
                    { 259, 2, 1, 0, 1, 0, 0, 14, 3, 259, 1 },
                    { 260, 0, 2, 0, 1, 0, 0, 12, 0, 260, 0 },
                    { 261, 1, 3, 0, 0, 0, 0, 19, 1, 261, 1 },
                    { 262, 0, 1, 0, 0, 0, 1, 5, 5, 262, 1 },
                    { 263, 3, 2, 1, 0, 0, 1, 14, 0, 263, 0 },
                    { 264, 0, 2, 0, 1, 0, 0, 11, 0, 264, 0 },
                    { 265, 0, 1, 0, 0, 0, 1, -1, 0, 265, 0 },
                    { 266, 0, 2, 0, 1, 1, 0, 15, 0, 266, 0 },
                    { 267, 1, 3, 1, 1, 1, 0, 18, 1, 267, 1 },
                    { 268, 0, 2, 0, 1, 1, 0, 17, 9, 268, 0 },
                    { 269, 3, 2, 0, 0, 1, 1, 26, 0, 269, 0 },
                    { 270, 1, 2, 0, 1, 0, 1, 12, 0, 270, 0 },
                    { 271, 2, 3, 0, 1, 0, 0, 28, 8, 271, 1 },
                    { 272, 3, 2, 0, 0, 0, 0, 26, 0, 272, 0 },
                    { 273, 1, 0, 0, 0, 0, 0, 8, 7, 273, 0 },
                    { 274, 1, 2, 0, 0, 1, 1, 17, 0, 274, 0 },
                    { 275, 1, 3, 0, 0, 1, 0, 22, 0, 275, 0 },
                    { 276, 1, 0, 0, 1, 0, 0, 2, 0, 276, 1 },
                    { 277, 3, 1, 0, 0, 0, 0, 24, 2, 277, 1 },
                    { 278, 0, 3, 0, 1, 1, 0, 19, 1, 278, 1 },
                    { 279, 2, 3, 0, 1, 0, 0, 21, 4, 279, 1 },
                    { 280, 2, 2, 0, 1, 1, 0, 21, 0, 280, 1 },
                    { 281, 1, 0, 0, 0, 0, 1, 0, 0, 281, 1 },
                    { 282, 0, 3, 0, 0, 1, 1, 19, 4, 282, 0 },
                    { 283, 0, 3, 0, 1, 0, 0, 17, 6, 283, 0 },
                    { 284, 1, 1, 0, 0, 0, 0, 11, 0, 284, 0 },
                    { 285, 3, 0, 0, 1, 1, 0, 14, 0, 285, 0 },
                    { 286, 1, 2, 0, 0, 0, 0, 17, 0, 286, 0 },
                    { 287, 3, 3, 0, 1, 0, 0, 29, 0, 287, 0 },
                    { 288, 0, 3, 0, 1, 1, 0, 19, 0, 288, 1 },
                    { 289, 1, 1, 0, 1, 1, 0, 11, 0, 289, 1 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 290, 1, 1, 0, 1, 0, 0, 12, 6, 290, 0 },
                    { 291, 3, 3, 0, 0, 0, 1, 31, 7, 291, 1 },
                    { 292, 1, 1, 0, 0, 0, 0, 11, 0, 292, 0 },
                    { 293, 0, 0, 0, 0, 0, 1, -5, 0, 293, 0 },
                    { 294, 0, 3, 0, 0, 0, 1, 11, 0, 294, 1 },
                    { 295, 3, 3, 0, 1, 0, 0, 29, 0, 295, 1 },
                    { 296, 1, 2, 0, 1, 1, 0, 15, 0, 296, 0 },
                    { 297, 2, 1, 0, 0, 0, 0, 17, 0, 297, 0 },
                    { 298, 0, 1, 1, 1, 1, 1, 0, 0, 298, 0 },
                    { 299, 2, 3, 0, 1, 1, 1, 25, 0, 299, 0 },
                    { 300, 2, 3, 0, 0, 0, 1, 24, 6, 300, 0 },
                    { 301, 3, 2, 0, 0, 1, 0, 24, 0, 301, 1 },
                    { 302, 3, 0, 0, 1, 0, 1, 8, 0, 302, 0 },
                    { 303, 1, 1, 0, 1, 0, 0, 8, 0, 303, 1 },
                    { 304, 2, 1, 0, 0, 0, 1, 11, 1, 304, 1 },
                    { 305, 0, 3, 0, 0, 1, 0, 19, 0, 305, 1 },
                    { 306, 2, 1, 0, 1, 0, 1, 6, 1, 306, 1 },
                    { 307, 0, 1, 0, 1, 1, 0, 6, 0, 307, 1 },
                    { 308, 3, 0, 0, 0, 1, 1, 12, 0, 308, 1 },
                    { 309, 3, 3, 0, 1, 1, 0, 34, 3, 309, 0 },
                    { 310, 2, 1, 0, 0, 0, 0, 22, 5, 310, 0 },
                    { 311, 0, 2, 0, 0, 1, 0, 16, 0, 311, 0 },
                    { 312, 0, 1, 0, 1, 0, 0, 5, 2, 312, 0 },
                    { 313, 0, 0, 1, 0, 0, 1, -1, 1, 313, 0 },
                    { 314, 3, 2, 0, 1, 0, 1, 20, 1, 314, 1 },
                    { 315, 0, 2, 0, 0, 1, 0, 12, 0, 315, 0 },
                    { 316, 2, 0, 0, 1, 1, 1, 8, 0, 316, 1 },
                    { 317, 2, 3, 0, 1, 1, 1, 25, 0, 317, 0 },
                    { 318, 3, 1, 0, 1, 0, 1, 14, 0, 318, 0 },
                    { 319, 1, 2, 0, 1, 0, 0, 13, 0, 319, 1 },
                    { 320, 1, 3, 0, 1, 1, 1, 14, 0, 320, 0 },
                    { 321, 2, 3, 0, 1, 1, 1, 30, 7, 321, 0 },
                    { 322, 1, 3, 0, 1, 0, 1, 23, 10, 322, 0 },
                    { 323, 3, 3, 0, 1, 0, 1, 31, 0, 323, 0 },
                    { 324, 2, 2, 0, 1, 1, 0, 19, 0, 324, 1 },
                    { 325, 2, 1, 0, 1, 1, 1, 16, 0, 325, 1 },
                    { 326, 3, 1, 0, 1, 1, 1, 19, 6, 326, 1 },
                    { 327, 3, 3, 0, 1, 1, 1, 28, 0, 327, 1 },
                    { 328, 2, 2, 0, 0, 0, 1, 22, 2, 328, 1 },
                    { 329, 3, 1, 0, 0, 1, 0, 27, 3, 329, 1 },
                    { 330, 2, 2, 0, 0, 0, 0, 15, 0, 330, 1 },
                    { 331, 1, 2, 0, 0, 1, 1, 16, 4, 331, 1 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 332, 0, 0, 0, 0, 0, 0, 1, 1, 332, 0 },
                    { 333, 0, 3, 0, 0, 1, 1, 24, 6, 333, 0 },
                    { 334, 3, 0, 0, 1, 1, 1, 12, 0, 334, 0 },
                    { 335, 0, 2, 0, 0, 0, 1, 11, 3, 335, 0 },
                    { 336, 2, 1, 0, 0, 1, 1, 15, 3, 336, 1 },
                    { 337, 2, 2, 0, 0, 1, 0, 25, 0, 337, 1 },
                    { 338, 0, 2, 0, 1, 1, 1, 12, 6, 338, 0 },
                    { 339, 1, 3, 0, 1, 1, 0, 19, 1, 339, 0 },
                    { 340, 3, 1, 0, 1, 0, 1, 13, 2, 340, 1 },
                    { 341, 1, 1, 0, 0, 1, 0, 12, 0, 341, 1 },
                    { 342, 1, 3, 0, 0, 0, 1, 12, 0, 342, 1 },
                    { 343, 3, 2, 0, 1, 0, 1, 23, 0, 343, 0 },
                    { 344, 1, 1, 0, 0, 1, 1, 13, 6, 344, 0 },
                    { 345, 2, 3, 0, 0, 0, 0, 26, 0, 345, 0 },
                    { 346, 1, 3, 0, 1, 0, 1, 18, 0, 346, 1 },
                    { 347, 1, 2, 0, 0, 0, 1, 13, 0, 347, 0 },
                    { 348, 0, 3, 0, 0, 1, 1, 16, 0, 348, 0 },
                    { 349, 3, 3, 0, 1, 1, 1, 32, 7, 349, 1 },
                    { 350, 2, 1, 0, 0, 1, 0, 16, 0, 350, 0 },
                    { 351, 2, 0, 0, 1, 0, 1, 9, 4, 351, 0 },
                    { 352, 0, 2, 0, 0, 1, 1, 10, 0, 352, 1 },
                    { 353, 3, 1, 0, 1, 1, 1, 17, 0, 353, 1 },
                    { 354, 0, 1, 0, 0, 1, 1, 5, 3, 354, 0 },
                    { 355, 3, 1, 0, 1, 0, 1, 14, 0, 355, 1 },
                    { 356, 2, 2, 0, 1, 1, 1, 18, 0, 356, 1 },
                    { 357, 2, 1, 0, 1, 1, 0, 19, 0, 357, 1 },
                    { 358, 1, 3, 0, 0, 1, 1, 23, 0, 358, 0 },
                    { 359, 0, 1, 0, 0, 1, 1, 11, 2, 359, 1 },
                    { 360, 1, 1, 0, 1, 1, 0, 14, 4, 360, 0 },
                    { 361, 3, 1, 0, 0, 0, 1, 16, 0, 361, 1 },
                    { 362, 1, 1, 0, 1, 1, 1, 10, 0, 362, 0 },
                    { 363, 0, 1, 0, 0, 0, 0, 6, 2, 363, 1 },
                    { 364, 0, 2, 0, 0, 1, 1, 13, 8, 364, 0 },
                    { 365, 3, 1, 0, 1, 0, 1, 20, 8, 365, 0 },
                    { 366, 3, 0, 1, 0, 1, 0, 11, 0, 366, 0 },
                    { 367, 3, 1, 0, 1, 1, 1, 21, 10, 367, 1 },
                    { 368, 3, 0, 0, 0, 0, 1, 19, 9, 368, 1 },
                    { 369, 1, 3, 0, 1, 0, 1, 17, 0, 369, 1 },
                    { 370, 3, 2, 0, 1, 0, 1, 20, 0, 370, 0 },
                    { 371, 2, 0, 0, 0, 0, 0, 16, 9, 371, 0 },
                    { 372, 3, 1, 0, 1, 1, 0, 23, 0, 372, 0 },
                    { 373, 1, 3, 0, 1, 1, 1, 21, 1, 373, 0 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 374, 2, 3, 0, 1, 1, 1, 17, 0, 374, 1 },
                    { 375, 2, 1, 0, 1, 1, 0, 12, 0, 375, 1 },
                    { 376, 0, 2, 0, 0, 0, 1, 9, 3, 376, 0 },
                    { 377, 0, 0, 0, 0, 1, 0, 5, 3, 377, 0 },
                    { 378, 3, 1, 0, 0, 1, 1, 23, 6, 378, 1 },
                    { 379, 3, 3, 0, 0, 1, 0, 26, 0, 379, 1 },
                    { 380, 3, 0, 0, 0, 0, 1, 10, 8, 380, 1 },
                    { 381, 2, 3, 0, 0, 0, 0, 28, 0, 381, 0 },
                    { 382, 0, 0, 0, 0, 0, 1, -3, 0, 382, 1 },
                    { 383, 1, 3, 0, 1, 1, 1, 24, 6, 383, 1 },
                    { 384, 1, 0, 0, 0, 1, 1, 5, 0, 384, 1 },
                    { 385, 3, 0, 0, 0, 0, 0, 11, 0, 385, 1 },
                    { 386, 2, 0, 0, 0, 0, 0, 4, 0, 386, 1 },
                    { 387, 2, 2, 0, 1, 1, 0, 27, 10, 387, 0 },
                    { 388, 0, 1, 0, 1, 0, 1, 3, 1, 388, 0 },
                    { 389, 2, 2, 0, 0, 0, 1, 24, 4, 389, 0 },
                    { 390, 3, 2, 0, 1, 0, 1, 22, 7, 390, 1 },
                    { 391, 1, 3, 0, 0, 0, 1, 18, 0, 391, 0 },
                    { 392, 1, 3, 0, 0, 1, 1, 23, 0, 392, 0 },
                    { 393, 3, 3, 0, 1, 0, 0, 30, 4, 393, 1 },
                    { 394, 0, 1, 0, 1, 1, 1, 5, 0, 394, 0 },
                    { 395, 1, 3, 0, 0, 1, 1, 26, 0, 395, 0 },
                    { 396, 2, 1, 0, 1, 0, 1, 10, 0, 396, 1 },
                    { 397, 3, 1, 0, 0, 0, 1, 19, 0, 397, 0 },
                    { 398, 1, 3, 0, 0, 1, 1, 28, 9, 398, 0 },
                    { 399, 0, 0, 0, 0, 0, 0, -2, 0, 399, 0 },
                    { 400, 1, 3, 0, 0, 0, 1, 19, 0, 400, 0 },
                    { 401, 0, 1, 0, 0, 1, 0, 11, 0, 401, 0 },
                    { 402, 3, 1, 0, 0, 1, 0, 21, 0, 402, 1 },
                    { 403, 3, 3, 0, 0, 1, 0, 40, 0, 403, 0 },
                    { 404, 2, 2, 0, 1, 1, 1, 19, 0, 404, 0 },
                    { 405, 0, 0, 0, 0, 1, 1, -4, 0, 405, 1 },
                    { 406, 3, 0, 0, 1, 1, 0, 10, 0, 406, 1 },
                    { 407, 2, 3, 0, 0, 1, 1, 27, 0, 407, 0 },
                    { 408, 3, 0, 0, 1, 0, 1, 4, 0, 408, 0 },
                    { 409, 2, 3, 0, 1, 1, 0, 28, 0, 409, 0 },
                    { 410, 1, 0, 0, 1, 1, 1, 11, 9, 410, 0 },
                    { 411, 1, 1, 0, 1, 0, 0, 12, 6, 411, 0 },
                    { 412, 3, 1, 0, 0, 1, 0, 21, 0, 412, 1 },
                    { 413, 0, 1, 0, 1, 0, 0, 5, 0, 413, 0 },
                    { 414, 3, 2, 0, 0, 1, 0, 30, 9, 414, 0 },
                    { 415, 0, 3, 0, 0, 0, 1, 13, 1, 415, 1 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 416, 3, 2, 0, 0, 0, 1, 20, 3, 416, 0 },
                    { 417, 3, 0, 0, 1, 1, 0, 15, 0, 417, 0 },
                    { 418, 3, 0, 0, 0, 1, 0, 15, 0, 418, 1 },
                    { 419, 3, 3, 0, 0, 0, 1, 28, 0, 419, 1 },
                    { 420, 1, 0, 0, 0, 0, 0, 2, 3, 420, 1 },
                    { 421, 3, 0, 0, 1, 0, 1, 8, 0, 421, 0 },
                    { 422, 2, 2, 0, 0, 1, 1, 16, 0, 422, 1 },
                    { 423, 2, 2, 0, 1, 1, 1, 17, 1, 423, 0 },
                    { 424, 3, 0, 0, 0, 1, 0, 20, 2, 424, 0 },
                    { 425, 2, 2, 1, 0, 1, 0, 18, 0, 425, 1 },
                    { 426, 2, 2, 0, 1, 0, 0, 23, 9, 426, 0 },
                    { 427, 0, 1, 0, 1, 1, 0, 7, 0, 427, 0 },
                    { 428, 0, 1, 0, 0, 0, 0, 4, 0, 428, 0 },
                    { 429, 1, 2, 0, 1, 0, 1, 10, 0, 429, 0 },
                    { 430, 2, 3, 0, 1, 1, 1, 21, 0, 430, 1 },
                    { 431, 3, 0, 0, 1, 0, 0, 9, 5, 431, 1 },
                    { 432, 3, 1, 0, 0, 0, 0, 16, 3, 432, 0 },
                    { 433, 3, 2, 0, 0, 0, 1, 23, 8, 433, 0 },
                    { 434, 0, 3, 0, 0, 1, 0, 21, 5, 434, 0 },
                    { 435, 1, 0, 0, 0, 1, 1, 4, 0, 435, 1 },
                    { 436, 3, 3, 0, 0, 0, 0, 28, 5, 436, 0 },
                    { 437, 3, 3, 1, 0, 0, 1, 24, 0, 437, 1 },
                    { 438, 0, 3, 0, 0, 0, 0, 13, 0, 438, 1 },
                    { 439, 3, 0, 0, 0, 1, 1, 14, 2, 439, 1 },
                    { 440, 1, 1, 0, 0, 0, 1, 8, 5, 440, 1 },
                    { 441, 0, 2, 0, 1, 0, 0, 9, 0, 441, 1 },
                    { 442, 2, 3, 1, 1, 0, 1, 20, 6, 442, 1 },
                    { 443, 2, 3, 0, 0, 1, 0, 25, 0, 443, 1 },
                    { 444, 3, 2, 0, 1, 1, 1, 25, 3, 444, 0 },
                    { 445, 2, 0, 1, 0, 1, 1, 2, 0, 445, 1 },
                    { 446, 3, 0, 0, 1, 0, 1, 12, 0, 446, 0 },
                    { 447, 0, 3, 0, 0, 0, 1, 12, 6, 447, 0 },
                    { 448, 0, 0, 1, 1, 0, 1, -5, 0, 448, 0 },
                    { 449, 0, 3, 0, 1, 1, 1, 10, 0, 449, 1 },
                    { 450, 0, 0, 0, 0, 0, 1, -1, 0, 450, 0 },
                    { 451, 2, 0, 0, 1, 0, 1, 6, 1, 451, 0 },
                    { 452, 1, 1, 0, 1, 1, 1, 13, 10, 452, 1 },
                    { 453, 0, 1, 0, 0, 0, 1, 3, 0, 453, 0 },
                    { 454, 0, 1, 1, 1, 1, 0, 11, 3, 454, 0 },
                    { 455, 2, 1, 0, 0, 0, 1, 8, 5, 455, 1 },
                    { 456, 1, 3, 0, 1, 1, 1, 19, 0, 456, 1 },
                    { 457, 1, 3, 0, 1, 1, 0, 19, 0, 457, 0 }
                });

            migrationBuilder.InsertData(
                table: "StatystykiZawodnikow",
                columns: new[] { "StatystykiZawodnikowId", "Asysty", "Bramki", "CzerwoneKartki", "KarneSpowodowane", "KarneWywalczone", "KarneZmarnowane", "Punkty", "StrzalyObronione", "ZawodnikId", "ZolteKartki" },
                values: new object[,]
                {
                    { 458, 2, 2, 0, 0, 0, 0, 25, 10, 458, 1 },
                    { 459, 1, 0, 0, 0, 0, 0, 4, 8, 459, 1 },
                    { 460, 1, 2, 0, 0, 0, 0, 13, 3, 460, 0 },
                    { 461, 3, 1, 0, 0, 1, 0, 20, 0, 461, 1 },
                    { 462, 3, 2, 0, 0, 1, 0, 28, 0, 462, 0 },
                    { 463, 2, 2, 0, 1, 0, 0, 20, 8, 463, 1 },
                    { 464, 1, 2, 0, 0, 1, 1, 17, 0, 464, 1 },
                    { 465, 0, 2, 0, 0, 1, 1, 13, 0, 465, 0 },
                    { 466, 0, 0, 1, 1, 1, 1, 2, 2, 466, 0 },
                    { 467, 2, 3, 0, 0, 1, 0, 30, 4, 467, 0 },
                    { 468, 3, 2, 0, 0, 0, 1, 26, 0, 468, 1 },
                    { 469, 1, 0, 0, 0, 1, 1, 3, 0, 469, 0 },
                    { 470, 3, 2, 0, 0, 0, 1, 21, 0, 470, 0 },
                    { 471, 1, 3, 0, 1, 1, 0, 26, 6, 471, 1 },
                    { 472, 3, 1, 0, 0, 1, 1, 19, 3, 472, 0 },
                    { 473, 3, 3, 0, 1, 1, 0, 31, 0, 473, 0 },
                    { 474, 3, 0, 0, 1, 0, 0, 13, 6, 474, 1 },
                    { 475, 2, 3, 0, 0, 1, 0, 38, 2, 475, 0 },
                    { 476, 2, 3, 0, 0, 1, 0, 32, 8, 476, 1 },
                    { 477, 0, 2, 0, 1, 1, 1, 9, 0, 477, 0 },
                    { 478, 1, 0, 0, 0, 0, 1, 6, 5, 478, 0 },
                    { 479, 2, 0, 0, 0, 0, 1, 7, 4, 479, 1 },
                    { 480, 3, 0, 0, 0, 0, 0, 22, 8, 480, 0 },
                    { 481, 0, 2, 0, 0, 0, 0, 13, 0, 481, 0 },
                    { 482, 1, 3, 0, 0, 0, 1, 20, 0, 482, 1 },
                    { 483, 3, 3, 0, 0, 0, 0, 31, 0, 483, 1 },
                    { 484, 2, 3, 0, 0, 1, 1, 30, 4, 484, 0 },
                    { 485, 3, 1, 0, 1, 1, 0, 24, 4, 485, 1 },
                    { 486, 0, 2, 0, 0, 0, 0, 13, 4, 486, 0 },
                    { 487, 0, 2, 0, 1, 1, 0, 15, 0, 487, 0 },
                    { 488, 1, 2, 0, 1, 0, 0, 15, 0, 488, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Druzyny_UzytkownikId",
                table: "Druzyny",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaCen_ZawodnikId",
                table: "HistoriaCen",
                column: "ZawodnikId");

            migrationBuilder.CreateIndex(
                name: "IX_SkladDruzyny_ZawodnikId",
                table: "SkladDruzyny",
                column: "ZawodnikId");

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
                name: "HistoriaCen");

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
