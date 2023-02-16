using System.ComponentModel.DataAnnotations;

namespace Mikroservis_Uplata.Models
{
    public class Kurs
    {
        [Required]
        public int Id { get; set; }

        public DateTime Datum { get; set; }

        public string Valuta { get; set; }
    }
}
