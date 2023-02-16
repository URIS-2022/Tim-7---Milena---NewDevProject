using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Entities
{
    public class TipJavnogNadmetanja
    {
        /// <summary>
        /// ID tipa javnog nadmetanja
        /// </summary>
        [Key]
        public Guid TipJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// Naziv tipa javnog nadmetanja
        /// </summary> 
        [Required]
        public string NazivTipaJavnogNadmetanja { get; set; }
    }
}
