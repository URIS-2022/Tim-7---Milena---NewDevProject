using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeDTO
    {
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public Guid JavnoNadmetanjeID { get; set; }
        /// <summary>
        ///  Datum održavanja javnog nadmetanja
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        ///  Vreme početka javnog nadmetanja
        /// </summary>
        public string VremePocetka { get; set; }
        /// <summary>
        ///  Vreme kraja javnog nadmetanja
        /// </summary>
        public string VremeKraja { get; set; }
        /// <summary>
        /// Početna cena po hektaru
        /// </summary>
        public int PocetnaCenaPoHektaru { get; set; }
        /// <summary>
        ///  Informacija o tome da li je javno nadmetanje izuzeto
        /// </summary>
        public bool Izuzeto { get; set; }
        /// <summary>
        /// Naziv tipa javnog nadmetanja
        /// </summary>
        public string TipJavnogNadmetanja { get; set; }
        /// <summary>
        /// Naziv statusa javnog nadmetanja
        /// </summary>
        public string StatusJavnogNadmetanja{ get; set; }
        /// <summary>
        /// Izlicitirana cena
        /// </summary>
        public int IzlicitiranaCena { get; set; }
        /// <summary>
        /// Vremenski period zakupa 
        /// </summary>
        public int PeriodZakupa { get; set; }

        /// <summary>
        /// Broj učesnika u javnom nadmetanju
        /// </summary>
        public int BrojUcesnika { get; set; }
        /// <summary>
        /// Visina dopune depozita
        /// </summary>
        public int VisinaDopuneDepozita { get; set; }
        /// <summary>
        /// Krug javnog nadmetanja 
        /// </summary>
        public int Krug { get; set; }
        [JsonIgnore]
        public List<Guid> LicitantiID { get; set; }
        /// <summary>
        /// Lista ovlascenih lica(licitanata)
        /// </summary>
        public List<OvlascenoLiceInfoDto> Licitanti { get; set; }
        [JsonIgnore]
        public List<Guid> PrijavljeniKupciID { get; set; }
        /// <summary>
        /// Lista prijavljenih kupaca
        /// </summary>
        public List<KupacInfoDto> PrijavljeniKupci { get; set; }
        [JsonIgnore]
        public List<int> ParceleID { get; set; }
        /// <summary>
        /// Lista parcela
        /// </summary>
        public List<ParcelaInfoDto> Parcele { get; set; }
        [JsonIgnore]
        public Guid AdresaID { get; set; }
        /// <summary>
        /// Adresa javnog nadmetanja
        /// </summary>
        public AdresaDTO Adresa { get; set; }
        [JsonIgnore]
        public Guid KupacID { get; set; }
        /// <summary>
        /// Kupac koji je dostavio najbolju ponudu
        /// </summary>
        public KupacInfoDto NajboljiPonudjac { get; set; }

    }
}
