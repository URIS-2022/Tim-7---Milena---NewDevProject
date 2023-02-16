using Mikroservis_Uplata.Context;
using Mikroservis_Uplata.Models;
using Mikroservis_Uplata.Repositories.Base;

namespace Mikroservis_Uplata.Repositories.KursRepository
{
    public class KursRepository : BaseRepository<int, Kurs>, IKursRepository
    {
        private readonly UrisDbContext _context;

        public KursRepository(UrisDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Kurs> GetAll()
        {
            return _context.Kursevi.ToList();
        }
    }
}
