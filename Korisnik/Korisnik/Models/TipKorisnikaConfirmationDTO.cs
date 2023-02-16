using Korisnik.Entities;

namespace Korisnik.Models
{
    /// <summary>
    /// Dto za uspesno kreiranog tipa korisnika
    /// </summary>
    public class TipKorisnikaConfirmationDto
    {
        /// <summary>
        /// Id tipa korisnika
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Naziv tipa korisnika
        /// </summary>
        public string Naziv { get; set; }

        public TipKorisnikaConfirmationDto(TipKorisnikaEntity tipKorisnika)
        {
            Id = tipKorisnika.Id;
            Naziv = tipKorisnika.Naziv; 
        }
    }
}
