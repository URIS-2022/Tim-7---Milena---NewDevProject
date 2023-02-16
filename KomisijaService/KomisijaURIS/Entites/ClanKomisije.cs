using System.ComponentModel.DataAnnotations;

namespace KomisijaURIS.Entites
{
    public class ClanKomisije
    {
        [Key]
        public int ClanId { get; set; }
        public string ImeClana { get; set; }
        public string PrezimeClana { get; set; }
        public string EmailClana { get; set; }
    }
}
