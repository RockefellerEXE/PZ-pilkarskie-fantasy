using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 84, 5m, 3, "Diaz", "Napastnik", 0 },
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
                    { 99, 4.5m, 4, "Kun", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 126, 4.5m, 5, "Lis", "Obrońca", 0 },
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
                    { 141, 3m, 5, "Bąk", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 168, 4.5m, 6, "Bzdyl", "Pomocnik", 0 },
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
                    { 183, 5.5m, 7, "Wojtuszek", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 210, 5m, 8, "Wojcik", "Obrońca", 0 },
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
                    { 225, 9m, 8, "Mraz", "Napastnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 252, 10.5m, 9, "Rondic", "Napastnik", 0 },
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
                    { 267, 7m, 10, "Błąd", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 294, 9m, 11, "Felix", "Pomocnik", 0 },
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
                    { 309, 6m, 12, "Jaunzems", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 336, 5.5m, 13, "Kłudka", "Obrońca", 0 },
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
                    { 351, 4.5m, 13, "Kolan", "Pomocnik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 378, 4m, 14, "Hajda", "Pomocnik", 0 },
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
                    { 393, 5m, 15, "Matuszewski", "Obrońca", 0 }
                });

            migrationBuilder.InsertData(
                table: "Zawodnicy",
                columns: new[] { "ZawodnikId", "Cena", "KlubId", "Nazwisko", "Pozycja", "Punkty" },
                values: new object[,]
                {
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
                    { 416, 3.5m, 15, "Bąk", "Napastnik", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Zawodnicy",
                keyColumn: "ZawodnikId",
                keyValue: 416);
        }
    }
}
