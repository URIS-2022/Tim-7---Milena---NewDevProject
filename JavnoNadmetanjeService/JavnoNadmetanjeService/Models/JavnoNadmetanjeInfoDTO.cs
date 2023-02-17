namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeInfoDto
    {
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public Guid JavnoNadmetanjeID { get; set; }
        /// <summary>
        ///  Datum održavanja javnog nadmetanja
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        ///  Vreme početka javnog nadmetanja
        /// </summary>
        public string VremePocetka { get; set; }
        /// <summary>
        ///  Vreme kraja javnog nadmetanja
        /// </summary>
        public string VremeKraja { get; set; }
        /// <summary>
        /// Početna cena po hektaru
        /// </summary>
        public int PocetnaCenaPoHektaru { get; set; }
        /// <summary>
        ///  Informacija o tome da li je javno nadmetanje izuzeto
        /// </summary>
        public bool Izuzeto { get; set; }
        /// <summary>
        /// Naziv tipa javnog nadmetanja
        /// </summary>
        public string TipJavnogNadmetanja { get; set; }
        /// <summary>
        /// Naziv statusa javnog nadmetanja
        /// </summary>
        public string StatusJavnogNadmetanja { get; set; }
        /// <summary>
        /// Izlicitirana cena
        /// </summary>
        public int IzlicitiranaCena { get; set; }
        /// <summary>
        /// Vremenski period zakupa
        /// </summary>
        public int PeriodZakupa { get; set; }
        /// <summary>
        /// Broj učesnika u javnom nadmetanju
        /// </summary>
        public int BrojUcesnika { get; set; }
        /// <summary>
        /// Visina dopune depozita
        /// </summary>
        public int VisinaDopuneDepozita { get; set; }
        /// <summary>
        /// Krug javnog nadmetanja 
        /// </summary>
        public int Krug { get; set; }
    }
}
