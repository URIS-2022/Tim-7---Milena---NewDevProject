using System.ComponentModel.DataAnnotations;

namespace KomisijaURIS.Entites
{
    public class Predsednik
    {
        [Key]
        public int PredsednikId { get; set; }
        public string ImePredsednika { get; set; }
        public string PrezimePredsednika { get; set; }
        public string EmailPredsednika { get; set; }
    }
}
