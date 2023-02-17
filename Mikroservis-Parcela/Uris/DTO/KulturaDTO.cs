using System.ComponentModel.DataAnnotations;

namespace Uris.DTO
{
    public class KulturaDto
    {
        public int Id { get; set; }

        public string? Naziv { get; set; }

        public string? Kategorija { get; set; }
    }
}
