namespace FantasyApp.Models
{
    public class HistoriaCen
    {
        public int HistoriaCenId { get; set; }
        public int ZawodnikId { get; set; }
        public int Kolejka { get; set; }
        public double Cena { get; set; }
        public Zawodnik Zawodnik { get; set; } // Nawigacja

    }
}
