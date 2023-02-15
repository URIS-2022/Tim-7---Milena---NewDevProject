using Korisnik.Entities;

namespace Korisnik.Models
{
    /// <summary>
    /// DTO za ulogovanog korisnika
    /// </summary>
    public class KorisnikTokenDTO
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

        public KorisnikTokenDTO(KorisnikEntity korisnik, string token)
        {
            Id = korisnik.Id;
            KorisnickoIme = korisnik.KorisnickoIme;
            Token = token;
        }
    }
}
