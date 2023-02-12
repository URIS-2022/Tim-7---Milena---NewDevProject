using Gateway.Models.Korisnik;

namespace Gateway.ServiceCalls.Interfaces
{
    public interface IKorisnikService : IServiceCall<KorisnikDTO, KorisnikConfirmationDTO> 
    {
        public Task<KorisnikTokenDTO> RegisterAsync(string url, KorisnikDTO dto);
        public Task<KorisnikTokenDTO> LoginAsync(string url, KorisnikLoginDTO dto);

    }
}
