namespace JavnoNadmetanjeService.Models
{
    public class StatusJavnogNadmetanjaDTO
    {
        /// <summary>
        /// ID statusa javnog nadmetanja
        /// </summary> 
        public Guid StatusJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// Naziv statusa javnog nadmetanja
        /// </summary> 
        public string NazivStatusaJavnogNadmetanja { get; set; }
    }
}
