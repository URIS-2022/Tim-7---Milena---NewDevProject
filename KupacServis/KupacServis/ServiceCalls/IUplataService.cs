using KupacServis.Models;

namespace KupacServis.ServiceCalls
{
    public interface IUplataService
    {
        public Task<List<UplataInfoDTO>> GetUplataByKupacID(Guid kupacId);
    }
}
