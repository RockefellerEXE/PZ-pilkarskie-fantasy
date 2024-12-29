using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace FantasyApp.Models
{
    public class Zawodnik
    {
        public int ZawodnikId { get; set; } // Klucz główny
        public int KlubId { get; set; } // Klucz obcy
       // public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pozycja { get; set; }
        public decimal Cena { get; set; }
        public int Punkty { get; set; }

        public Klub Klub { get; set; } // Nawigacja
        public ICollection<SkladDruzyny> SkladDruzyny { get; set; }
        public ICollection<StatystykiZawodnikow> Statystyki { get; set; }
        public ICollection<Transfer> Transfery { get; set; }
    }



}
