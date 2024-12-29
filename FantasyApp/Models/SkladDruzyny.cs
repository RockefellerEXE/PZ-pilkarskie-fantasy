﻿namespace FantasyApp.Models
{
    public class SkladDruzyny
    {
        public int DruzynaId { get; set; } // Klucz złożony
        public int ZawodnikId { get; set; } // Klucz złożony

        public Druzyna Druzyna { get; set; } // Nawigacja
        public Zawodnik Zawodnik { get; set; } // Nawigacja
    }

}