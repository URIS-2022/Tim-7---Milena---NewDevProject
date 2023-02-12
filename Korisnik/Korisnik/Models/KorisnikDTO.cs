using Korisnik.Entities;

namespace Korisnik.Models
{
    public class KorisnikDTO
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int TipKorisnikaId { get; set; }

        public KorisnikDTO()
        { 
        }

        public KorisnikDTO(KorisnikEntity korisnik)
        {
            Ime = korisnik.Ime;
            Prezime = korisnik.Prezime;
            KorisnickoIme = korisnik.KorisnickoIme;
            Lozinka = korisnik.Lozinka;
            TipKorisnikaId = korisnik.TipKorisnika.Id;
        }
    }
}
