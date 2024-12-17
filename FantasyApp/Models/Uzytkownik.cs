using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{
    public class Uzytkownik
    {
        [Key]
        public int UzytkownikId { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; } // zaszyfrowane hasło
        public string Email { get; set; }
        public int Punkty { get; set; }

        // Możesz dodać relacje jeśli użytkownik może mieć swoje mecze/statystyki
    }

}
