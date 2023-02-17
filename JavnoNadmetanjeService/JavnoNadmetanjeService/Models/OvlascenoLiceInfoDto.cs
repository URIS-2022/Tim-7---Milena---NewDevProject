namespace JavnoNadmetanjeService.Models
{
    public class OvlascenoLiceInfoDto
    {
        /// <summary>
        /// ID ovlaščenog lica
        /// </summary> 
        public Guid OvlascenoLiceId { get; set; }
        /// <summary>
        /// Ime ovlašćenog lica
        /// </summary> 
        public string Ime { get; set; }
        /// <summary>
        /// Prezime ovlašćenog lica
        /// </summary> 
        public string Prezime { get; set; }
        /// <summary>
        /// Jmbg ovlašćenog lica
        /// </summary> 
        public string Jmbg { get; set; }
        /// <summary>
        /// Broj table
        /// </summary> 
        public int BrTable { get; set; }
    }
}
