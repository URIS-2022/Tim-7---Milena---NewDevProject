using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KomisijaURIS.Models
{
    public class PredsednikDto
    {
        /// <summary>
        /// Id predsednika
        /// </summary>
        public int PredsednikId { get; set; }

        /// <summary>
        /// Ime predsednika 
        /// </summary>
        
        public string ImePredsednika { get; set; }

        /// <summary>
        /// Prezime predsednika 
        /// </summary>
        
        public string PrezimePredsednika { get; set; }

        /// <summary>
        /// Email predsednika 
        /// </summary>
        
        public string EmailPredsednika { get; set; }
    }
}
