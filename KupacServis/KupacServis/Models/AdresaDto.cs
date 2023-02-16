namespace KupacServis.Models
{
    public class AdresaDto
    {
        /// <summary>
        /// Id adrese
        /// </summary>
        public Guid AdresaID { get; set; }
        /// <summary>
        /// Naziv ulice
        /// </summary>
        public string Ulica { get; set; }
        /// <summary>
        /// Broj
        /// </summary>
        public string Broj { get; set; }
        /// <summary>
        /// Mjesto
        /// </summary>
        public string Mesto { get; set; }
        /// <summary>
        /// Postanski broj
        /// </summary>
        public string PostanskiBroj { get; set; }
        /// <summary>
        ///ID drzave
        /// </summary>
        public Guid DrzavaID { get; set; }

    }
}
