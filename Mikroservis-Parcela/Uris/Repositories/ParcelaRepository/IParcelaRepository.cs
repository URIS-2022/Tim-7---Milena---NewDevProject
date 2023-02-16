using Uris.Models;
using Uris.Repositories.Base;

namespace Uris.Repositories.ParcelaRepository
{
    public interface IParcelaRepository : IBaseRepository<int, Parcela>
    {
        IEnumerable<Parcela> GetAll();
        public Parcela GetParcelaByIdVO(int parcelaId);
    }
}
