using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imie",
                table: "Zawodnicy");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 1,
                column: "Nazwa",
                value: "Lech Poznań");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 2,
                column: "Nazwa",
                value: "Raków Częstochowa");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 3,
                column: "Nazwa",
                value: "Jagiellonia Białystok");

            migrationBuilder.InsertData(
                table: "Kluby",
                columns: new[] { "KlubId", "Nazwa" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 1,
                columns: new[] { "Cena", "Nazwisko", "Punkty" },
                values: new object[] { 6.5m, "Mrozek", 0 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 2,
                columns: new[] { "Cena", "KlubId", "Nazwisko", "Punkty" },
                values: new object[] { 5m, 1, "Bednarek", 0 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 3,
                columns: new[] { "Cena", "Nazwisko", "Punkty" },
                values: new object[] { 8.5m, "Pereira", 0 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 4,
                columns: new[] { "Cena", "KlubId", "Nazwisko", "Punkty" },
                values: new object[] { 7m, 1, "Gurgul", 0 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 5,
                columns: new[] { "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 6.5m, 1, "Milic", "Obrońca", 0 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 6,
                columns: new[] { "Cena", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 6.5m, "Douglas", "Obrońca", 0 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 7,
                columns: new[] { "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 5.5m, 1, "Salamon", "Obrońca", 0 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 8,
                columns: new[] { "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 4.5m, 1, "Andersson", "Obrońca", 0 });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 24, 4m, 1, "Lisman", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 42, 9m, 2, "Hansen", "Pomocnik", 0 },
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
                    { 57, 3m, 2, "Wojdakowski", "Napastnik", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 57);

            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "Zawodnicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 1,
                column: "Nazwa",
                value: "FC Barcelona");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 2,
                column: "Nazwa",
                value: "Real Madrid");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 3,
                column: "Nazwa",
                value: "Manchester United");

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 1,
                columns: new[] { "Cena", "Imie", "Nazwisko", "Punkty" },
                values: new object[] { 50m, "Marc", "Ter Stegen", 100 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 2,
                columns: new[] { "Cena", "Imie", "KlubId", "Nazwisko", "Punkty" },
                values: new object[] { 55m, "Thibaut", 2, "Courtois", 95 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 3,
                columns: new[] { "Cena", "Imie", "Nazwisko", "Punkty" },
                values: new object[] { 40m, "Gerard", "Pique", 80 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 4,
                columns: new[] { "Cena", "Imie", "KlubId", "Nazwisko", "Punkty" },
                values: new object[] { 42m, "David", 2, "Alaba", 85 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 5,
                columns: new[] { "Cena", "Imie", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 60m, "Bruno", 3, "Fernandes", "Pomocnik", 110 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 6,
                columns: new[] { "Cena", "Imie", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 55m, "Pedri", "Gonzalez", "Pomocnik", 105 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 7,
                columns: new[] { "Cena", "Imie", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 70m, "Marcus", 3, "Rashford", "Napastnik", 120 });

            migrationBuilder.UpdateData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 8,
                columns: new[] { "Cena", "Imie", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[] { 75m, "Karim", 2, "Benzema", "Napastnik", 130 });
        }
    }
}
