using System.ComponentModel.DataAnnotations;

namespace LicitacijaServis.Models
{
    public class LicitacijaCreationDto:IValidatableObject
    {

        /// <summary>
        /// Broj licitacije
        /// </summary>
        [Required]
        public int Broj { get; set; }
        /// <summary>
        /// Godina licitacije
        /// </summary>

        public int Godina { get; set; }
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int Ogranicenje { get; set; }
        /// <summary>
        /// korak cijene
        /// </summary>
        public int KorakCene { get; set; }
        /// <summary>
        /// Lista dokumenata fizickog lica za datu licitaciju
        /// </summary>
        public string? ListaDokumentacijeFizickaLica { get; set; }
        /// <summary>
        /// Lista dokumenata pravnog lica za datu licitaciju
        /// </summary>
        public string? ListaDokumentacijePravnaLica { get; set; }
        /// <summary>
        /// rok
        /// </summary>
        public DateTime Rok { get; set; }
        /// <summary>
        /// datum licitacije
        /// </summary>
        public DateTime Datum { get; set; }

        public List<Guid>? JavnaNadmetanja { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Broj < 1)
            {
                yield return new ValidationResult(
                    "The number has to be greater than 0.",
                    new[] { "LicitacijaCreationDto" });
            }

            if (KorakCene < 1)
            {
                yield return new ValidationResult(
                    "The value for the increase of price has to be greater than 0.",
                    new[] { "LicitacijaCreationDto" });
            }
        }
    }
}
