using Uris.Models;
using Uris.Repositories.Base;

namespace Uris.Repositories.KatastarskaOpstinaRepository
{
    public interface IKatastarskaOpstinaRepository : IBaseRepository<int, KatastarskaOpstina>
    {
        IEnumerable<KatastarskaOpstina> GetAll();
    }
}
