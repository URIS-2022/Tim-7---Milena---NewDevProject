using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Liciter
{
    public class PravnoLiceCreationDto : IValidatableObject
    {
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string? Naziv { get; set; }
        /// <summary>
        /// Maticni broj pravnog lica
        /// </summary>
        public string? MaticniBroj { get; set; }
          /// <summary>
        /// Faks pravnog lica
        /// </summary>
        public string? Faks { get; set; }
        /// <summary>
        /// Id kupca koji je pravno lice
        /// </summary>
        public Guid KupacId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Naziv!.Length ==0)
            {
                yield return new ValidationResult(
                    "Naziv can not be empty.",
                    new[] { "LicitacijaCreationDto" });
            }

            if ( MaticniBroj!.Length == 0)
            {
                yield return new ValidationResult(
                    "MaticniBroj can not be empty.",
                    new[] { "LicitacijaCreationDto" });
            }
        }
    }
}
