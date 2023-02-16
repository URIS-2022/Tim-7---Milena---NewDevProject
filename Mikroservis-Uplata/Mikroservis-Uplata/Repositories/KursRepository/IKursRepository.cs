using Mikroservis_Uplata.Models;
using Mikroservis_Uplata.Repositories.Base;

namespace Mikroservis_Uplata.Repositories.KursRepository
{
    public interface IKursRepository : IBaseRepository<int, Kurs>
    {
        IEnumerable<Kurs> GetAll();
    }
}
