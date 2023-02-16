using System.ComponentModel.DataAnnotations;

namespace KupacServis.Entities
{
    public class Prioritet
    {
        [Key]
        public Guid PrioritetId { get; set; }

        [Required]
        public string OpisPrioriteta { get; set; }

    }
}
