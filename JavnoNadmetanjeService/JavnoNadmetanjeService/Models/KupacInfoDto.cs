namespace JavnoNadmetanjeService.Models
{
    public class KupacInfoDto
    {
        /// <summary>
        /// ID kupca
        /// </summary> 
        public Guid KupacId { get; set; }
        /// <summary>
        /// Ostvarena površina
        /// </summary> 
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Da li kupac ima zabranu?
        /// </summary> 
        public bool ImaZabranu { get; set; }
        /// <summary>
        /// broj telefona kupca
        /// </summary> 
        public string BrTelefona1 { get; set; }
        /// <summary>
        /// E-mail kupca
        /// </summary> 
        public string Email { get; set; }
        /// <summary>
        /// Broj računa kupca
        /// </summary> 
        public string BrRacuna { get; set; }
    }
}
