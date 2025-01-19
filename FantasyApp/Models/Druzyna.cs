using System.Security.Cryptography.Xml;

namespace FantasyApp.Models
{
	public class Druzyna
	{
		public int DruzynaId { get; set; } // Klucz główny
		public int UzytkownikId { get; set; } // Klucz obcy
		public string NazwaDruzyny { get; set; }
		public decimal Budzet { get; set; }
        public int PozostaleTransfrery { get; set; }

        public Uzytkownik Uzytkownik { get; set; } // Nawigacja
		public ICollection<SkladDruzyny> SkladDruzyny { get; set; }
		//public ICollection<StatystykiZawodnikow> Statystyki { get; set; }
		public ICollection<Transfer> Transfery { get; set; }
	}

}
