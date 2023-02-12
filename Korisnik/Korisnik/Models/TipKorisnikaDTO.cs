using Korisnik.Entities;

namespace Korisnik.Models
{
    public class TipKorisnikaDTO
    {
        public string Naziv { get; set; }

        public TipKorisnikaDTO()
        {

        }

        public TipKorisnikaDTO(TipKorisnikaEntity tipKorisnika)
        {
            Naziv = tipKorisnika.Naziv;
        }
    }
}
