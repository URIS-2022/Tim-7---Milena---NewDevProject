using UgovorService.Models;

namespace UgovorService.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacInfoDto> GetKupacById(Guid KupacID);
    }
}
