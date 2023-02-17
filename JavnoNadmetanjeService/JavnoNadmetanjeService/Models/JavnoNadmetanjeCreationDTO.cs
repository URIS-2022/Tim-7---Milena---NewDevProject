using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeCreationDto:IValidatableObject
    {
        /// <summary>
        ///  Datum održavanja javnog nadmetanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum održavanja javnog nadmetanja.")]
        public DateTime Datum { get; set; }
        /// <summary>
        ///  Vreme početka javnog nadmetanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti vreme početka održavanja javnog nadmetanja.")]
        public string VremePocetka { get; set; }
        /// <summary>
        ///  Vreme kraja javnog nadmetanja
        /// </summary>
        public string VremeKraja { get; set; }
        /// <summary>
        /// Početna cena po hektaru
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti početnu cenu po hektaru.")]
        public int PocetnaCenaPoHektaru { get; set; }
        /// <summary>
        ///  Informacija o tome da li je javno nadmetanje izuzeto
        /// </summary>
        public bool Izuzeto { get; set; }
        /// <summary>
        /// ID tipa javnog nadmetanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je ID tipa javnog nadmetanja.")]
        public Guid TipJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// ID statusa javnog nadmetanja
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti ID statusa javnog nadmetanja.")]
        public Guid StatusJavnogNadmetanjaID { get; set; }
        /// <summary>
        /// Izlicitirana cena
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti izlicitiranu cenu.")]
        public int IzlicitiranaCena { get; set; }
        /// <summary>
        /// Vremenski period zakupa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti period zakupa.")]
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
        /// Lista id-jeva licitanata
        /// </summary>
        public List<Guid> LicitantiID { get; set; }
        /// <summary>
        /// Lista id-jeva prijavljenih kupaca
        /// </summary>
        public List<Guid> PrijavljeniKupciID { get; set; }
        /// <summary>
        /// Lista id-jeva parcela
        /// </summary>
        public List<int> ParceleID { get; set; }
        /// <summary>
        /// ID adrese javnog nadmetanja
        /// </summary>
        public Guid AdresaID { get; set; }
        /// <summary>
        /// ID kupca koji je dostavio najbolju ponudu
        /// </summary>
        public Guid KupacID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PocetnaCenaPoHektaru > IzlicitiranaCena)
            {
                yield return new ValidationResult(
                    "Izlicitirana cena ne sme biti manja od početne cene!",
                    new[] { "JavnoNadmetanjeCreationDTO" });
            }
            if (Int32.Parse(VremePocetka.Substring(0, 2)) > Int32.Parse(VremeKraja.Substring(0, 2)))
            {
                yield return new ValidationResult(
                    "Vreme početka održavanja javnog nadmetanja ne sme biti veće od vremena kraja javnog nadmetanja!",
                    new[] { "JavnoNadmetanjeCreationDTO" });
            }
        }

    }
}
