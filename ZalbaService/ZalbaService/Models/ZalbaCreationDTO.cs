using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Models
{
    public class ZalbaCreationDTO:IValidatableObject
    {
        /// <summary>
        /// Datum podnošenja žalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum podnošenja žalbe.")]
        public DateTime DatumPodnosenjaZalbe { get; set; }
        /// <summary>
        /// Razlog žalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti razlog žalbe.")]
        public string RazlogZalbe { get; set; }
        /// <summary>
        /// Obrazloženje
        /// </summary>
        public string Obrazlozenje { get; set; }
        /// <summary>
        /// Broj nadmetanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum broj nadmetanja na koje se odnosi žalba.")]
        public string BrojNadmetanja { get; set; }
        /// <summary>
        /// Datum resenja žalbe
        /// </summary>
        public DateTime DatumResenja { get; set; }
        /// <summary>
        /// Broj rešenja
        /// </summary>
        public string BrojResenja { get; set; }
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id tipa žalbe.")]
        public Guid TipZalbeID { get; set; }
        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id statusa žalbe.")]
        public Guid StatusZalbeID { get; set; }
        /// <summary>
        /// ID radnje na osnovu žalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id radnje na osnovu žalbe.")]
        public Guid RadnjaNaOsnovuZalbeID { get; set; }
        /// <summary>
        /// ID podnosioca žalbe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id podnosioca žalbe.")]
        public Guid PodnosilacZalbeID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DatumPodnosenjaZalbe > DatumResenja)
            {
                yield return new ValidationResult(
                    "Datum podnošenja žalbe ne može biti posle datuma rešenja!",
                    new[] { "ZalbaCreationDTO" });
            }
        }
    }
}
