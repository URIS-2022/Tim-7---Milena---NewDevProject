namespace KupacServis.Models
{
    public class KupacInfoDto
    {
        /// <summary>
        /// Kupac Id
        /// </summary>
        public Guid KupacId { get; set; }
        /// <summary>
        /// Ostvarena povrsina kupca
        /// </summary>
        public int OstvarenaPovrsina { get; set; } 
        /// <summary>
        ///Da li kupac ima zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }
        
       
        /// <summary>
        /// Broj telefona kupca 
        /// </summary>
        public string BrTelefona1 { get; set; }
        /// <summary>
        /// Email kupca 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Broj racuna kupca 
        /// </summary>
        public string BrRacuna { get; set; }
    }
}
