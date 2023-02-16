using KomisijaURIS.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KomisijaURIS.Models
{
    /// <summary>
    /// DTO za komisiju
    /// </summary>
    public class KomisijaDto
    {
        /// <summary>
        /// Id komisije
        /// </summary>
        public int KomisijaId { get; set; }

        /// <summary>
        /// Predsednik komisije
        /// </summary>
        public int PredsednikId { get; set; }

        /// <summary>
        /// Clanovi komisije
        /// </summary>
        public List<int> ClanId { get; set; }

        public KomisijaDto()
        {

        }

        
    }
}
