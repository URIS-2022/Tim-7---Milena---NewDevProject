using Korisnik.Models;

namespace Korisnik.Entities
{
    /// <summary>
    /// Predstavlja model korisnika
    /// </summary>
    public class KorisnikEntity
    {
        /// <summary>
        /// Id korisnika
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Korisničko ime
        /// </summary>
        public string KorisnickoIme { get; set; }
        /// <summary>
        /// Hash-ovana šifra korisnika
        /// </summary>
        public byte[] LozinkaHash { get; set; }
        /// <summary>
        /// Salt
        /// </summary>
        public byte[] LozinkaSalt { get; set; }
        /// <summary>
        /// Tip korisnika
        /// </summary>
        public TipKorisnikaEntity TipKorisnika { get; set; }
    }
}
