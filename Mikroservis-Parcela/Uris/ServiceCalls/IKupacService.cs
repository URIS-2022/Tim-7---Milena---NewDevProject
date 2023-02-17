using Uris.DTO;

namespace Uris.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacDto> GetKupacById(Guid KupacID);
    }
}
