using Mikroservis_Uplata.DTO;

namespace Mikroservis_Uplata.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacDto> GetKupacById(Guid KupacID);
    }
}
