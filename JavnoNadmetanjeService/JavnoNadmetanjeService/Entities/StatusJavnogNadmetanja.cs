using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Entities
{
    public class StatusJavnogNadmetanja
    {
        /// <summary>
        /// ID statusa javnog nadmetanja
        /// </summary>
        [Key]
        public Guid StatusJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// Naziv statusa javnog nadmetanja
        /// </summary> 
        [Required]
        public string NazivStatusaJavnogNadmetanja { get; set; }
    }
}
