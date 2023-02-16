using Uris.DTO;

namespace Uris.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacDTO> GetKupacById(Guid KupacID);
    }
}
