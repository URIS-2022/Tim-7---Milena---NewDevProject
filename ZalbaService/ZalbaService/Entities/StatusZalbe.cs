using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Entities
{
    public class StatusZalbe
    {

        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        [Key]
        public Guid StatusZalbeID { get; set; }
        /// <summary>
        /// Naziv statusa žalbe
        /// </summary>
        public string NazivStatusaZalbe { get; set; }

    }
}
