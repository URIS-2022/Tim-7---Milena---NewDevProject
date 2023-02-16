using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadmetanjeService.Entities
{
    public class JavnoNadmetanjeParcele
    {
        [ForeignKey("JavnoNadmetanje")]
        public Guid JavnoNadmetanjeID { get; set; }
        public int ParcelaID { get; set; }
        public JavnoNadmetanje JavnoNadmetanje { get; set; }
    }
}
