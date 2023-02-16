using System.Diagnostics.Metrics;
using Uris.Context;
using Uris.Models;
using Uris.Repositories.Base;

namespace Uris.Repositories.KulturaRepository
{
    public class KulturaRepository : BaseRepository<int, Kultura>, IKulturaRepository
    {
        private readonly UrisDbContext _context;

        public KulturaRepository(UrisDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Kultura> GetAll()
        {
            return _context.Kulture.ToList();
        }
    }
}
