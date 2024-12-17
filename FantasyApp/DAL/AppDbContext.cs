using FantasyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Zawodnik> Zawodnicy { get; set; }
        public DbSet<Klub> Kluby { get; set; }
        public DbSet<StatystykiZawodnika> StatystykiZawodnikow { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Mecz> Mecze { get; set; }

    }
}
