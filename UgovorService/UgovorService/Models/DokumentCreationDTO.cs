using System.ComponentModel.DataAnnotations;

namespace UgovorService.Models
{
    public class DokumentCreationDto
    {
        /// <summary>
        /// Zavodni broj dokumenta
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti zavodni broj.")]
        public string ZavodniBroj { get; set; }
        /// <summary>
        /// Datum
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum.")]
        public DateTime Datum { get; set; }
        /// <summary>
        /// Datum donosenja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum donosenja.")]
        public DateTime DatumDonosenja { get; set; }
        /// <summary>
        /// Sablon
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti sablon.")]
        public string Sablon { get; set; }

    }
}
