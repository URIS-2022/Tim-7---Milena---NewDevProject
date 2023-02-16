using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public interface IParcelaService
    {
        public Task<ParcelaInfoDto> GetParcelaById(int ParcelaID);
    }
}
