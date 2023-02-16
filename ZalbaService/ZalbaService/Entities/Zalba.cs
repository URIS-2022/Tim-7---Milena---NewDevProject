using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZalbaService.Models.Mock;

namespace ZalbaService.Entities
{
    public class Zalba
    {
        /// <summary>
        /// ID žalbe
        /// </summary>
        [Key]
        public Guid ZalbaID { get; set; }
        /// <summary>
        /// Datum podnošenja žalbe
        /// </summary>
        public DateTime DatumPodnosenjaZalbe { get; set; }
        /// <summary>
        /// Razlog žalbe
        /// </summary>
        public string RazlogZalbe { get; set; }
        /// <summary>
        /// Obrazloženje
        /// </summary>
        public string Obrazlozenje { get; set; }
        /// <summary>
        /// Broj nadmetanja
        /// </summary>
        public string BrojNadmetanja { get; set; }
        /// <summary>
        /// Datum resenja žalbe
        /// </summary>
        public DateTime DatumResenja { get; set; }
        /// <summary>
        /// Broj rešenja
        /// </summary>
        public string BrojResenja { get; set; }
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        [ForeignKey("TipZalbe")]
        public Guid TipZalbeID { get; set; }
        /// <summary>
        /// Tip žalbe
        /// </summary>
        public TipZalbe TipZalbe { get; set; }
        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        [ForeignKey("StatusZalbe")]
        public Guid StatusZalbeID { get; set; }
        /// <summary>
        /// Status žalbe
        /// </summary>
        public StatusZalbe StatusZalbe { get; set; }
        /// <summary>
        /// ID radnje na osnovu žalbe
        /// </summary>
        [ForeignKey("RadnjaNaOsnovuZalbe")]
        public Guid RadnjaNaOsnovuZalbeID { get; set; }
        /// <summary>
        /// Dogadjaj na osnovu zalbe
        /// </summary>
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
        /// <summary>
        /// Id podnosioca žalbe(kupca)
        /// </summary>
        public Guid? PodnosilacZalbeID { get; set; }
    }
}
