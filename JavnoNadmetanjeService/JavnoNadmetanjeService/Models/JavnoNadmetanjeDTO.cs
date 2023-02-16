using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeDTO
    {
        public Guid JavnoNadmetanjeID { get; set; }
        public DateTime Datum { get; set; }
        public string VremePocetka { get; set; }
        public string VremeKraja { get; set; }
        public int PocetnaCenaPoHektaru { get; set; }
        public bool Izuzeto { get; set; }
        public string TipJavnogNadmetanja { get; set; }
        public string StatusJavnogNadmetanja{ get; set; }
        public int IzlicitiranaCena { get; set; }
        public int PeriodZakupa { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }
        public int Krug { get; set; }
        [JsonIgnore]
        public List<Guid> LicitantiID { get; set; }
        public List<OvlascenoLiceInfoDto> Licitanti { get; set; }
        [JsonIgnore]
        public List<Guid> PrijavljeniKupciID { get; set; }
        public List<KupacInfoDto> PrijavljeniKupci { get; set; }
        //[JsonIgnore]
        public List<int> ParceleID { get; set; }
        public List<ParcelaInfoDto> Parcele { get; set; }
        [JsonIgnore]
        public Guid AdresaID { get; set; }
        public AdresaDTO Adresa { get; set; }
        [JsonIgnore]
        public Guid KupacID { get; set; }
        public KupacInfoDto NajboljiPonudjac { get; set; }

    }
}
