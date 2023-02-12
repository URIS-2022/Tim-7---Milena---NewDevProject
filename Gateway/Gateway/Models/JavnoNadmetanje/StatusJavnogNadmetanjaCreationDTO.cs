using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.JavnoNadmetanje
{
    public class StatusJavnogNadmetanjaCreationDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv statusa.")]
        public string NazivStatusaJavnogNadmetanja { get; set; }
    }
}
