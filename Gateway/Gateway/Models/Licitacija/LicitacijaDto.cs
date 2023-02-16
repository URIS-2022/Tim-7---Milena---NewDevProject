using Gateway.Models.JavnoNadmetanje;
using System.Text.Json.Serialization;

namespace Gateway.Models.Licitacija
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
        /// Lista Dto objekata javnog nadmetanja
        /// </summary>
        public List<JavnoNadmetanjeDto>? JavnaNadmetanja { get; set; } //Moram kreirati JavnoNadmetanjeDto
        /// <summary>
        /// Lista id javnog nadmetanja
        /// </summary>
        [JsonIgnore]
        public List<Guid>? JavnaNadmetanjaId { get; set; }
    }
}
