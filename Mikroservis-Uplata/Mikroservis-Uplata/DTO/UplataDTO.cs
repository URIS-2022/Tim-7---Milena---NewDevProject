using System.Text.Json.Serialization;

namespace Mikroservis_Uplata.DTO
{
    public class UplataDto
    {
        public int Id { get; set; }

        public string? BrojRacuna { get; set; }

        public string? PozivNaBroj { get; set; }

        public string? SvrhaUplate { get; set; }

        public int Iznos { get; set; }

        public DateTime Datum { get; set; }

        public int KursID { get; set; }

        public KupacDto? KupacDTO { get; set; }

        [JsonIgnore]
        public Guid KupacId { get; set; }

        public JavnoNadmetanjeDto? JavnoNadmetanjeDTO { get; set; }

        [JsonIgnore]
        public Guid JavnoNadmetanjeId { get; set; }
    }
}
