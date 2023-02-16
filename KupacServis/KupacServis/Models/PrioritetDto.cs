using System.ComponentModel.DataAnnotations;

namespace KupacServis.Models
{
    public class PrioritetDto
    {

        /// <summary>
        /// Id prioriteta
        /// </summary>
        public Guid PrioritetId { get; set; }
        /// <summary>
        /// Opis priositeta
        /// </summary>
        public string OpisPrioriteta { get; set; }
        

    }
}
