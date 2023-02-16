using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.JavnoNadmetanje
{
    public class JavnoNadmetanjeCreationDto
    {
        [Required(ErrorMessage = "Obavezno je uneti datum održavanja javnog nadmetanja.")]
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Obavezno je uneti vreme početka održavanja javnog nadmetanja.")]
        public string? VremePocetka { get; set; }
        public string? VremeKraja { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti početnu cenu po hektaru.")]
        public int PocetnaCenaPoHektaru { get; set; }
        public bool Izuzeto { get; set; }
        [Required(ErrorMessage = "Obavezno je ID tipa javnog nadmetanja.")]
        public Guid TipJavnogNadmetanjaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ID statusa javnog nadmetanja.")]
        public Guid StatusJavnogNadmetanjaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti izlicitiranu cenu.")]
        public int IzlicitiranaCena { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti period zakupa.")]
        public int PeriodZakupa { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }
        public int Krug { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PocetnaCenaPoHektaru > IzlicitiranaCena)
            {
                yield return new ValidationResult(
                    "Izlicitirana cena ne sme biti manja od početne cene!",
                    new[] { "JavnoNadmetanjeCreationDto" });
            }
            if (Int32.Parse(VremePocetka!.Substring(0, 2)) > Int32.Parse(VremeKraja!.Substring(0, 2)))
            {
                yield return new ValidationResult(
                    "Vreme početka održavanja javnog nadmetanja ne sme biti veće od vremena kraja javnog nadmetanja!",
                    new[] { "JavnoNadmetanjeCreationDto" });
            }
        }

    }
}
