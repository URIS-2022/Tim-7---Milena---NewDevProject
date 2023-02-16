using Uris.Models;
using Uris.Repositories.Base;

namespace Uris.Repositories.KulturaRepository
{
    public interface IKulturaRepository : IBaseRepository<int, Kultura>
    {
        IEnumerable<Kultura> GetAll();
    }
}
