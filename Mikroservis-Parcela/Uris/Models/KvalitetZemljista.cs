using System.ComponentModel.DataAnnotations;

namespace Uris.Models
{
    public class KvalitetZemljista
    {
        [Required]
        public int Id { get; set; }

        public string? NazivVrsteZemljista { get; set; }

        public Kvalitet Kvalitet { get; set; }
    }

    public enum Kvalitet
    {
        Nizak, Srednji, Visok
    }
}
