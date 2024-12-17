using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{
    public class Zawodnik
    {
        [Key]
        public int ZawodnikId { get; set; } // Zmieniono nazwę na ZawodnikId
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pozycja { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Narodowosc { get; set; }
        public int punkty { get; set; }
        public double cena { get; set; }
        public int posiadanie { get; set; }

        // Klucz obcy do tabeli Klub
        public int KlubId { get; set; }
        public Klub Klub { get; set; }

        // Relacja do statystyk
        public ICollection<StatystykiZawodnika> Statystyki { get; set; }
    }


}
