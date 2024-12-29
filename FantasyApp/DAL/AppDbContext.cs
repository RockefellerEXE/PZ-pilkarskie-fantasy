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
        }
    }

}
