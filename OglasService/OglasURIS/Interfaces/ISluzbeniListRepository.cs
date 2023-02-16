using OglasURIS.Models;
using System.Linq.Expressions;

namespace OglasURIS.Interfaces
{
    public interface ISluzbeniListRepository : IBaseRepository<int, SluzbeniList>
    {
        IEnumerable<SluzbeniList> GetAll(string? includeProperties = null);
        public SluzbeniList GetById(Expression<Func<SluzbeniList, bool>> filter, string? includeProperties = null);

        public bool Delete(Expression<Func<SluzbeniList, bool>> filter, string? includeProperties = null);

    }
}
