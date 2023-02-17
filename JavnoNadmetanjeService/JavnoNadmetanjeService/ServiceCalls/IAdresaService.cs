using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public interface IAdresaService
    {
        public Task<AdresaDto> GetAdresaById(Guid AdresaID);
    }
}
