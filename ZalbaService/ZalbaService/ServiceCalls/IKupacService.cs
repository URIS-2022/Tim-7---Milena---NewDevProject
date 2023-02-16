using ZalbaService.Models;

namespace ZalbaService.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacInfoDto> GetKupacById(Guid KupacID);
    }
}
