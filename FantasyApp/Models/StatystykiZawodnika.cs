using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{
    
    public class StatystykiZawodnika
    {
        [Key]
        public int StatystykaId { get; set; } // Klucz główny
        public int ZawodnikId { get; set; }   // Zmieniono klucz obcy
        public int MeczId { get; set; }
        public int Minuty { get; set; }
        public int Bramki { get; set; }
        public int Asysty { get; set; }
        public int BramkiSamobojcze { get; set; }
        public int KarneWykonane { get; set; }
        public int KarneZmarnowane { get; set; }
        public int ZoltaKartka { get; set; }
        public int CzerwonaKartka { get; set; }
        public int StrzalyObronione { get; set; }
        public int Punkty { get; set; }

        public Zawodnik Zawodnik { get; set; } // Nawigacja
        public Mecz Mecz { get; set; }
    }


}
