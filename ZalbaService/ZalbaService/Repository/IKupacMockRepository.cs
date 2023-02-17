using ZalbaService.Models.Mock;

namespace ZalbaService.Repository
{
    public interface IKupacMockRepository
    {
        public KupacDto GetKupac(Guid KupacID); 
    }
}
