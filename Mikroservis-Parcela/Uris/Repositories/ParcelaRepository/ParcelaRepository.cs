using Uris.Context;
using Uris.Models;
using Uris.Repositories.Base;
using Uris.Repositories.KulturaRepository;

namespace Uris.Repositories.ParcelaRepository
{
    public class ParcelaRepository : BaseRepository<int, Parcela>, IParcelaRepository
    {
        private readonly UrisDbContext _context;

        public ParcelaRepository(UrisDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Parcela> GetAll()
        {
            return _context.Parcele.ToList();
        }

        public Parcela GetParcelaByIdVO(int parcelaId)
        {
            return _context.Parcele.FirstOrDefault(e => e.Id == parcelaId);
        }
    }
}
