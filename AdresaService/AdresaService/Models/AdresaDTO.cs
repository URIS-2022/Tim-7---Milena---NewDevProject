namespace AdresaService.Models
{
    public class AdresaDTO
    {
        /// <summary>
        /// ID adrese
        /// </summary>
        public Guid AdresaID { get; set; }
        /// <summary>
        /// ulica
        /// </summary>
        public string Ulica { get; set; }
        /// <summary>
        /// broj ulice
        /// </summary>
        public string Broj { get; set; }
        /// <summary>
        /// Mesto 
        /// </summary>
        public string Mesto { get; set; }
        /// <summary>
        /// postanski broj
        /// </summary>
        public string PostanskiBroj { get; set; }
        /// <summary>
        /// ID drzave
        /// </summary>

        public Guid DrzavaID { get; set; }
    }
}
