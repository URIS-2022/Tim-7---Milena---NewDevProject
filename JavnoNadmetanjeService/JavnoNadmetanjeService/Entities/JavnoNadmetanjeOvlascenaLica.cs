using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadmetanjeService.Entities
{
    public class JavnoNadmetanjeOvlascenaLica
    {
        [ForeignKey("JavnoNadmetanje")]
        public Guid JavnoNadmetanjeID { get; set; }
        public Guid OvlascenoLiceID { get; set; }
        public JavnoNadmetanje JavnoNadmetanje { get; set; }
    }
}
