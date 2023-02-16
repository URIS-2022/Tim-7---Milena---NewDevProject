namespace KupacServis.Models
{
    public class JavnoNadmetanjeInfoDto
    {
        public Guid JavnoNadmetanjeID { get; set; }
        public DateTime Datum { get; set; }
        public string VremePocetka { get; set; }
        public string VremeKraja { get; set; }
        public int PocetnaCenaPoHektaru { get; set; }
        public bool Izuzeto { get; set; }
        public string TipJavnogNadmetanja { get; set; }
        public string StatusJavnogNadmetanja { get; set; }
        public int IzlicitiranaCena { get; set; }
        public int PeriodZakupa { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }
        public int Krug { get; set; }
    }
}
