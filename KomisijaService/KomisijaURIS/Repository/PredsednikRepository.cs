using KomisijaURIS.Data;
using KomisijaURIS.Entites;
using KomisijaURIS.Interfaces;

namespace KomisijaURIS.Repository
{
    public class PredsednikRepository : BaseRepository<int, Predsednik>, IPredsednikRepository
    {
        private readonly DataContext _context;

        public PredsednikRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        

        public IEnumerable<Predsednik> GetAll()
        {
            return _context.Predsednici.ToList();
        }
    }
}
