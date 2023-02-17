namespace JavnoNadmetanjeService.Models
{
    public class AdresaDto
    {
        /// <summary>
        /// ID adrese
        /// </summary>
        public Guid AdresaID { get; set; }
        /// <summary>
        /// Naziv ulice
        /// </summary>
        public string Ulica { get; set; }
        /// <summary>
        ///Broj ulice
        /// </summary>
        public string Broj { get; set; }
        /// <summary>
        /// Naziv mesta
        /// </summary>
        public string Mesto { get; set; }
        /// <summary>
        /// Postanski broj
        /// </summary>
        public string PostanskiBroj { get; set; }
        /// <summary>
        /// ID države
        /// </summary>
        public Guid DrzavaID { get; set; }
    }
}
