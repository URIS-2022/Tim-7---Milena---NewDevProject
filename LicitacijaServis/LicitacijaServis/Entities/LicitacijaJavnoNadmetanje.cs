using System.ComponentModel.DataAnnotations.Schema;

namespace LicitacijaServis.Entities
{
    public class LicitacijaJavnoNadmetanje
    {
        [ForeignKey("Licitacija")]
        public Guid LicitacijaId { get; set; }

        public Guid JavnoNadmetanjeId { get; set; }

        public Licitacija Licitacija { get; set; }
    }
}
