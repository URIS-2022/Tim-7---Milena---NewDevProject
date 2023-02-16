
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacServis.Entities
{
    public class FizickoLice
    {
        [Key]
        public Guid FizickoLiceId { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string JMBG { get; set; }

        [ForeignKey(nameof(Kupac))]
        public Guid KupacId { get; set; }
    }
}
