using OglasURIS.Models;

namespace OglasURIS.Interfaces
{
    public interface IOglasRepository : IBaseRepository<int, Oglas>
    {
        IEnumerable<Oglas> GetAll();
        
    }
}
