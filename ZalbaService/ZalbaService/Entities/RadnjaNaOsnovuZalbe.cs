using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Entities
{
    public class RadnjaNaOsnovuZalbe
    {

        /// <summary>
        /// ID radnje na osnovu žalbe
        /// </summary>
        [Key]
        public Guid RadnjaNaOsnovuZalbeID { get; set; }

        /// <summary>
        /// Naziv radnje na osnovu žalbe
        /// </summary>
        public string NazivRadnjeNaOsnovuZalbe { get; set; }
    }
}
