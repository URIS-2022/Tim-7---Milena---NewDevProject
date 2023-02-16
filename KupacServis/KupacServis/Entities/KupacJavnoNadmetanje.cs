using System.ComponentModel.DataAnnotations.Schema;

namespace KupacServis.Entities
{
    public class KupacJavnoNadmetanje
    {
        [ForeignKey("Kupac")]
        public Guid KupacId { get; set; }
        public Guid JavnoNadmetanjeId { get; set; }

        public Kupac Kupac { get; set; }
    }
}
