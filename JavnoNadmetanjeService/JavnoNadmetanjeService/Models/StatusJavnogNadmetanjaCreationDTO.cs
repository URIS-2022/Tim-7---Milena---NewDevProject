using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Models
{
    public class StatusJavnogNadmetanjaCreationDto
    {
        /// <summary>
        /// Naziv statusa javnog nadmetanja
        /// </summary> 
        [Required(ErrorMessage = "Obavezno je uneti naziv statusa.")]
        public string NazivStatusaJavnogNadmetanja { get; set; }
    }
}
