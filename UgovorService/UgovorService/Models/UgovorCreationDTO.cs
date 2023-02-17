using System.ComponentModel.DataAnnotations;

namespace UgovorService.Models
{
    public class UgovorCreationDto
    {
        /// <summary>
        /// zavodni broj ugovora
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti zavodni broj ugovora.")]
        public string ZavodniBrojUgovora { get; set; }
        /// <summary>
        /// Datum zavodjenja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum zavodjenja.")]
        public DateTime DatumZavodjenja { get; set; }
        /// <summary>
        /// Rok za vracanje zemljista
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti rok za vracanje zemljista.")]
        public DateTime RokZaVracanjeZemljista { get; set; }
        /// <summary>
        /// Mesto potpisa
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti mesto potpisa.")]
        public string MestoPotpisa { get; set; }
        /// <summary>
        /// Datum potpisa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum potpisa.")]
        public DateTime DatumPotpisa { get; set; }

        /// <summary>
        /// ID tipa garancije
        /// </summary>


        [Required(ErrorMessage = "Obavezno je uneti id tipa garancije.")]
        public Guid TipGarancijeID { get; set; }

        /// <summary>
        /// ID dokumenta
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id dokumenta.")]
        public Guid DokumentID { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>

        public Guid KupacID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public Guid JavnoNadmetanjeID { get; set; }

    }
}
