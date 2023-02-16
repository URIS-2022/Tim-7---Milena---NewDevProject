using KomisijaURIS.Entites;

namespace KomisijaURIS.Interfaces
{
    public interface IPredsednikRepository : IBaseRepository<int, Predsednik>
    {
        IEnumerable<Predsednik> GetAll();
        Predsednik GetById(int id);

    }

}
