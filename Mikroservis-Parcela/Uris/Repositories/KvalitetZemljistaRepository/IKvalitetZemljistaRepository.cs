using Uris.Models;
using Uris.Repositories.Base;

namespace Uris.Repositories.KvalitetZemljistaRepository
{
    public interface IKvalitetZemljistaRepository : IBaseRepository<int, KvalitetZemljista>
    {
        IEnumerable<KvalitetZemljista> GetAll();
    }
}
