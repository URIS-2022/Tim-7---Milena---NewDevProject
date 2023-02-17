using KupacServis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace KupacServis.Entities
{
    public class Kupac
    {
        [Key]
       public Guid KupacId { get; set; }

     //   [ForeignKey(nameof(Prioritet))]
        public Guid PrioritetId { get; set; }
        public Prioritet Prioritet { get; set; }

        public int OstvarenaPovrsina { get; set; }

        public bool ImaZabranu { get; set; }

        
        public DateTime? DatumPocetkaZabrane { get; set; }

        public DateTime? DatumPrestankaZabrane { get; set; }

        public int DuzinaTrajanjaZabraneUGod { get; set; }

        public string BrTelefona1 { get; set; }
        public string BrTelefona2 { get; set; }
        public string Email { get; set; }
        public string BrRacuna { get; set; }

        public Guid? FizickoLiceId { get; set; }

        public Guid? PravnoLiceId { get; set; }

        public FizickoLice? FizickoLice { get; set; }

        public PravnoLice? PravnoLice { get; set; } 

        public Guid? AdresaId { get; set; }

     

        [NotMapped]
        public List<int>? Uplate { get; set; }

        [NotMapped]
         public List<Guid>? JavnaNadmetanja { get; set; }

        [NotMapped]
        public List<Guid>? OvlascenaLica { get; set; }




    }
}
