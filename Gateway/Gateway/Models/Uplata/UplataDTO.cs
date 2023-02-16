using Gateway.Models.JavnoNadmetanje;
using Gateway.Models.Liciter;

namespace Gateway.Models.Uplata
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

        public KupacDto? Kupac { get; set; }

        public JavnoNadmetanjeDto? JavnoNadmetanje { get; set; }
    }
}
