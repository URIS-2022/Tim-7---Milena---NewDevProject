using System.ComponentModel.DataAnnotations;

namespace AdresaService.Models
{
    public class AdresaCreationDto
    {
        /// <summary>
        /// ulica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ulicu.")]
        public string Ulica { get; set; }
        /// <summary>
        /// broj ulice
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj ulice.")]

        public string Broj { get; set; }
        /// <summary>
        /// Mesto 
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto.")]
        public string Mesto { get; set; }
        /// <summary>
        /// postanski broj
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti postanski broj.")]
        public string PostanskiBroj { get; set; }
        /// <summary>
        /// ID drzave
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti id drzave.")]
        public Guid DrzavaID { get; set; }
    }
}
