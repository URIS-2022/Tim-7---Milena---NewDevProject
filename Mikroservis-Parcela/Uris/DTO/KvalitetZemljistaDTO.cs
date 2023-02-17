using System.ComponentModel.DataAnnotations;
using Uris.Models;

namespace Uris.DTO
{
    public class KvalitetZemljistaDto
    {
        public int Id { get; set; }

        public string? NazivVrsteZemljista { get; set; }

        public Kvalitet Kvalitet { get; set; }
    }
}
