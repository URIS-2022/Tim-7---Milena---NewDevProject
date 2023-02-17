using Microsoft.EntityFrameworkCore;
using OglasURIS.Data;
using OglasURIS.Interfaces;
using OglasURIS.Models;

namespace OglasURIS.Repository
{
    public class OglasRepository : BaseRepository<int, Oglas>, IOglasRepository
    {
        private readonly DataContext _context;
        public OglasRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Oglas> GetAll()
        {
            return _context.Oglasi.ToList();
        }

        
    }
}
