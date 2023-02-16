using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mikroservis_Uplata.DTO;

namespace Mikroservis_Uplata.Models
{
    public class Uplata
    {
        [Required]
        public int Id { get; set; }

        public string BrojRacuna { get; set; }

        public string PozivNaBroj { get; set; }

        public string SvrhaUplate { get; set; }

        public int Iznos { get; set; }

        public DateTime Datum { get; set; }

        public Kurs Kurs { get; set; }

        [ForeignKey("Kurs")]
        public int KursID { get; set; }

        public Guid KupacId { get; set; }

        public Guid JavnoNadmetanjeId { get; set; }
    }
}
