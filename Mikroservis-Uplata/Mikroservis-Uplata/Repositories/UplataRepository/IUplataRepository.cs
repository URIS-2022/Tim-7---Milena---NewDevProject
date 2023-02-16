using Mikroservis_Uplata.Models;
using Mikroservis_Uplata.Repositories.Base;

namespace Mikroservis_Uplata.Repositories.UplataRepository
{
    public interface IUplataRepository : IBaseRepository<int, Uplata>
    {
        IEnumerable<Uplata> GetAll();
        public Uplata GetUplataByIdVO(int uplataId);
        public IEnumerable<Uplata> GetUplateByKupacIdVO(Guid kupacId);
    }
}
