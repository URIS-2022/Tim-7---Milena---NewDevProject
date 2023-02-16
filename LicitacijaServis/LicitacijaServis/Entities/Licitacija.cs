using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicitacijaServis.Entities
{
    public class Licitacija
    {
        [Key]
        public Guid LicitacijaId { get; set; }
        public int Broj { get; set; }

        public int Godina { get; set; }

        public int Ogranicenje { get; set; }

        public int KorakCene { get; set; }

        public string? ListaDokumentacijeFizickaLica { get; set; }

        public string? ListaDokumentacijePravnaLica { get; set; }

        public DateTime Rok { get; set; }

        public DateTime Datum { get; set; }

         [NotMapped]
         public List<Guid>? JavnaNadmetanja { get; set; } 
    }
}
