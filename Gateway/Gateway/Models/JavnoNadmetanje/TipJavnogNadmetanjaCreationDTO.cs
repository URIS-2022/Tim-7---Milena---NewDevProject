﻿using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.JavnoNadmetanje
{
    public class TipJavnogNadmetanjaCreationDTO
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv tipa.")]
        public string NazivTipaJavnogNadmetanja { get; set; }
    }
}
