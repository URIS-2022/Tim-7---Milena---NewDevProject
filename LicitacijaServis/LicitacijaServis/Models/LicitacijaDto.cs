using LicitacijaServis.Models.Mock;
using System.Text.Json.Serialization;

namespace LicitacijaServis.Models
{
    public class LicitacijaDto
    {
        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int Broj { get; set; }
        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int Godina { get; set; }
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int Ogranicenje { get; set; }
        /// <summary>
        /// Korak cijene
        /// </summary>
        public int KorakCene { get; set; }
        /// <summary>
        /// Lista dokumenata fizickog lica za datu licitaciju
        /// </summary>
        public string? ListaDokumentacijeFizickaLica { get; set; }
        /// <summary>
        /// Lista dokumenata pravnog lica za datu licitaciju
        /// </summary>
        public string? ListaDokumentacijePravnaLica { get; set; }
        /// <summary>
        /// Rok 
        /// </summary>
        public DateTime Rok { get; set; }
        /// <summary>
        ///datum licitacije
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        /// Lista dto objekata javnog nadmetanja
        /// </summary>
        public List<JavnoNadmetanjeInfoDto>? JavnaNadmetanjaObj { get; set; } 
        /// <summary>
        /// Lista id javnog nadmetanja
        /// </summary>
        [JsonIgnore]
        public List<Guid>? JavnaNadmetanja { get; set; }
    }
}
