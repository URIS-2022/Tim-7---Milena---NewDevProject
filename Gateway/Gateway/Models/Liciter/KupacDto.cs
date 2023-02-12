using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gateway.Models.Liciter
{
    public class KupacDto
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        public Guid KupacId { get; set; }
        
        /// <summary>
       /// Opis priosirteta kupca
       /// </summary>
        public string OpisPrioriteta { get; set; }
        /// <summary>
        /// Ostvarena povrsina
        /// </summary>
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        ///Da li kupac ima zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }
        /// <summary>
        /// Datum pocetka zabrane
        /// </summary>

        [DataType(DataType.Date)]
        public DateTime? DatumPocetkaZabrane { get; set; }
        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>

        [DataType(DataType.Date)]
        public DateTime? DatumPrestankaZabrane { get; set; }
        /// <summary>
        /// Duzina trajanja zabrane u godinama
        /// </summary>
        public int DuzinaTrajanjaZabraneUGod { get; set; }
        /// <summary>
        /// Broj telefona kupca 
        /// </summary>
        public string BrTelefona1 { get; set; }
        /// <summary>
        /// Drugi broj telefona kupca 
        /// </summary>
        public string BrTelefona2 { get; set; }
        /// <summary>
        /// Email kupca 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Broj racuna kupca 
        /// </summary>
        public string BrRacuna { get; set; }
        /// <summary>
        /// Dto objekat adrese
        /// </summary>
        [JsonIgnore]
        public Guid AdresaId { get; set; }
        public AdresaDto Adresa { get; set; }
        /// <summary>
        /// Dto objekat Pravnog lica
        /// </summary>
       
        public PravnoLiceDto PravnoLice { get; set; }
        /// <summary>
        /// Dto objekat fizickog lica
        /// </summary>
       
        public FizickoLiceDto FizickoLice { get; set; }


        /// <summary>
        /// Lista kljuceva javnog nadmetanja koja se ne prikazuje
        /// </summary>

        [JsonIgnore]
        public List<Guid> JavnaNadmetanja { get; set; }


        /// <summary>
        /// Lista dto objekata javnog nadmetanja
        /// </summary>
        public List<JavnoNadmetanjeInfoDto> JavnaNadmetanjaOb { get; set; }


        /// <summary>
        /// Lista dto objekata uplate
        /// </summary>
      
        public List<UplataDto> Uplate { get; set; }
        /// <summary>
        /// Lista uplata id
        /// </summary>

        [JsonIgnore]
        public List<Guid> UplateId { get; set; }
        /// <summary>
        /// Lista ovlasceno lice id
        /// </summary>

        [JsonIgnore]
        public List<Guid> OvlascenaLica { get; set; }

        /// <summary>
        /// Lista dto objekata ovlascenog lica
        /// </summary>
        public List<OvlascenoLiceInfoDto> OvlascenaLicaObj { get; set; }
       


    }
}
