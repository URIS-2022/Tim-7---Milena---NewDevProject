using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Entities
{
    public class JavnoNadmetanje
    {
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        [Key]
        public Guid JavnoNadmetanjeID { get; set; }
        /// <summary>
        ///  Datum održavanja javnog nadmetanja
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        ///  Vreme početka javnog nadmetanja
        /// </summary>
        public string VremePocetka { get; set; }

        /// <summary>
        ///  Vreme kraja javnog nadmetanja
        /// </summary>
        public string VremeKraja { get; set; }

        /// <summary>
        /// Početna cena po hektaru
        /// </summary>
        public int PocetnaCenaPoHektaru { get; set; }
        /// <summary>
        ///  Informacija o tome da li je javno nadmetanje izuzeto
        /// </summary>
        public bool Izuzeto { get; set; }
        /// <summary>
        /// ID tipa javnog nadmetanja
        /// </summary>
        [ForeignKey("TipJavnogNadmetanja")]
        public Guid TipJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// Tip javnog nadmetanja
        /// </summary>
        public TipJavnogNadmetanja TipJavnogNadmetanja { get; set; }
        /// <summary>
        /// ID statusa javnog nadmetanja
        /// </summary>
        [ForeignKey("StatusJavnogNadmetanja")]

        public Guid StatusJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// Status javnog nadmetanja 
        /// </summary>
        public StatusJavnogNadmetanja StatusJavnogNadmetanja { get; set; }

        /// <summary>
        /// Izlicitirana cena
        /// </summary>
        public int IzlicitiranaCena { get; set; }

        /// <summary>
        /// Vremenski period zakupa 
        /// </summary>
        public int PeriodZakupa { get; set; }

        /// <summary>
        /// Broj učesnika u javnom nadmetanju
        /// </summary>
        public int BrojUcesnika { get; set; }

        /// <summary>
        /// Visina dopune depozita
        /// </summary>
        public int VisinaDopuneDepozita { get; set; }

        /// <summary>
        /// Krug javnog nadmetanja 
        /// </summary>
        public int Krug { get; set; }
        /// <summary>
        /// ID kupca koji je dostavio najbolju ponudu
        /// </summary>
        public Guid? KupacID { get; set; }
        /// <summary>
        /// ID adrese na kojoj se održava javno nadmetanje
        /// </summary>
        public Guid? AdresaID { get; set; }
        /// <summary>
        /// Lista ID-jeva licitanata(ovlašćenih lica) koji učestvuju na javnom nadmetanju
        /// </summary>
        [NotMapped]
        public List<Guid> LicitantiID { get; set; }
        /// <summary>
        /// Lista ID-jeva svih prijavljenih kupaca koji učestvuju na javnom nadmetanju
        /// </summary>
        [NotMapped]
        public List<Guid> PrijavljeniKupciID { get; set; }
        /// <summary>
        /// Lista ID-jeva parcela koje učestvuju na javnom nadmetanju
        /// </summary>
        [NotMapped]
        public List<int> ParceleID { get; set; }
    }
}
