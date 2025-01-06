using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{
	public class Klub
	{
		public int KlubId { get; set; } // Klucz główny
		public string Nazwa { get; set; }

		public ICollection<Zawodnik> Zawodnicy { get; set; } // Nawigacja
	}


}
