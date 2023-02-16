using KomisijaURIS.Entites;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace KomisijaURIS.Models
{
    /// <summary>
    /// GetDTO za komisiju
    /// </summary>
    public class KomisijaGetDto
    {
        /// <summary>
        /// Id komisije
        /// </summary>
        public int KomisijaId { get; set; }

        /// <summary>
        /// Predsednik komisije
        /// </summary>
        public Predsednik Predsednik { get; set; }

        /// <summary>
        /// Clanovi komisije
        /// </summary>
        public List<ClanKomisije> Clan { get; set; }

        public KomisijaGetDto()
        {

        }

        public KomisijaGetDto(Komisija komisija)
        {
            Clan = komisija.Clan;
            Predsednik = komisija.Predsednik;
            KomisijaId = komisija.KomisijaId;
        }
    }
}
