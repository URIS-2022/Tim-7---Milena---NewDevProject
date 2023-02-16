namespace Gateway.Models.Liciter
{
    public class KupacOvlascenoDto
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        public Guid KupacId { get; set; }
        /// <summary>
        /// Ostvarena povrsina kupca 
        /// </summary>
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Da li kupac ima zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }
        /// <summary>
        /// Datum pocetka zabrane
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }
        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }
        /// <summary>
        /// Trajanje zabrane u godinama 
        /// </summary>
        public int DuzinaTrajanjaZabraneUGod { get; set; }
        /// <summary>
        /// Broj telefona kupca 
        /// </summary>
        public string? BrTelefona1 { get; set; }
        /// <summary>
        /// Drugi broj telefona kupca 
        /// </summary>
        public string? BrTelefona2 { get; set; }
        /// <summary>
        /// Email kupca 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Broj racuna kupca 
        /// </summary>
        public string? BrRacuna { get; set; }
        /// <summary>
        /// Kolekcija Dto objekata ovlascenog lica datum kupca
        /// </summary>
        public ICollection<OvlascenoLiceDto>? OvlascenaLica { get; set; }
       

    }
}
