using KomisijaURIS.Entites;
using System.Linq.Expressions;

namespace KomisijaURIS.Interfaces
{
    public interface IKomisijaRepository : IBaseRepository<int, Komisija>
    {
        public IEnumerable<Komisija> GetAll(string? includeProperties = null);
        public Komisija GetById(Expression<Func<Komisija, bool>> filter, string? includeProperties = null);

        public bool Delete(Expression<Func<Komisija, bool>> filter, string? includeProperties = null);
    }
}
