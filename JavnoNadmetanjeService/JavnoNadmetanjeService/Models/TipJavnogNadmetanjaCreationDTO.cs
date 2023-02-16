using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Models
{
    public class TipJavnogNadmetanjaCreationDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv tipa.")]
        public string NazivTipaJavnogNadmetanja { get; set; }
    }
}
