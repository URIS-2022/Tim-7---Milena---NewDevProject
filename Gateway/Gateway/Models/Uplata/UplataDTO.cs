namespace Gateway.Models.Uplata
{
    public class UplataDTO
    {
        public int Id { get; set; }

        public string BrojRacuna { get; set; }

        public string PozivNaBroj { get; set; }

        public string SvrhaUplate { get; set; }

        public int Iznos { get; set; }

        public DateTime Datum { get; set; }

        public int KursID { get; set; }

        //public Kupac Kupac { get; set; }

        //public JavnoNadmetanje JavnoNadmetanje { get; set; }
    }
}
