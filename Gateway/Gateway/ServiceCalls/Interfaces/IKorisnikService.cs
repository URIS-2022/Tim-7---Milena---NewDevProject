using Gateway.Models.Korisnik;

namespace Gateway.ServiceCalls.Interfaces
{
    public interface IKorisnikService : IServiceCall<KorisnikDto, KorisnikConfirmationDto> 
    {
        public Task<KorisnikTokenDto> RegisterAsync(string url, KorisnikDto Dto);
        public Task<KorisnikTokenDto> LoginAsync(string url, KorisnikLoginDto Dto);

    }
}
