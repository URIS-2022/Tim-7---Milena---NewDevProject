namespace Korisnik.Models
{
    /// <summary>
    /// DTO za logovanje korisnika
    /// </summary>
    public class KorisnikLoginDTO
    {
        /// <summary>
        /// Korisnicko ime korisnika
        /// </summary>
        public string KorisnickoIme { get; set; }
        /// <summary>
        /// Lozinka korisnika
        /// </summary>
        public string Lozinka { get; set; }
    }
}
