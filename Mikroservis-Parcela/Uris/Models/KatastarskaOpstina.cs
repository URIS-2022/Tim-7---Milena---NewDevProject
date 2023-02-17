using System.ComponentModel.DataAnnotations;

namespace Uris.Models
{
    public class KatastarskaOpstina
    {
        [Required]
        public int Id { get; set; }

        public string? Naziv { get; set; }

        public string? Okrug{ get; set; }
    }
}
