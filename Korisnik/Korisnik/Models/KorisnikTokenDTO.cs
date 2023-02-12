using Korisnik.Entities;

namespace Korisnik.Models
{
    public class KorisnikTokenDTO
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Token { get; set; }

        public KorisnikTokenDTO(KorisnikEntity korisnik, string token)
        {
            Id = korisnik.Id;
            KorisnickoIme = korisnik.KorisnickoIme;
            Token = token;
        }
    }
}
