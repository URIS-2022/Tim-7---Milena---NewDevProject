using Korisnik.Entities;

namespace Korisnik.Models
{
    public class TipKorisnikaConfirmationDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public TipKorisnikaConfirmationDTO(TipKorisnikaEntity tipKorisnika)
        {
            Id = tipKorisnika.Id;
            Naziv = tipKorisnika.Naziv; 
        }
    }
}
