using Newtonsoft.Json;

namespace OglasURIS.DTO
{
    /// <summary>
    /// Predstavlja model oglasa
    /// </summary>
    public class OglasDto
    {
        /// <summary>
        /// Id oglasa
        /// </summary>
        public int OglasId { get; set; }

        /// <summary>
        /// Datum objave oglasa
        /// </summary>
        public DateTime DatumObjave { get; set; }

        /// <summary>
        /// Rok za žalbu na oglas
        /// </summary>
        public DateTime RokZaZalbu { get; set; }

        /// <summary>
        /// Opis oglasa
        /// </summary>
        public string OpisOglasa { get; set; }

        /// <summary>
        /// Id službenog lista u kom je objavljen oglas
        /// </summary>
        public int ObjavljenUListuId { get; set; }

        [JsonIgnore]
        public Guid JavnoNadmetanjeId { get; set; }

        
        public JavnoNadmetanjeInfoDto JavnoNadmetanje { get; set; }

    }
}
