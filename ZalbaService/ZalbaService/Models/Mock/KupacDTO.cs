namespace ZalbaService.Models.Mock
{
    public class KupacDTO
    {
        public Guid KupacId { get; set; }
        public Guid PrioritetId { get; set; }

        public int OstvarenaPovrsina { get; set; }

        public bool ImaZabranu { get; set; }

        public DateTime? DatumPocetkaZabrane { get; set; }

        public DateTime? DatumPrestankaZabrane { get; set; }

        public int DuzinaTrajanjaZabraneUGod { get; set; }
        public string BrTelefona { get; set; }
        public string Email { get; set; }
        public string BrRacuna { get; set; }

    }
}
