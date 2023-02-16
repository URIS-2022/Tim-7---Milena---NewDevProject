using Korisnik.Entities;

namespace Korisnik.Helpers
{
    public interface IAuthHelper
    {
        public string CreateToken(KorisnikEntity korisnik);

        public void CreatePasswordHash(string? password, out byte[] passwordHash, out byte[] passwordSalt);

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
