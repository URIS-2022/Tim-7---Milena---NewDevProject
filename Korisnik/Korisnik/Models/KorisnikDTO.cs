namespace Korisnik.Models
{
    /// <summary>
    /// Dto za Korisnika
    /// </summary>
    public class KorisnikDto
    {
        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string? Ime { get; set; }
        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string? Prezime { get; set; }
        /// <summary>
        /// Korisnicko ime korisnika
        /// </summary>
        public string? KorisnickoIme { get; set; }
        /// <summary>
        /// Lozinka korisnika
        /// </summary>
        public string? Lozinka { get; set; }
        /// <summary>
        /// Id tipa korisnika
        /// </summary>
        public int TipKorisnikaId { get; set; }
    }
}
