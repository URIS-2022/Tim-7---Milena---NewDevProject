using KupacServis.Models;

namespace KupacServis.ServiceCalls
{
    public interface IDrzavaService
    {
        public Task<DrzavaDto> GetDrzavaByID(Guid drzavaId);
    }
}
