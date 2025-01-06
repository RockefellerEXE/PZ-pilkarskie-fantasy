using FantasyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyApp.DAL
{
	public class FantasyContext : DbContext
	{
		public FantasyContext(DbContextOptions<FantasyContext> options) : base(options)
		{
		}
		public DbSet<Uzytkownik> Uzytkownicy { get; set; }
		public DbSet<Druzyna> Druzyny { get; set; }
		public DbSet<SkladDruzyny> SkladDruzyny { get; set; }
		public DbSet<Klub> Kluby { get; set; }
		public DbSet<Zawodnik> Zawodnicy { get; set; }
		public DbSet<StatystykiZawodnikow> StatystykiZawodnikow { get; set; }
		public DbSet<Transfer> Transfery { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// SkladDruzyny: Klucz złożony
			modelBuilder.Entity<SkladDruzyny>()
				.HasKey(sd => new { sd.DruzynaId, sd.ZawodnikId });

			// Relacje SkladDruzyny
			modelBuilder.Entity<SkladDruzyny>()
				.HasOne(sd => sd.Druzyna)
				.WithMany(d => d.SkladDruzyny)
				.HasForeignKey(sd => sd.DruzynaId);

			modelBuilder.Entity<SkladDruzyny>()
				.HasOne(sd => sd.Zawodnik)
				.WithMany(z => z.SkladDruzyny)
				.HasForeignKey(sd => sd.ZawodnikId);

			// Relacja Zawodnik -> Klub
			modelBuilder.Entity<Zawodnik>()
				.HasOne(z => z.Klub)
				.WithMany(k => k.Zawodnicy)
				.HasForeignKey(z => z.KlubId);

			// Relacja Statystyki -> Druzyna i Zawodnik
			modelBuilder.Entity<StatystykiZawodnikow>()
				.HasOne(sz => sz.Druzyna)
				.WithMany(d => d.Statystyki)
				.HasForeignKey(sz => sz.DruzynaId);

			modelBuilder.Entity<StatystykiZawodnikow>()
				.HasOne(sz => sz.Zawodnik)
				.WithMany(z => z.Statystyki)
				.HasForeignKey(sz => sz.ZawodnikId);

			// Relacja Transfer -> Druzyna i Zawodnik
			modelBuilder.Entity<Transfer>()
				.HasOne(t => t.Druzyna)
				.WithMany(d => d.Transfery)
				.HasForeignKey(t => t.DruzynaId);

			modelBuilder.Entity<Transfer>()
				.HasOne(t => t.Zawodnik)
				.WithMany(z => z.Transfery)
				.HasForeignKey(t => t.ZawodnikId);

			// Dodanie danych początkowych
			modelBuilder.Entity<Klub>().HasData(

				new Klub { KlubId = 1, Nazwa = "Lech Poznań" },
				new Klub { KlubId = 2, Nazwa = "Raków Częstochowa" },
				new Klub { KlubId = 3, Nazwa = "Jagiellonia Białystok" },
				new Klub { KlubId = 4, Nazwa = "Legia Warszawa" },
				new Klub { KlubId = 5, Nazwa = "Cracovia" },
				new Klub { KlubId = 6, Nazwa = "Górnik Zabrze" },
				new Klub { KlubId = 7, Nazwa = "Motor Lublin" },
				new Klub { KlubId = 8, Nazwa = "Pogoń Szczecin" },
				new Klub { KlubId = 9, Nazwa = "Widzew Łódź" },
				new Klub { KlubId = 10, Nazwa = "GKS Katowice" },
				new Klub { KlubId = 11, Nazwa = "Piast Gliwice" },
				new Klub { KlubId = 12, Nazwa = "Radomiak Radom" },
				new Klub { KlubId = 13, Nazwa = "Stal Mielec" },
				new Klub { KlubId = 14, Nazwa = "Zagłębie Lubin" },
				new Klub { KlubId = 15, Nazwa = "Puszcza Niepołomice" },
				new Klub { KlubId = 16, Nazwa = "Korona Kielce" },
				new Klub { KlubId = 17, Nazwa = "Lechia Gdańsk" },
				new Klub { KlubId = 18, Nazwa = "Śląsk Wrocław" }

			);

			modelBuilder.Entity<Uzytkownik>().HasData(
				new Uzytkownik { UzytkownikId = 1, Login = "user1", Punkty = 0 },
				new Uzytkownik { UzytkownikId = 2, Login = "user2", Punkty = 0 },
				new Uzytkownik { UzytkownikId = 3, Login = "user3", Punkty = 0 }
			);

			modelBuilder.Entity<Druzyna>().HasData(
				new Druzyna { DruzynaId = 1, UzytkownikId = 1, NazwaDruzyny = "Drużyna A", Budzet = 100 },
				new Druzyna { DruzynaId = 2, UzytkownikId = 2, NazwaDruzyny = "Drużyna B", Budzet = 100 },
				new Druzyna { DruzynaId = 3, UzytkownikId = 3, NazwaDruzyny = "Drużyna C", Budzet = 100 }
			//new Druzyna { DruzynaId = 1, Nazwa = "Dream Team", UzytkownikId = 1 },
			//new Druzyna { DruzynaId = 2, Nazwa = "Galacticos", UzytkownikId = 2 },
			//new Druzyna { DruzynaId = 3, Nazwa = "Red Devils", UzytkownikId = 3 }
			);

			modelBuilder.Entity<Zawodnik>().HasData(

				//LECH
				new Zawodnik { ZawodnikId = 1, KlubId = 1, Nazwisko = "Mrozek", Pozycja = "Bramkarz", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 2, KlubId = 1, Nazwisko = "Bednarek", Pozycja = "Bramkarz", Cena = 5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 3, KlubId = 1, Nazwisko = "Pereira", Pozycja = "Obrońca", Cena = 8.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 4, KlubId = 1, Nazwisko = "Gurgul", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 5, KlubId = 1, Nazwisko = "Milic", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 6, KlubId = 1, Nazwisko = "Douglas", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 7, KlubId = 1, Nazwisko = "Salamon", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 8, KlubId = 1, Nazwisko = "Andersson", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 9, KlubId = 1, Nazwisko = "Pingot", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 10, KlubId = 1, Nazwisko = "Hoffman", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 11, KlubId = 1, Nazwisko = "Mońka", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 12, KlubId = 1, Nazwisko = "Dagerstal", Pozycja = "Obrońca", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 13, KlubId = 1, Nazwisko = "Wichtowski", Pozycja = "Obrońca", Cena = 4m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 14, KlubId = 1, Nazwisko = "Sousa", Pozycja = "Pomocnik", Cena = 10.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 15, KlubId = 1, Nazwisko = "Walemark", Pozycja = "Pomocnik", Cena = 8.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 16, KlubId = 1, Nazwisko = "Hotic", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 17, KlubId = 1, Nazwisko = "Hakans", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 18, KlubId = 1, Nazwisko = "Gholizadeh", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 19, KlubId = 1, Nazwisko = "Kozubal", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 20, KlubId = 1, Nazwisko = "Murawski", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 21, KlubId = 1, Nazwisko = "Jagiełło", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 22, KlubId = 1, Nazwisko = "Ba Loua", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 23, KlubId = 1, Nazwisko = "S. Loncar", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 24, KlubId = 1, Nazwisko = "Lisman", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 25, KlubId = 1, Nazwisko = "Ishak", Pozycja = "Napastnik", Cena = 14m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 26, KlubId = 1, Nazwisko = "Szymczak", Pozycja = "Napastnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 27, KlubId = 1, Nazwisko = "Fiabema", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },

				//JAGIELLONIA

				new Zawodnik { ZawodnikId = 28, KlubId = 2, Nazwisko = "Abramowicz", Pozycja = "Bramkarz", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 29, KlubId = 2, Nazwisko = "Stryjek", Pozycja = "Bramkarz", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 30, KlubId = 2, Nazwisko = "Zynel", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 31, KlubId = 2, Nazwisko = "Piekutkowski", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 32, KlubId = 2, Nazwisko = "Suchocki", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 33, KlubId = 2, Nazwisko = "Moutinho", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 34, KlubId = 2, Nazwisko = "Sacek", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 35, KlubId = 2, Nazwisko = "Skrzypczak", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 36, KlubId = 2, Nazwisko = "Dieguez", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 37, KlubId = 2, Nazwisko = "Stojinovic", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 38, KlubId = 2, Nazwisko = "Tomas Silva", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 39, KlubId = 2, Nazwisko = "Haliti", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 40, KlubId = 2, Nazwisko = "Polak", Pozycja = "Obrońca", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 41, KlubId = 2, Nazwisko = "Kovacik", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 42, KlubId = 2, Nazwisko = "Hansen", Pozycja = "Pomocnik", Cena = 9m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 43, KlubId = 2, Nazwisko = "Miki", Pozycja = "Pomocnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 44, KlubId = 2, Nazwisko = "Curlinov", Pozycja = "Pomocnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 45, KlubId = 2, Nazwisko = "Kubicki", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 46, KlubId = 2, Nazwisko = "Nene", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 47, KlubId = 2, Nazwisko = "Romanczuk", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 48, KlubId = 2, Nazwisko = "Listkowski", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 49, KlubId = 2, Nazwisko = "Nguiamba", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 50, KlubId = 2, Nazwisko = "Kozłowski", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 51, KlubId = 2, Nazwisko = "Stypułkowski", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 52, KlubId = 2, Nazwisko = "Imaz", Pozycja = "Napastnik", Cena = 12m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 53, KlubId = 2, Nazwisko = "Pululu", Pozycja = "Napastnik", Cena = 10m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 54, KlubId = 2, Nazwisko = "Fadiga", Pozycja = "Napastnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 55, KlubId = 2, Nazwisko = "Rybak", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 56, KlubId = 2, Nazwisko = "Pietuszewski", Pozycja = "Napastnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 57, KlubId = 2, Nazwisko = "Wojdakowski", Pozycja = "Napastnik", Cena = 3m, Punkty = 0 },

				// Raków
				new Zawodnik { ZawodnikId = 58, KlubId = 3, Nazwisko = "Trelowski", Pozycja = "Bramkarz", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 59, KlubId = 3, Nazwisko = "Kuciak", Pozycja = "Bramkarz", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 60, KlubId = 3, Nazwisko = "Carlos", Pozycja = "Obrońca", Cena = 8.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 61, KlubId = 3, Nazwisko = "Tudor", Pozycja = "Obrońca", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 62, KlubId = 3, Nazwisko = "Svarnas", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 63, KlubId = 3, Nazwisko = "Mosór", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 64, KlubId = 3, Nazwisko = "Racovitan", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 65, KlubId = 3, Nazwisko = "Arsenic", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 66, KlubId = 3, Nazwisko = "Otieno", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 67, KlubId = 3, Nazwisko = "Rodin", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 68, KlubId = 3, Nazwisko = "Pestka", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 69, KlubId = 3, Nazwisko = "Rundic", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 70, KlubId = 3, Nazwisko = "Ivi", Pozycja = "Pomocnik", Cena = 9.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 71, KlubId = 3, Nazwisko = "Ameyaw", Pozycja = "Pomocnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 72, KlubId = 3, Nazwisko = "Amorim", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 73, KlubId = 3, Nazwisko = "Kocherhin", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 74, KlubId = 3, Nazwisko = "Berggren", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 75, KlubId = 3, Nazwisko = "Lamprou", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 76, KlubId = 3, Nazwisko = "Plavsic", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 77, KlubId = 3, Nazwisko = "Drachal", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 78, KlubId = 3, Nazwisko = "Czyż", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 79, KlubId = 3, Nazwisko = "Barath", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 80, KlubId = 3, Nazwisko = "Lederman", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 81, KlubId = 3, Nazwisko = "Nowakowski", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 82, KlubId = 3, Nazwisko = "Brunes", Pozycja = "Napastnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 83, KlubId = 3, Nazwisko = "Makuch", Pozycja = "Napastnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 84, KlubId = 3, Nazwisko = "Diaz", Pozycja = "Napastnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 85, KlubId = 3, Nazwisko = "Walczak", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },

				//LEGIA

				new Zawodnik { ZawodnikId = 86, KlubId = 4, Nazwisko = "Tobiasz", Pozycja = "Bramkarz", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 87, KlubId = 4, Nazwisko = "Kobylak", Pozycja = "Bramkarz", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 88, KlubId = 4, Nazwisko = "Mendes", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 89, KlubId = 4, Nazwisko = "Banasik", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 90, KlubId = 4, Nazwisko = "Vinagre", Pozycja = "Obrońca", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 91, KlubId = 4, Nazwisko = "Wszołek", Pozycja = "Obrońca", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 92, KlubId = 4, Nazwisko = "Kapuadi", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 93, KlubId = 4, Nazwisko = "Augustyniak", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 94, KlubId = 4, Nazwisko = "Pankov", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 95, KlubId = 4, Nazwisko = "Ziółkowski", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 96, KlubId = 4, Nazwisko = "Jędrzejczyk", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 97, KlubId = 4, Nazwisko = "Barcia", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 98, KlubId = 4, Nazwisko = "Burch", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 99, KlubId = 4, Nazwisko = "Kun", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 100, KlubId = 4, Nazwisko = "Leszczyński", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 101, KlubId = 4, Nazwisko = "Chodyna", Pozycja = "Pomocnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 102, KlubId = 4, Nazwisko = "Kapustka", Pozycja = "Pomocnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 103, KlubId = 4, Nazwisko = "Morishita", Pozycja = "Pomocnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 104, KlubId = 4, Nazwisko = "Elitim", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 105, KlubId = 4, Nazwisko = "Luquinhas", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 106, KlubId = 4, Nazwisko = "Oyedele", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 107, KlubId = 4, Nazwisko = "Goncalves", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 108, KlubId = 4, Nazwisko = "Celhaka", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 109, KlubId = 4, Nazwisko = "Urbański", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 110, KlubId = 4, Nazwisko = "Adkonis", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 111, KlubId = 4, Nazwisko = "Żewłakow", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 112, KlubId = 4, Nazwisko = "Gual", Pozycja = "Napastnik", Cena = 8.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 113, KlubId = 4, Nazwisko = "Nsame", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 114, KlubId = 4, Nazwisko = "Alfarela", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 115, KlubId = 4, Nazwisko = "Pekhart", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 116, KlubId = 4, Nazwisko = "Szczepaniak", Pozycja = "Napastnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 117, KlubId = 4, Nazwisko = "Majchrzak", Pozycja = "Napastnik", Cena = 3.5m, Punkty = 0 },


				//POGOŃ

				new Zawodnik { ZawodnikId = 118, KlubId = 5, Nazwisko = "Cojocaru", Pozycja = "Bramkarz", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 119, KlubId = 5, Nazwisko = "Kamiński", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 120, KlubId = 5, Nazwisko = "Wahlqvist", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 121, KlubId = 5, Nazwisko = "Koutris", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 122, KlubId = 5, Nazwisko = "Borges", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 123, KlubId = 5, Nazwisko = "Keramitsis", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 124, KlubId = 5, Nazwisko = "Zech", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 125, KlubId = 5, Nazwisko = "Malec", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 126, KlubId = 5, Nazwisko = "Lis", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 127, KlubId = 5, Nazwisko = "D.Loncar", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 128, KlubId = 5, Nazwisko = "Lisowski", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 129, KlubId = 5, Nazwisko = "Grosicki", Pozycja = "Pomocnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 130, KlubId = 5, Nazwisko = "Vahan", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 131, KlubId = 5, Nazwisko = "Łukasiak", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 132, KlubId = 5, Nazwisko = "Gorgon", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 133, KlubId = 5, Nazwisko = "Ulvestad", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 134, KlubId = 5, Nazwisko = "Kurzawa", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 135, KlubId = 5, Nazwisko = "Gamboa", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 136, KlubId = 5, Nazwisko = "Przyborek", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 137, KlubId = 5, Nazwisko = "Korczakowski", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 138, KlubId = 5, Nazwisko = "Smoliński", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 139, KlubId = 5, Nazwisko = "Wędrychowski", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 140, KlubId = 5, Nazwisko = "Wojciechowski", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 141, KlubId = 5, Nazwisko = "Bąk", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 142, KlubId = 5, Nazwisko = "Koulouris", Pozycja = "Napastnik", Cena = 10.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 143, KlubId = 5, Nazwisko = "Paryzek", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 144, KlubId = 5, Nazwisko = "Klukowski", Pozycja = "Napastnik", Cena = 3.5m, Punkty = 0 },


				//CRACOVIA
				new Zawodnik { ZawodnikId = 145, KlubId = 6, Nazwisko = "Ravas", Pozycja = "Bramkarz", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 146, KlubId = 6, Nazwisko = "Madejski", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 147, KlubId = 6, Nazwisko = "Burek", Pozycja = "Bramkarz", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 148, KlubId = 6, Nazwisko = "Golonka", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 149, KlubId = 6, Nazwisko = "Kakabadze", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 150, KlubId = 6, Nazwisko = "Olafsson", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 151, KlubId = 6, Nazwisko = "Ghita", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 152, KlubId = 6, Nazwisko = "Jugas", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 153, KlubId = 6, Nazwisko = "Glik", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 154, KlubId = 6, Nazwisko = "Hoskonen", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 155, KlubId = 6, Nazwisko = "Biedrzycki", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 156, KlubId = 6, Nazwisko = "Skovgaard", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 157, KlubId = 6, Nazwisko = "Janasik", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 158, KlubId = 6, Nazwisko = "Wójcik", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 159, KlubId = 6, Nazwisko = "Pestka", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 160, KlubId = 6, Nazwisko = "Hasic", Pozycja = "Pomocnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 161, KlubId = 6, Nazwisko = "Maigaard", Pozycja = "Pomocnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 162, KlubId = 6, Nazwisko = "Rózga", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 163, KlubId = 6, Nazwisko = "Al-Ammari", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 164, KlubId = 6, Nazwisko = "Rakoczy", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 165, KlubId = 6, Nazwisko = "Sokołowski", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 166, KlubId = 6, Nazwisko = "Atanasov", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 167, KlubId = 6, Nazwisko = "Bochnak", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 168, KlubId = 6, Nazwisko = "Bzdyl", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 169, KlubId = 6, Nazwisko = "Lachowicz", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 170, KlubId = 6, Nazwisko = "Pomietło", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 171, KlubId = 6, Nazwisko = "Kallman", Pozycja = "Napastnik", Cena = 13m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 172, KlubId = 6, Nazwisko = "Buren", Pozycja = "Napastnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 173, KlubId = 6, Nazwisko = "Śmiglewski", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },


				// Górnik
				new Zawodnik { ZawodnikId = 174, KlubId = 7, Nazwisko = "Szromnik", Pozycja = "Bramkarz", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 175, KlubId = 7, Nazwisko = "Majchrowicz", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 176, KlubId = 7, Nazwisko = "Jeleń", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 177, KlubId = 7, Nazwisko = "Soberka", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 178, KlubId = 7, Nazwisko = "Janza", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 179, KlubId = 7, Nazwisko = "Josema", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 180, KlubId = 7, Nazwisko = "Janicki", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 181, KlubId = 7, Nazwisko = "Sanchez", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 182, KlubId = 7, Nazwisko = "Szala", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 183, KlubId = 7, Nazwisko = "Wojtuszek", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 184, KlubId = 7, Nazwisko = "Szcześniak", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 185, KlubId = 7, Nazwisko = "Olkowski", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 186, KlubId = 7, Nazwisko = "Barczak", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 187, KlubId = 7, Nazwisko = "Rasak", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 188, KlubId = 7, Nazwisko = "Ambros", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 189, KlubId = 7, Nazwisko = "Ismaheel", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 190, KlubId = 7, Nazwisko = "Lukoszek", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 191, KlubId = 7, Nazwisko = "Hellebrand", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 192, KlubId = 7, Nazwisko = "Furukawa", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 193, KlubId = 7, Nazwisko = "Nascimento", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 194, KlubId = 7, Nazwisko = "Zielonka", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 195, KlubId = 7, Nazwisko = "Tobolik", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 196, KlubId = 7, Nazwisko = "Sarapata", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 197, KlubId = 7, Nazwisko = "Zahovic", Pozycja = "Napastnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 198, KlubId = 7, Nazwisko = "Podolski", Pozycja = "Napastnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 199, KlubId = 7, Nazwisko = "Buksa", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 200, KlubId = 7, Nazwisko = "Bakis", Pozycja = "Napastnik", Cena = 5m, Punkty = 0 },

				// Motor
				new Zawodnik { ZawodnikId = 201, KlubId = 8, Nazwisko = "Brkic", Pozycja = "Bramkarz", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 202, KlubId = 8, Nazwisko = "Rosa", Pozycja = "Bramkarz", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 203, KlubId = 8, Nazwisko = "Bartnik", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 204, KlubId = 8, Nazwisko = "Jeż", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 205, KlubId = 8, Nazwisko = "Luberecki", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 206, KlubId = 8, Nazwisko = "Rudol", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 207, KlubId = 8, Nazwisko = "Bartos", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 208, KlubId = 8, Nazwisko = "Najemski", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 209, KlubId = 8, Nazwisko = "Stolarski", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 210, KlubId = 8, Nazwisko = "Wojcik", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 211, KlubId = 8, Nazwisko = "Palacz", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 212, KlubId = 8, Nazwisko = "Romanowski", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 213, KlubId = 8, Nazwisko = "Kruk", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 214, KlubId = 8, Nazwisko = "Wolski", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 215, KlubId = 8, Nazwisko = "M.Król", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 216, KlubId = 8, Nazwisko = "Simon", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 217, KlubId = 8, Nazwisko = "Caliskaner", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 218, KlubId = 8, Nazwisko = "Samper", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 219, KlubId = 8, Nazwisko = "Kubica", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 220, KlubId = 8, Nazwisko = "van Hoeven", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 221, KlubId = 8, Nazwisko = "Scalet", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 222, KlubId = 8, Nazwisko = "Gąsior", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 223, KlubId = 8, Nazwisko = "Wełniak", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 224, KlubId = 8, Nazwisko = "R.Król", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 225, KlubId = 8, Nazwisko = "Mraz", Pozycja = "Napastnik", Cena = 9m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 226, KlubId = 8, Nazwisko = "Ceglarz", Pozycja = "Napastnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 227, KlubId = 8, Nazwisko = "Ndiaye", Pozycja = "Napastnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 228, KlubId = 8, Nazwisko = "Śpiewak", Pozycja = "Napastnik", Cena = 3m, Punkty = 0 },


				// Widzew
				new Zawodnik { ZawodnikId = 229, KlubId = 9, Nazwisko = "Gikiewicz", Pozycja = "Bramkarz", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 230, KlubId = 9, Nazwisko = "Krzywański", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 231, KlubId = 9, Nazwisko = "Biegański", Pozycja = "Bramkarz", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 232, KlubId = 9, Nazwisko = "Żyro", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 233, KlubId = 9, Nazwisko = "Kozlovsky", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 234, KlubId = 9, Nazwisko = "Ibiza", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 235, KlubId = 9, Nazwisko = "Silva", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 236, KlubId = 9, Nazwisko = "Krajewski", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 237, KlubId = 9, Nazwisko = "Kastrati", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 238, KlubId = 9, Nazwisko = "Hajrizi", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 239, KlubId = 9, Nazwisko = "Kwiatkowski", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 240, KlubId = 9, Nazwisko = "Pawłowski", Pozycja = "Pomocnik", Cena = 8.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 241, KlubId = 9, Nazwisko = "Kerk", Pozycja = "Pomocnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 242, KlubId = 9, Nazwisko = "Alvarez", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 243, KlubId = 9, Nazwisko = "Łukowski", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 244, KlubId = 9, Nazwisko = "Cybulski", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 245, KlubId = 9, Nazwisko = "Klimek", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 246, KlubId = 9, Nazwisko = "Shehu", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 247, KlubId = 9, Nazwisko = "Hanousek", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 248, KlubId = 9, Nazwisko = "Diliberto", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 249, KlubId = 9, Nazwisko = "Gong", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 250, KlubId = 9, Nazwisko = "Nunes", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 251, KlubId = 9, Nazwisko = "Gryzio", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 252, KlubId = 9, Nazwisko = "Rondic", Pozycja = "Napastnik", Cena = 10.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 253, KlubId = 9, Nazwisko = "Sypek", Pozycja = "Napastnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 254, KlubId = 9, Nazwisko = "Hamulic", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 255, KlubId = 9, Nazwisko = "Sobol", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },


				// GKS
				new Zawodnik { ZawodnikId = 256, KlubId = 10, Nazwisko = "Kudła", Pozycja = "Bramkarz", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 257, KlubId = 10, Nazwisko = "Strączek", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 258, KlubId = 10, Nazwisko = "Jędrych", Pozycja = "Obrońca", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 259, KlubId = 10, Nazwisko = "Wasielewski", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 260, KlubId = 10, Nazwisko = "Czerwiński", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 261, KlubId = 10, Nazwisko = "Rogala", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 262, KlubId = 10, Nazwisko = "Klemenz", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 263, KlubId = 10, Nazwisko = "Kuusk", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 264, KlubId = 10, Nazwisko = "Komor", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 265, KlubId = 10, Nazwisko = "Jaroszek", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 266, KlubId = 10, Nazwisko = "Trepka", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 267, KlubId = 10, Nazwisko = "Błąd", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 268, KlubId = 10, Nazwisko = "Nowak", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 269, KlubId = 10, Nazwisko = "Galan", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 270, KlubId = 10, Nazwisko = "Mak", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 271, KlubId = 10, Nazwisko = "Repka", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 272, KlubId = 10, Nazwisko = "Kowalczyk", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 273, KlubId = 10, Nazwisko = "Milewski", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 274, KlubId = 10, Nazwisko = "Marzec", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 275, KlubId = 10, Nazwisko = "Antczak", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 276, KlubId = 10, Nazwisko = "Baranowicz", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 277, KlubId = 10, Nazwisko = "Bród", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 278, KlubId = 10, Nazwisko = "Zrelak", Pozycja = "Napastnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 279, KlubId = 10, Nazwisko = "Bergier", Pozycja = "Napastnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 280, KlubId = 10, Nazwisko = "Arak", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },

				// Piast
				new Zawodnik { ZawodnikId = 281, KlubId = 11, Nazwisko = "Plach", Pozycja = "Bramkarz", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 282, KlubId = 11, Nazwisko = "Szymański", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 283, KlubId = 11, Nazwisko = "Pyrka", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 284, KlubId = 11, Nazwisko = "Huk", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 285, KlubId = 11, Nazwisko = "Czerwiński", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 286, KlubId = 11, Nazwisko = "Drapiński", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 287, KlubId = 11, Nazwisko = "Munoz", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 288, KlubId = 11, Nazwisko = "Nobrega", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 289, KlubId = 11, Nazwisko = "Lewicki", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 290, KlubId = 11, Nazwisko = "Mokwa", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 291, KlubId = 11, Nazwisko = "Reiner", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 292, KlubId = 11, Nazwisko = "Liszewski", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 293, KlubId = 11, Nazwisko = "Pitan", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 294, KlubId = 11, Nazwisko = "Felix", Pozycja = "Pomocnik", Cena = 9m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 295, KlubId = 11, Nazwisko = "Chrapek", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 296, KlubId = 11, Nazwisko = "Kądzior", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 297, KlubId = 11, Nazwisko = "Szczepański", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 298, KlubId = 11, Nazwisko = "Dziczek", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 299, KlubId = 11, Nazwisko = "Tomasiewicz", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 300, KlubId = 11, Nazwisko = "Kostadinov", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 301, KlubId = 11, Nazwisko = "Mucha", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 302, KlubId = 11, Nazwisko = "Leśniak", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 303, KlubId = 11, Nazwisko = "Karbowy", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 304, KlubId = 11, Nazwisko = "Rosołek", Pozycja = "Napastnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 305, KlubId = 11, Nazwisko = "Piasecki", Pozycja = "Napastnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 306, KlubId = 11, Nazwisko = "Katsantonis", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },


				//STAL MIELEC

				new Zawodnik { ZawodnikId = 307, KlubId = 12, Nazwisko = "Mądrzyk", Pozycja = "Bramkarz", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 308, KlubId = 12, Nazwisko = "Jałocha", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 309, KlubId = 12, Nazwisko = "Jaunzems", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 310, KlubId = 12, Nazwisko = "Getinger", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 311, KlubId = 12, Nazwisko = "Senger", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 312, KlubId = 12, Nazwisko = "Matras", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 313, KlubId = 12, Nazwisko = "Esselink", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 314, KlubId = 12, Nazwisko = "Ehmann", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 315, KlubId = 12, Nazwisko = "Wołkowicz", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 316, KlubId = 12, Nazwisko = "Bagalianis", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 317, KlubId = 12, Nazwisko = "Pajnowski", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 318, KlubId = 12, Nazwisko = "Domański", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 319, KlubId = 12, Nazwisko = "Wlazło", Pozycja = "Pomocnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 320, KlubId = 12, Nazwisko = "Krykun", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 321, KlubId = 12, Nazwisko = "Wolsztyński", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 322, KlubId = 12, Nazwisko = "Guillaumier", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 323, KlubId = 12, Nazwisko = "Dadok", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 324, KlubId = 12, Nazwisko = "Hinokio", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 325, KlubId = 12, Nazwisko = "Tkacz", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 326, KlubId = 12, Nazwisko = "Gerbowski", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 327, KlubId = 12, Nazwisko = "Knap", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 328, KlubId = 12, Nazwisko = "Bukowski", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 329, KlubId = 12, Nazwisko = "Shkurin", Pozycja = "Napastnik", Cena = 8m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 330, KlubId = 12, Nazwisko = "Assayag", Pozycja = "Napastnik", Cena = 5.5m, Punkty = 0 },


				//ZAGŁĘBIE LUBIN

				new Zawodnik { ZawodnikId = 331, KlubId = 13, Nazwisko = "Hładun", Pozycja = "Bramkarz", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 332, KlubId = 13, Nazwisko = "Buric", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 333, KlubId = 13, Nazwisko = "Matysek", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 334, KlubId = 13, Nazwisko = "Wdowiak", Pozycja = "Obrońca", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 335, KlubId = 13, Nazwisko = "Grzybek", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 336, KlubId = 13, Nazwisko = "Kłudka", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 337, KlubId = 13, Nazwisko = "Mata", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 338, KlubId = 13, Nazwisko = "Orlikowski", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 339, KlubId = 13, Nazwisko = "Ławniczak", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 340, KlubId = 13, Nazwisko = "Kopacz", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 341, KlubId = 13, Nazwisko = "Lepczyński", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 342, KlubId = 13, Nazwisko = "Nalepa", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 343, KlubId = 13, Nazwisko = "Jach", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 344, KlubId = 13, Nazwisko = "Mróz", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 345, KlubId = 13, Nazwisko = "Szmyt", Pozycja = "Pomocnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 346, KlubId = 13, Nazwisko = "Radwański", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 347, KlubId = 13, Nazwisko = "Makowski", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 348, KlubId = 13, Nazwisko = "Dąbrowski", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 349, KlubId = 13, Nazwisko = "Kusztal", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 350, KlubId = 13, Nazwisko = "Reguła", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 351, KlubId = 13, Nazwisko = "Kolan", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 352, KlubId = 13, Nazwisko = "Dziewiatowski", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 353, KlubId = 13, Nazwisko = "Adamczyk", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 354, KlubId = 13, Nazwisko = "Kocaba", Pozycja = "Pomocnik", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 355, KlubId = 13, Nazwisko = "Kurminowski", Pozycja = "Napastnik", Cena = 7.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 356, KlubId = 13, Nazwisko = "Pieńko", Pozycja = "Napastnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 357, KlubId = 13, Nazwisko = "Woźniak", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 358, KlubId = 13, Nazwisko = "Mikołajewski", Pozycja = "Napastnik", Cena = 4m, Punkty = 0 },

				//PUSZCZA NIEPOŁOMICE

				new Zawodnik { ZawodnikId = 359, KlubId = 14, Nazwisko = "Komar", Pozycja = "Bramkarz", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 360, KlubId = 14, Nazwisko = "Perchel", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 361, KlubId = 14, Nazwisko = "Craciun", Pozycja = "Obrońca", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 362, KlubId = 14, Nazwisko = "Revenco", Pozycja = "Obrońca", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 363, KlubId = 14, Nazwisko = "Yakuba", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 364, KlubId = 14, Nazwisko = "Szymonowicz", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 365, KlubId = 14, Nazwisko = "Siplak", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 366, KlubId = 14, Nazwisko = "Mroziński", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 367, KlubId = 14, Nazwisko = "K.Stępień", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 368, KlubId = 14, Nazwisko = "Sołowiej", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 369, KlubId = 14, Nazwisko = "Kieliś", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 370, KlubId = 14, Nazwisko = "Gil", Pozycja = "Obrońca", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 371, KlubId = 14, Nazwisko = "Lee", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 372, KlubId = 14, Nazwisko = "Blagaic", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 373, KlubId = 14, Nazwisko = "M.Stępień", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 374, KlubId = 14, Nazwisko = "Cholewiak", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 375, KlubId = 14, Nazwisko = "Abramowicz", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 376, KlubId = 14, Nazwisko = "Serafin", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 377, KlubId = 14, Nazwisko = "Radecki", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 378, KlubId = 14, Nazwisko = "Hajda", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 379, KlubId = 14, Nazwisko = "Walski", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 380, KlubId = 14, Nazwisko = "Siemaszko", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 381, KlubId = 14, Nazwisko = "Tomalski", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 382, KlubId = 14, Nazwisko = "Pieprzyca", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 383, KlubId = 14, Nazwisko = "Kogut", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 384, KlubId = 14, Nazwisko = "Kosidis", Pozycja = "Napastnik", Cena = 7m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 385, KlubId = 14, Nazwisko = "Kidric", Pozycja = "Napastnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 386, KlubId = 14, Nazwisko = "Okoniewski", Pozycja = "Napastnik", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 387, KlubId = 14, Nazwisko = "Klisiewicz", Pozycja = "Napastnik", Cena = 3.5m, Punkty = 0 },


				//KORONA KIELCE

				new Zawodnik { ZawodnikId = 388, KlubId = 15, Nazwisko = "Dziekoński", Pozycja = "Bramkarz", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 389, KlubId = 15, Nazwisko = "Mamla", Pozycja = "Bramkarz", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 390, KlubId = 15, Nazwisko = "Zapytowski", Pozycja = "Bramkarz", Cena = 3m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 391, KlubId = 15, Nazwisko = "Resta", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 392, KlubId = 15, Nazwisko = "Zwoźny", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 393, KlubId = 15, Nazwisko = "Matuszewski", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 394, KlubId = 15, Nazwisko = "Zator", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 395, KlubId = 15, Nazwisko = "Błanik", Pozycja = "Obrońca", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 396, KlubId = 15, Nazwisko = "Pięczek", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 397, KlubId = 15, Nazwisko = "Trojak", Pozycja = "Obrońca", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 398, KlubId = 15, Nazwisko = "Smolarczyk", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 399, KlubId = 15, Nazwisko = "Malarczyk", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 400, KlubId = 15, Nazwisko = "Kośmicki", Pozycja = "Obrońca", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 401, KlubId = 15, Nazwisko = "Nuno", Pozycja = "Pomocnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 402, KlubId = 15, Nazwisko = "Fornalczyk", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 403, KlubId = 15, Nazwisko = "Nono", Pozycja = "Pomocnik", Cena = 5.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 404, KlubId = 15, Nazwisko = "Hofmayster", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 405, KlubId = 15, Nazwisko = "Remacle", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 406, KlubId = 15, Nazwisko = "Długosz", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 407, KlubId = 15, Nazwisko = "Nagamatsu", Pozycja = "Pomocnik", Cena = 5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 408, KlubId = 15, Nazwisko = "Trejo", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 409, KlubId = 15, Nazwisko = "Godinho", Pozycja = "Pomocnik", Cena = 4.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 410, KlubId = 15, Nazwisko = "Kamiński", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 411, KlubId = 15, Nazwisko = "Strzeboński", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 412, KlubId = 15, Nazwisko = "Konstantyn", Pozycja = "Pomocnik", Cena = 4m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 413, KlubId = 15, Nazwisko = "Chojecki", Pozycja = "Pomocnik", Cena = 3.5m, Punkty = 0 },

				new Zawodnik { ZawodnikId = 414, KlubId = 15, Nazwisko = "Dalmau", Pozycja = "Napastnik", Cena = 6.5m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 415, KlubId = 15, Nazwisko = "Shikavka", Pozycja = "Napastnik", Cena = 6m, Punkty = 0 },
				new Zawodnik { ZawodnikId = 416, KlubId = 15, Nazwisko = "Bąk", Pozycja = "Napastnik", Cena = 3.5m, Punkty = 0 }


			//RADOMIAK RADOM

			//LECHIA GDAŃSK

			//ŚLĄSK WROCŁAW

			);

			modelBuilder.Entity<SkladDruzyny>().HasData(
				new SkladDruzyny { DruzynaId = 1, ZawodnikId = 1 },
				new SkladDruzyny { DruzynaId = 1, ZawodnikId = 3 },
				new SkladDruzyny { DruzynaId = 2, ZawodnikId = 2 },
				new SkladDruzyny { DruzynaId = 2, ZawodnikId = 4 },
				new SkladDruzyny { DruzynaId = 3, ZawodnikId = 5 },
				new SkladDruzyny { DruzynaId = 3, ZawodnikId = 7 }
			);

			modelBuilder.Entity<StatystykiZawodnikow>().HasData(
				new StatystykiZawodnikow { StatystykiZawodnikowId = 1, DruzynaId = 1, ZawodnikId = 1, Bramki = 1, Asysty = 1, ZolteKartki = 0, CzerwoneKartki = 0, KarneSpowodowane = 0, KarneWywalczone = 0, KarneZmarnowane = 0, StrzalyObronione = 0, Punkty = 5 },
				new StatystykiZawodnikow { StatystykiZawodnikowId = 2, DruzynaId = 2, ZawodnikId = 2, Bramki = 1, Asysty = 1, ZolteKartki = 0, CzerwoneKartki = 0, KarneSpowodowane = 0, KarneWywalczone = 0, KarneZmarnowane = 0, StrzalyObronione = 0, Punkty = 5 },
				new StatystykiZawodnikow { StatystykiZawodnikowId = 3, DruzynaId = 1, ZawodnikId = 3, Bramki = 1, Asysty = 1, ZolteKartki = 0, CzerwoneKartki = 0, KarneSpowodowane = 0, KarneWywalczone = 0, KarneZmarnowane = 0, StrzalyObronione = 0, Punkty = 5 }
			);

			modelBuilder.Entity<Transfer>().HasData(
				new Transfer { TransferId = 1, DruzynaId = 1, ZawodnikId = 1, TypTransferu = "Kupno" },
				new Transfer { TransferId = 2, DruzynaId = 1, ZawodnikId = 3, TypTransferu = "Kupno" },
				new Transfer { TransferId = 3, DruzynaId = 2, ZawodnikId = 4, TypTransferu = "Kupno" }
			);
		}
	}
}
