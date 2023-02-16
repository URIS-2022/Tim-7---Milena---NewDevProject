using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacInfoDto> GetKupacById(Guid KupacID);
    }
}
