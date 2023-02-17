namespace UgovorService.Models
{
    public class DokumentDto
    {
        /// <summary>
        /// ID dokumenta
        /// </summary>
        public Guid DokumentID { get; set; }
        /// <summary>
        /// Zavodni broj dokumenta
        /// </summary>
        public string ZavodniBroj { get; set; }
        /// <summary>
        /// Datum
        /// </summary>

        public DateTime Datum { get; set; }
        /// <summary>
        /// Datum donosenja
        /// </summary>
        public DateTime DatumDonosenja { get; set; }
        /// <summary>
        /// Sablon
        /// </summary>
        public string Sablon { get; set; }
        
    }
}
