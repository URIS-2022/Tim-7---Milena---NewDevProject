using System.ComponentModel.DataAnnotations;

namespace UgovorService.Entities
{
    public class TipGarancije
    {
        /// <summary>
        /// ID tipa garancije
        /// </summary>
        [Key]
        public Guid TipGarancijeID { get; set; }

        /// <summary>
        /// Naziv tipa garancije
        /// </summary>
        public string NazivTipaG { get; set; }
    }
}
