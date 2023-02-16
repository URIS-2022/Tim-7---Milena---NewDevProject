using Korisnik.Entities;

namespace Korisnik.Models
{
    /// <summary>
    /// Dto za ulogovanog korisnika
    /// </summary>
    public class KorisnikTokenDto
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
        /// Token korisnika
        /// </summary>
        public string Token { get; set; }

        public KorisnikTokenDto(KorisnikEntity korisnik, string token)
        {
            Id = korisnik.Id;
            KorisnickoIme = korisnik.KorisnickoIme;
            Token = token;
        }
    }
}
