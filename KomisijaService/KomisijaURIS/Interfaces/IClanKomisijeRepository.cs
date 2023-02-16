using KomisijaURIS.Entites;
using System.Linq.Expressions;

namespace KomisijaURIS.Interfaces
{
    public interface IClanKomisijeRepository : IBaseRepository<int, ClanKomisije>
    {
        public IEnumerable<ClanKomisije> GetAll(Expression<Func<ClanKomisije, bool>>? filter = null);
        ClanKomisije GetById(int id);
    }
}
