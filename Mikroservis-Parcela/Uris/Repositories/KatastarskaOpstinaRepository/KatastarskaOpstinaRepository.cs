using Uris.Context;
using Uris.Models;
using Uris.Repositories.Base;
using Uris.Repositories.KulturaRepository;

namespace Uris.Repositories.KatastarskaOpstinaRepository
{
    public class KatastarskaOpstinaRepository : BaseRepository<int, KatastarskaOpstina>, IKatastarskaOpstinaRepository
    {
        private readonly UrisDbContext _context;

        public KatastarskaOpstinaRepository(UrisDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<KatastarskaOpstina> GetAll()
        {
            return _context.KatastarskeOpstine.ToList();
        }
    }
}
