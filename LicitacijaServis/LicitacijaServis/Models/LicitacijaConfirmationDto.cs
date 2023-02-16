using LicitacijaServis.Models.Mock;
using System.Text.Json.Serialization;

namespace LicitacijaServis.Models
{
    public class LicitacijaConfirmationDto
    {
        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int Broj { get; set; }
        
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int Ogranicenje { get; set; }
        /// <summary>
        /// Korak cijene
        /// </summary>
        public int KorakCene { get; set; }
      
        /// <summary>
        /// Rok 
        /// </summary>
        public DateTime Rok { get; set; }
        /// <summary>
        ///datum licitacije
        /// </summary>
        public DateTime Datum { get; set; }
       
        
        
       
    }
}
