namespace ZalbaService.Models
{
    public class StatusZalbeDTO
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
