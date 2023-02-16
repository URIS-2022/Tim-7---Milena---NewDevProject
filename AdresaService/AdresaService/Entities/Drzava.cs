using System.ComponentModel.DataAnnotations;

namespace AdresaService.Entities
{
    public class Drzava
    {
        /// <summary>
        /// ID drzave
        /// </summary>
        [Key]
        public Guid DrzavaID { get; set; }

        /// <summary>
        /// Naziv drzave
        /// </summary>
        public string NazivDrzave { get; set; }
    }
}
