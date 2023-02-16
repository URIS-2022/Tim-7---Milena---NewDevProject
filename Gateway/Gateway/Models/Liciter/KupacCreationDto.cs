using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Liciter
{
    public class KupacCreationDto : IValidatableObject
    {

        /// <summary>
        /// Id prioriteta kupca
        /// </summary>
        public Guid PrioritetId { get; set; }
        /// <summary>
        /// Ostvarena povrsina kupca
        /// </summary>
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Ima li kupac zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }
        /// <summary>
        /// Datum pocetka zabrane 
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DatumPocetkaZabrane { get; set; }
        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DatumPrestankaZabrane { get; set; }
        /// <summary>
        /// Duzina trajanja zabrane u godinama
        /// </summary>
        public int DuzinaTrajanjaZabraneUGod { get; set; }
        /// <summary>
        /// Broj telefona kupca 
        /// </summary>
        public string? BrTelefona1 { get; set; }
        /// <summary>
        /// Drugi broj telefona kupca
        /// </summary>
        public string? BrTelefona2 { get; set; }
        /// <summary>
        /// Email kupca
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Broj racuna kupca
        /// </summary>
        public string? BrRacuna { get; set; }
        /// <summary>
        /// Id adrese kupca
        /// </summary>
        public Guid AdresaId { get; set; }
        /// <summary>
        /// Lista kljuceva ovlascenih lica kupca
        /// </summary>
        public List<Guid>? OvlascenaLica { get; set; }
        /// <summary>
        /// Lista kljuceva javnih nadmetanja na kojima kupac ucestvuje
        /// </summary>
        public List<Guid>? JavnaNadmetanja { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BrRacuna!.Length ==0 )
            {
                yield return new ValidationResult(
                    "BrRacuna can not be empty ",
                    new[] { "KupacCreationDto" });
            }

            if (Email!.Length == 0)
            {
                yield return new ValidationResult(
                    "Email can not be empty.",
                    new[] { "KupacCreationDto" });
            }
        }





    }
}
