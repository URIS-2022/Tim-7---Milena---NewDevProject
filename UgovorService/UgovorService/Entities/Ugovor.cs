using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UgovorService.Entities
{
    public class Ugovor
    {
        /// <summary>
        /// ID ugovora
        /// </summary>
        [Key]
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
        [ForeignKey("TipGarancije")]
        public Guid TipGarancijeID { get; set; }
        /// <summary>
        /// Tip garancije
        /// </summary>
        public TipGarancije TipGarancije { get; set; }
        /// <summary>
        /// ID dokumenta
        /// </summary>
        [ForeignKey("Dokument")]
        public Guid DokumentID { get; set; }
        /// <summary>
        /// Dokument
        /// </summary>
        public Dokument Dokument { get; set; }
        
        public Guid? JavnoNadmetanjeID { get; set; }
        public Guid? KupacID { get; set; }
    }
}
