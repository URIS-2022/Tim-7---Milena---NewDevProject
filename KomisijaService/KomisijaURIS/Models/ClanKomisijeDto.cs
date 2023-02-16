using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KomisijaURIS.Models
{
    public class ClanKomisijeDto
    {
        /// <summary>
        /// Id clana komisije
        /// </summary>
        public int ClanId { get; set; }

        /// <summary>
        /// Ime clana komisije
        /// </summary>
        
        public string ImeClana { get; set; }

        /// <summary>
        /// Prezime clana komisije
        /// </summary>
        public string PrezimeClana { get; set; }

        /// <summary>
        /// Email adresa clana komisije
        /// </summary>
        public string EmailClana { get; set; }



        
    }
}
