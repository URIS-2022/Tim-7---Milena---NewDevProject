using ZalbaService.Models.Mock;
using System.Text.Json.Serialization;

namespace ZalbaService.Models
{
    public class ZalbaDTO
    {
        /// <summary>
        /// ID žalbe
        /// </summary>
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
        /// Tip žalbe
        /// </summary>
        public string TipZalbe { get; set; }
        /// <summary>
        /// Status žalbe
        /// </summary>
        public string StatusZalbe { get; set; }
        /// <summary>
        /// Radnja na osnovu žalbe
        /// </summary>
        public string RadnjaNaOsnovuZalbe { get; set; }
        /// <summary>
        /// Id podnosioca žalbe(kupca)
        /// </summary>
        [JsonIgnore]
        public Guid PodnosilacZalbeID { get; set; }
        /// <summary>
        /// Objekat podnosioca žalbe(kupca)
        /// </summary>
        public KupacInfoDto Kupac { get; set; }

    }
}
