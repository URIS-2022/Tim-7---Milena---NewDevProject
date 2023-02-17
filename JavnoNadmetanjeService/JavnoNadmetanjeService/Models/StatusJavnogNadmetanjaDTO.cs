namespace JavnoNadmetanjeService.Models
{
    public class StatusJavnogNadmetanjaDto
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
