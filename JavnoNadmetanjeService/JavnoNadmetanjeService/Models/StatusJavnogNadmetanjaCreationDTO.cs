using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Models
{
    public class StatusJavnogNadmetanjaCreationDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv statusa.")]
        public string NazivStatusaJavnogNadmetanja { get; set; }
    }
}
