using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadmetanjeService.Entities
{
    public class JavnoNadmetanjePrijavljeniKupci
    {
        [ForeignKey("JavnoNadmetanje")]
        public Guid JavnoNadmetanjeID { get; set; }
        public Guid KupacID { get; set; }
        public JavnoNadmetanje JavnoNadmetanje { get; set; }
    }
}
