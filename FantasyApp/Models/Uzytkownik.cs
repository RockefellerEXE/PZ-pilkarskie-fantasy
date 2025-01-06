namespace FantasyApp.Models
{
	public class Uzytkownik
	{
		public int UzytkownikId { get; set; } // Klucz główny
		public string Login { get; set; }
		public int Punkty { get; set; }
		public ICollection<Druzyna> Druzyny { get; set; } // Nawigacja
	}
}
