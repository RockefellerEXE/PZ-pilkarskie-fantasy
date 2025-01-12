namespace FantasyApp.Models
{
    public class HistoriaCen
    {
        public int HistoriaCenId { get; set; }
        public int ZawodnikId { get; set; }
        public int Kolejka { get; set; }
        public decimal CenaPrzed { get; set; }
        public Zawodnik Zawodnik { get; set; } // Nawigacja

    }
}
