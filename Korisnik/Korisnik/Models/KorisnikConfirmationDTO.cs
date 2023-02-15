using Korisnik.Entities;

namespace Korisnik.Models
{
    /// <summary>
    /// DTO za uspesno kreiranog Korisnika
    /// </summary>
    public class KorisnikConfirmationDTO
    {
        /// <summary>
        /// Id korisnika
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Korisnicko ime korisnika
        /// </summary>
        public string KorisnickoIme { get; set; }
        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Id tipa korisnika
        /// </summary>
        public int TipKorisnikaId { get; set; }

        public KorisnikConfirmationDTO(KorisnikEntity korisnik)
        {
            Id = korisnik.Id;
            KorisnickoIme = korisnik.KorisnickoIme;
            Ime = korisnik.Ime;
            Prezime = korisnik.Prezime;
            TipKorisnikaId = korisnik.TipKorisnika.Id;
        }
    }
}
