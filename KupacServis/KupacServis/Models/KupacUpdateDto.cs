using KupacServis.Entities;
using System.ComponentModel.DataAnnotations;

namespace KupacServis.Models
{
    public class KupacUpdateDto
    {

        public Guid KupacId { get; set; }
       
        /// <summary>
        /// Id prioriteta kupca
        /// </summary>
        public Guid PrioritetId { get; set; }
        /// <summary>
        /// Ostvarena povrsina kupca
        /// </summary>
        public int OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Ima li kupac zabranu
        /// </summary>
        public bool ImaZabranu { get; set; }
        /// <summary>
        /// Datum pocetka zabrane 
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DatumPocetkaZabrane { get; set; }
        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DatumPrestankaZabrane { get; set; }
        /// <summary>
        /// Duzina trajanja zabrane u godinama
        /// </summary>
        public int DuzinaTrajanjaZabraneUGod { get; set; }
        /// <summary>
        /// Broj telefona kupca 
        /// </summary>
        public string BrTelefona1 { get; set; }
        /// <summary>
        /// Drugi broj telefona kupca
        /// </summary>
        public string BrTelefona2 { get; set; }
        /// <summary>
        /// Email kupca
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Broj racuna kupca
        /// </summary>
        public string BrRacuna { get; set; }
        /// <summary>
        /// Lista ovlascenih lica koja se moze azurirati
        /// </summary>
        public List<Guid> OvlascenaLica { get; set; }
        /// <summary>
        ///Lista javnih nadmetanja koja se moze azuriratu
        /// </summary>
        public List<Guid> JavnaNadmetanja { get; set; }

        /// <summary>
        /// Id pravnog lica koji vec postoji u bazi
        /// </summary>
        public Guid? PravnoLiceId { get; set; }
        /// <summary>
        ///Id fizickog lica 
        /// </summary>
        public Guid? FizickoLiceId { get; set; }

        public Guid? AdresaId { get; set; }

    }
}
