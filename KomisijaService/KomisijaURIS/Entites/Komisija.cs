using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KomisijaURIS.Entites
{
    public class Komisija
    {
        [Key]
        public int KomisijaId { get; set; }

        
        public Predsednik Predsednik { get; set; }

        public List<ClanKomisije> Clan { get; set; }
        
    }
}
