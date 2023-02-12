using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Liciter
{
    public class FizickoLiceCreationDto : IValidatableObject
    {
        /// <summary>
        /// Ime fizickog lica
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime fizickog lica
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// JMBG fizickog lica
        /// </summary>
        public string JMBG { get; set; }
        /// <summary>
        /// id kupca
        /// </summary>
        public Guid KupacId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ime.Length == 0)
            {
                yield return new ValidationResult(
                    "Ime can not be empty.",
                    new[] { "LicitacijaCreationDto" });
            }

            if (JMBG.Length == 0)
            {
                yield return new ValidationResult(
                    "JMBG can not be empty.",
                    new[] { "LicitacijaCreationDto" });
            }
        }
    }
}
