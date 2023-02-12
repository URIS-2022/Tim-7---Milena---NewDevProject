using Korisnik.Entities;

namespace Korisnik.Models
{
    public class KorisnikConfirmationDTO
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
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
