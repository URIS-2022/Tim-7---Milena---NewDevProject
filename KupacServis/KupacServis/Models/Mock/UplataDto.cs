namespace KupacServis.Models.Mock
{
    public class UplataDto
    {
        /// <summary>
        /// Id uplate
        /// </summary>
        public Guid UplataId { get; set; }
        /// <summary>
        /// Broj racuna
        /// </summary>
        public string BrojRacuna { get; set; }
        /// <summary>
        /// Poziv na broj
        /// </summary>
        public string PozivNaBroj { get; set; }
        /// <summary>
        /// Iznos uplate
        /// </summary>
        public decimal Iznos { get; set; }
        /// <summary>
        /// Svrha uplate
        /// </summary>
        public string SvrhaUplate { get; set; }
        /// <summary>
        /// Datum uplate
        /// </summary>

        public DateTime Datum { get; set; }
    }
}
