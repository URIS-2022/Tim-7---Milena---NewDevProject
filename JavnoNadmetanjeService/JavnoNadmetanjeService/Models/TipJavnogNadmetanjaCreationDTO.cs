using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Models
{
    public class TipJavnogNadmetanjaCreationDto
    {
        /// <summary>
        /// Naziv tipa javnog nadmetanja
        /// </summary> 
        [Required(ErrorMessage = "Obavezno je uneti naziv tipa.")]
        public string NazivTipaJavnogNadmetanja { get; set; }
    }
}
