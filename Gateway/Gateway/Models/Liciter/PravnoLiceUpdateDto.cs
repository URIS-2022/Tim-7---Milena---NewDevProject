namespace Gateway.Models.Liciter
{
    public class PravnoLiceUpdateDto
    {
        /// <summary>
        /// Id pravnog lica
        /// </summary>
        public Guid PravnoLiceId { get; set; }
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string? Naziv { get; set; }
        /// <summary>
        /// Maticni broj pravnog lica
        /// </summary>
        public string? MaticniBroj { get; set; }
        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        public string? Faks { get; set; }
        
        public Guid KupacId { get; set; }
    }
}
