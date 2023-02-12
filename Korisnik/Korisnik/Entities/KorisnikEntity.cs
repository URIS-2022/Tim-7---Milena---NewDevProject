using Korisnik.Models;

namespace Korisnik.Entities
{
    public class KorisnikEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public byte[] LozinkaHash { get; set; }
        public byte[] LozinkaSalt { get; set; }
        public TipKorisnikaEntity TipKorisnika { get; set; }
    }
}
