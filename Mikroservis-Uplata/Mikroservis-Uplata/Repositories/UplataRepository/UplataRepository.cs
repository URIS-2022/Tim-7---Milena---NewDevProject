using Mikroservis_Uplata.Context;
using Mikroservis_Uplata.Models;
using Mikroservis_Uplata.Repositories.Base;

namespace Mikroservis_Uplata.Repositories.UplataRepository
{
    public class UplataRepository : BaseRepository<int, Uplata>, IUplataRepository
    {
        private readonly UrisDbContext _context;

        public UplataRepository(UrisDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Uplata> GetAll()
        {
            return _context.Uplate.ToList();
        }

        public Uplata GetUplataByIdVO(int uplataId)
        {
            return _context.Uplate.FirstOrDefault(e => e.Id == uplataId);
        }

        public IEnumerable<Uplata> GetUplateByKupacIdVO(Guid kupacId)
        {
            return _context.Uplate.Where(x=> x.KupacId == kupacId).ToList();
        }
    }
}
