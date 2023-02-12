using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Zalba
{
    public class ZalbaCreationDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti datum podnošenja žalbe.")]
        public DateTime DatumPodnosenjaZalbe { get; set; }
        [Required(ErrorMessage = "Obavezno je uneti razlog žalbe.")]
        public string RazlogZalbe { get; set; }
        public string Obrazlozenje { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti datum broj nadmetanja na koje se odnosi žalba.")]
        public string BrojNadmetanja { get; set; }
        public DateTime DatumResenja { get; set; }
        public string BrojResenja { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id tipa žalbe.")]
        public Guid TipZalbeID { get; set; }
        [Required(ErrorMessage = "Obavezno je uneti id statusa žalbe.")]
        public Guid StatusZalbeID { get; set; }
        [Required(ErrorMessage = "Obavezno je id radnje na osnovu žalbe.")]
        public Guid RadnjaNaOsnovuZalbeID { get; set; }

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
