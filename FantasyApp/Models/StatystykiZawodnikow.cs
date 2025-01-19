using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{

	public class StatystykiZawodnikow
	{
		//[Key]
		public int StatystykiZawodnikowId { get; set; } // Klucz główny
		//public int DruzynaId { get; set; } // Klucz obcy
		public int ZawodnikId { get; set; } // Klucz obcy

		public int Bramki { get; set; }
		public int Asysty { get; set; }
		public int ZolteKartki { get; set; }
		public int CzerwoneKartki { get; set; }
		public int KarneSpowodowane { get; set; }
		public int KarneWywalczone { get; set; }
		public int KarneZmarnowane { get; set; }
		public int StrzalyObronione { get; set; }
		public int Punkty { get; set; }

		//public Druzyna Druzyna { get; set; } // Nawigacja
		public Zawodnik Zawodnik { get; set; } // Nawigacja
	}



}
