using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KupacServis.Models
{
    public class PravnoLiceDto
    {


        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string Naziv { get; set; }
        /// <summary>
        /// Maticni broj pravnog lica
        /// </summary>
        public string MaticniBroj { get; set; }
        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        public string Faks { get; set; }
      
    }
}
