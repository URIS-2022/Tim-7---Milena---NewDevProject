using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public interface IAdresaService
    {
        public Task<AdresaDTO> GetAdresaById(Guid AdresaID);
    }
}
