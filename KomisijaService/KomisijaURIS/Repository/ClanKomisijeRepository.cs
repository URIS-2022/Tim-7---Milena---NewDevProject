using KomisijaURIS.Data;
using KomisijaURIS.Entites;
using KomisijaURIS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace KomisijaURIS.Repository
{
    public class ClanKomisijeRepository : BaseRepository<int, ClanKomisije>, IClanKomisijeRepository
    {
        private readonly DataContext _context;

        public ClanKomisijeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        

        public IEnumerable<ClanKomisije> GetAll(Expression<Func<ClanKomisije, bool>>? filter = null)
        {
            IQueryable<ClanKomisije> query = _context.Set<ClanKomisije>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            
            return query.ToList();
        }
    }
}
