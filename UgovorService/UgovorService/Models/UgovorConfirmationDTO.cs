namespace UgovorService.Models
{
    public class UgovorConfirmationDto
    {
        /// <summary>
        /// ID ugovora
        /// </summary>
        public Guid UgovorID { get; set; }
        /// <summary>
        /// zavodni broj ugovora
        /// </summary>
        public string ZavodniBrojUgovora { get; set; }
        /// <summary>
        /// Datum zavodjenja
        /// </summary>
        public DateTime DatumZavodjenja { get; set; }
        /// <summary>
        /// Rok za vracanje zemljista
        /// </summary>
        public DateTime RokZaVracanjeZemljista { get; set; }
        /// <summary>
        /// Mesto potpisa
        /// </summary>
        public string MestoPotpisa { get; set; }
        /// <summary>
        /// Datum potpisa
        /// </summary>
        public DateTime DatumPotpisa { get; set; }
        /// <summary>
        /// ID tipa garancije
        /// </summary>
        public Guid TipGarancijeID { get; set; }
        /// <summary>
        /// ID dokumenta
        /// </summary>
        public Guid DokumentID { get; set; }
    }
}
