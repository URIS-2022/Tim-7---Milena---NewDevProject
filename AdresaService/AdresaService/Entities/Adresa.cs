using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdresaService.Entities
{
    public class Adresa
    {
        /// <summary>
        /// ID adrese
        /// </summary>
        [Key]
        public Guid AdresaID { get; set; }
        /// <summary>
        /// ulica
        /// </summary>
        public string Ulica { get; set; }
        /// <summary>
        /// broj ulice
        /// </summary>
        public string Broj { get; set; }
        
        /// <summary>
        /// Mesto 
        /// </summary>
        public string Mesto { get; set; }
        /// <summary>
        /// postanski broj
        /// </summary>
        public string PostanskiBroj { get; set; }

        /// <summary>
        /// ID drzave
        /// </summary>
        [ForeignKey("Drzava")]
        public Guid DrzavaID { get; set; }
        /// <summary>
        /// Drzava
        /// </summary>
        public Drzava Drzava { get; set; }
        
    }
}
