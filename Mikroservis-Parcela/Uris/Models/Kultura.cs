using System.ComponentModel.DataAnnotations;

namespace Uris.Models
{
    public class Kultura
    {
        [Required]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Kategorija { get; set; }
    }
}
