using Microsoft.EntityFrameworkCore;
using OglasURIS.Data;
using OglasURIS.Interfaces;
using OglasURIS.Models;
using System.Linq.Expressions;

namespace OglasURIS.Repository
{
    public class SluzbeniListRepository : BaseRepository<int, SluzbeniList>, ISluzbeniListRepository
    {
        private readonly DataContext _context;
        public SluzbeniListRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SluzbeniList> GetAll(string? includeProperties = null)
        {
            IQueryable<SluzbeniList> query = _context.Set<SluzbeniList>();

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public SluzbeniList GetById(Expression<Func<SluzbeniList, bool>> filter, string? includeProperties = null)
        {
            IQueryable<SluzbeniList> query = _context.Set<SluzbeniList>();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public bool Delete(Expression<Func<SluzbeniList, bool>> filter, string? includeProperties = null)
        {
            IQueryable<SluzbeniList> query = _context.Set<SluzbeniList>();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (query == null) return false;


            _context.Set<SluzbeniList>().Remove(query.FirstOrDefault());


            _context.SaveChanges();

            return true;
        }
    }
}
