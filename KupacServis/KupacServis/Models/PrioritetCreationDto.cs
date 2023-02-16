using System.ComponentModel.DataAnnotations;

namespace KupacServis.Models
{
    public class PrioritetCreationDto : IValidatableObject
    {
        /// <summary>
        /// Opis prioriteta
        /// </summary>
        public string OpisPrioriteta { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OpisPrioriteta.Length == 0)
            {
                yield return new ValidationResult(
                    "OpisPrioriteta can not be empty.",
                    new[] { "PrioritetCreationDto" });
            }

            
        }
    }
}
