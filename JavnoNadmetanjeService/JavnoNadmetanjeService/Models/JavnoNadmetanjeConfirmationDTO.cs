namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeConfirmationDTO
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
        /// Broj učesnika u javnom nadmetanju
        /// </summary>
        public int BrojUcesnika { get; set; }
    }
}
