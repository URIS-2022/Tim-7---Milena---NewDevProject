using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace KupacServis.Entities
{
    public class PravnoLice
    {
        [Key ]
        public Guid PravnoLiceId { get; set; }  

        public string Naziv { get; set; }   

        public string MaticniBroj { get; set; }

        public string Faks { get; set; }

        [ForeignKey(nameof(Kupac))]
        public Guid KupacId { get; set; }

    }
}
