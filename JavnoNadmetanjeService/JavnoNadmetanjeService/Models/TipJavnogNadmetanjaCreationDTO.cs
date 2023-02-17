using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Models
{
    public class TipJavnogNadmetanjaCreationDTO
    {
        /// <summary>
        /// Naziv tipa javnog nadmetanja
        /// </summary> 
        [Required(ErrorMessage = "Obavezno je uneti naziv tipa.")]
        public string NazivTipaJavnogNadmetanja { get; set; }
    }
}
