namespace ZalbaService.Models
{
    public class StatusZalbeDto
    {
        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        public Guid StatusZalbeID { get; set; }
        /// <summary>
        /// Naziv statusa žalbe
        /// </summary>
        public string NazivStatusaZalbe { get; set; }
    }
}
