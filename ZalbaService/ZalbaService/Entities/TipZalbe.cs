using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Entities
{
    public class TipZalbe
    {
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        [Key]
        public Guid TipZalbeID { get; set; }

        /// <summary>
        /// Naziv tipa žalbe
        /// </summary>
        public string NazivTipaZalbe { get; set; }

    }
}
