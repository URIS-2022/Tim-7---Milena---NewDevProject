using ZalbaService.Models.Mock;

namespace ZalbaService.Repository
{
    public interface IKupacMockRepository
    {
        public KupacDTO GetKupac(Guid KupacID); 
    }
}
