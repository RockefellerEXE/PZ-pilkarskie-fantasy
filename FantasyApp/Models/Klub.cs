using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{
    public class Klub
    {
        [Key]
        public int KlubId { get; set; }
        public string NazwaKlubu { get; set; }

        public ICollection<Zawodnik> Zawodnicy { get; set; }
    }

}
