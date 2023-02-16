using Uris.Context;
using Uris.Models;
using Uris.Repositories.Base;
using Uris.Repositories.KulturaRepository;

namespace Uris.Repositories.KvalitetZemljistaRepository
{
    public class KvalitetZemljistaRepository : BaseRepository<int, KvalitetZemljista>, IKvalitetZemljistaRepository
    {
        private readonly UrisDbContext _context;

        public KvalitetZemljistaRepository(UrisDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<KvalitetZemljista> GetAll()
        {
            return _context.KvalitetiZemljista.ToList();
        }
    }
}
