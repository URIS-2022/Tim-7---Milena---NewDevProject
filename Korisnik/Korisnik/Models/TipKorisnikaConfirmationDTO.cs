using Korisnik.Entities;

namespace Korisnik.Models
{
    /// <summary>
    /// DTO za uspesno kreiranog tipa korisnika
    /// </summary>
    public class TipKorisnikaConfirmationDTO
    {
        /// <summary>
        /// Id tipa korisnika
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Naziv tipa korisnika
        /// </summary>
        public string Naziv { get; set; }

        public TipKorisnikaConfirmationDTO(TipKorisnikaEntity tipKorisnika)
        {
            Id = tipKorisnika.Id;
            Naziv = tipKorisnika.Naziv; 
        }
    }
}
