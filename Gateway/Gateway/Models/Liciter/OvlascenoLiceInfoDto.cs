namespace Gateway.Models.Liciter
{
    public class OvlascenoLiceInfoDto
    {
        /// <summary>
        /// Id ovlascenog lica
        /// </summary>
        public Guid OvlascenoLiceId { get; set; }
        /// <summary>
        /// Ime ovlascenog lica
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime ovlascenog lica
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Jmbg ovlascenog lica
        /// </summary>
        public string Jmbg { get; set; }
        
        /// <summary>
        /// Broj table ovlascenog lica
        /// </summary>
        public int BrTable { get; set; }
    }
}
