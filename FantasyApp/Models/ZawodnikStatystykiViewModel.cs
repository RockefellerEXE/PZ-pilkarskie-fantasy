namespace FantasyApp.Models
{
	public class ZawodnikStatystykiViewModel
	{
		public string Nazwisko { get; set; }
		public string Pozycja { get; set; }
		public int Punkty { get; set; }
		public string Klub { get; set; }
		public int? Bramki { get; set; } // Nullable int
		public int? Asysty { get; set; }
		public int? ZolteKartki { get; set; }
		public int? CzerwoneKartki { get; set; }
		public int? KarneSpowodowane { get; set; }
		public int? KarneWywalczone { get; set; }
		public int? KarneZmarnowane { get; set; }
		public int? StrzalyObronione { get; set; }
	}

}
