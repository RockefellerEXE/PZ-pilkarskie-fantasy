using FantasyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyApp.DAL
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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
                new Klub { KlubId = 1, Nazwa = "FC Barcelona" },
                new Klub { KlubId = 2, Nazwa = "Real Madrid" },
                new Klub { KlubId = 3, Nazwa = "Manchester United" }
            );

            modelBuilder.Entity<Uzytkownik>().HasData(
                new Uzytkownik { UzytkownikId = 1, Login = "user1", Haslo = "password1", Email = "user1@example.com", Punkty = 0 },
                new Uzytkownik { UzytkownikId = 2, Login = "user2", Haslo = "password2", Email = "user2@example.com", Punkty = 0 },
                new Uzytkownik { UzytkownikId = 3, Login = "user3", Haslo = "password3", Email = "user3@example.com", Punkty = 0 }
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
                new Zawodnik { ZawodnikId = 1, KlubId = 1, Imie = "Marc", Nazwisko = "Ter Stegen", Pozycja = "Bramkarz", Cena = 50m, Punkty = 100 },
                new Zawodnik { ZawodnikId = 2, KlubId = 2, Imie = "Thibaut", Nazwisko = "Courtois", Pozycja = "Bramkarz", Cena = 55, Punkty = 95 },

                new Zawodnik { ZawodnikId = 3, KlubId = 1, Imie = "Gerard", Nazwisko = "Pique", Pozycja = "Obrońca", Cena = 40, Punkty = 80 },
                new Zawodnik { ZawodnikId = 4, KlubId = 2, Imie = "David", Nazwisko = "Alaba", Pozycja = "Obrońca", Cena = 42, Punkty = 85 },

                new Zawodnik { ZawodnikId = 5, KlubId = 3, Imie = "Bruno", Nazwisko = "Fernandes", Pozycja = "Pomocnik", Cena = 60, Punkty = 110 },
                new Zawodnik { ZawodnikId = 6, KlubId = 1, Imie = "Pedri", Nazwisko = "Gonzalez", Pozycja = "Pomocnik", Cena = 55, Punkty = 105 },

                new Zawodnik { ZawodnikId = 7, KlubId = 3, Imie = "Marcus", Nazwisko = "Rashford", Pozycja = "Napastnik", Cena = 70, Punkty = 120 },
                new Zawodnik { ZawodnikId = 8, KlubId = 2, Imie = "Karim", Nazwisko = "Benzema", Pozycja = "Napastnik", Cena = 75, Punkty = 130 }
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
