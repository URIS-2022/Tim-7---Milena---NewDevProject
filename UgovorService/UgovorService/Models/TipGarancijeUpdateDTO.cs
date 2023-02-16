namespace UgovorService.Models
{
    public class TipGarancijeUpdateDTO
    {
        /// <summary>
        /// ID tipa garancije
        /// </summary>
        public Guid TipGarancijeID { get; set; }
        /// <summary>
        /// Naziv tipa garancije
        /// </summary>
        public string NazivTipaG { get; set; }
    }
}
