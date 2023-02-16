namespace Korisnik.Models
{
    /// <summary>
    /// Dto za logovanje korisnika
    /// </summary>
    public class KorisnikLoginDto
    {
        /// <summary>
        /// Korisnicko ime korisnika
        /// </summary>
        public string? KorisnickoIme { get; set; }
        /// <summary>
        /// Lozinka korisnika
        /// </summary>
        public string? Lozinka { get; set; }
    }
}
