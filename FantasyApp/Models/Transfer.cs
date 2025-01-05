namespace FantasyApp.Models
{
	public class Transfer
	{
		public int TransferId { get; set; } // Klucz główny
		public int DruzynaId { get; set; } // Klucz obcy
		public int ZawodnikId { get; set; } // Klucz obcy
		public string TypTransferu { get; set; } // "Kupno" lub "Sprzedaż"

		public Druzyna Druzyna { get; set; } // Nawigacja
		public Zawodnik Zawodnik { get; set; } // Nawigacja
	}

}
