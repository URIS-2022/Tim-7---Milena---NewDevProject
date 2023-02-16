using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Licitacija
{
    public class LicitacijaUpdateDto
    { 
        /// <summary>
        ///id licitacije
        /// </summary>
        public Guid LicitacijaId { get; set; }
        /// <summary>
        ///broj licitacije
        /// </summary>
        public int Broj { get; set; }
        /// <summary>
        /// godina licitacije
        /// </summary>
        public int Godina { get; set; }
        /// <summary>
        ///ogranicenje licitacije
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
        ///rok
        /// </summary>
        public DateTime Rok { get; set; }
        /// <summary>
        ///datum licitacije
        /// </summary>
        public DateTime Datum { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Broj < 1)
            {
                yield return new ValidationResult(
                    "The number has to be greater than 0.",
                    new[] { "LicitacijaUpdateDto" });
            }

            if (KorakCene < 1)
            {
                yield return new ValidationResult(
                    "The value for the increase of price has to be greater than 0.",
                    new[] { "LicitacijaUpdateDto" });
            }
        }
    }
}
