namespace Gateway.Models.Liciter
{
    public class FizickoLiceDto
    {
        /// <summary>
        /// Fizicko lice id
        /// </summary>
        public Guid FizickoLiceId { get; set; }
        /// <summary>
        /// Ime fizickog lica
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime fizickog lica
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// JMBG fizickog lica
        /// </summary>
        public string JMBG { get; set; }
       
    }
}
