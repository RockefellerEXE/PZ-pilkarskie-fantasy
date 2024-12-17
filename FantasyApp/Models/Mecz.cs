using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{
    public class Mecz
    {
        [Key]
        public int MeczId { get; set; }
        public DateTime DataMeczu { get; set; }
        public string Wynik { get; set; }
        public string DruzynaDomowa { get; set; }
        public string DruzynaWyjazdowa { get; set; }

        public ICollection<StatystykiZawodnika> Statystyki { get; set; }
    }

}
