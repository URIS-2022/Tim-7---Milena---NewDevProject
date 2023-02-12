using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Liciter
{
    public class OvlascenoLiceCreationDto : IValidatableObject
    {
        /// <summary>
        /// Ime ovlascenog lica
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime ovlascenog lica
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Jmbg ovlascenog lica
        /// </summary>
        public string Jmbg { get; set; }
        /// <summary>
        /// Id adrese ovlascenog lica
        /// </summary>
        public Guid? AdresaId { get; set; }
        /// <summary>
        /// Id drzave ovlascenog lica
        /// </summary>
        public Guid? DrzavaId { get; set; }
        /// <summary>
        /// Broj table ovlascenog lica
        /// </summary>
        public int BrTable { get; set; }

       public List<Guid> Kupci { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ime.Length == 0)
            {
                yield return new ValidationResult(
                    "Ime can not be empty",
                    new[] { "OvlascenoLiceCreationDto" });
            }

            if (Prezime.Length == 0)
            {
                yield return new ValidationResult(
                    "Prezime can not be empty.",
                    new[] { "OvlascenoLiceCreationDto" });
            }
        }


    }
}
