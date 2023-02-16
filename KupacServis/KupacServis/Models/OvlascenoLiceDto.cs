using KupacServis.Entities;
using KupacServis.Models.Mock;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KupacServis.Models
{
    public class OvlascenoLiceDto
    {
        /// <summary>
        /// Id ovlascenog lica
        /// </summary>
        public Guid OvlascenoLiceId { get; set; }
        /// <summary>
        /// Ime ovlascenog lica
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime ovlascenog lica
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Jmbg ovlascenog lica
        /// </summary>
        public string Jmbg { get; set; }
        [JsonIgnore]
        public Guid AdresaId { get; set; }
        public AdresaDto Adresa { get; set; }
        /// <summary>
        /// Id drzave ovlascenog lica
        /// </summary>
        [JsonIgnore]
        public Guid? DrzavaId { get; set; }

        public DrzavaDto Drzava { get; set; }
        /// <summary>
        /// Broj table ovlascenog lica
        /// </summary>
        public int BrTable { get; set; }
        /// <summary>
        /// Kolekcija kupaca koje dato ovlasceno lice zastupa
        /// </summary>
        public List<KupacInfoDto>? KupciObj { get; set; }

        /// <summary>
        /// Lista kupac id
        /// </summary>
        [JsonIgnore]
        public List<Guid> Kupci { get; set; }
    }
}
