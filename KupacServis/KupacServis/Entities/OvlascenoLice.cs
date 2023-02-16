using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacServis.Entities
{
    public class OvlascenoLice
    {
        [Key]
        public Guid OvlascenoLiceId { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string Jmbg { get; set; }

        public Guid? AdresaId { get; set; }

        public Guid? DrzavaId { get; set; }

        public int BrTable { get; set; }

        [NotMapped]
        public List<Guid>? Kupci { get; set; }
    }
}
