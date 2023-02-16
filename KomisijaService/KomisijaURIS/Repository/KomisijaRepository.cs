using KomisijaURIS.Data;
using KomisijaURIS.Entites;
using KomisijaURIS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace KomisijaURIS.Repository
{
    public class KomisijaRepository : BaseRepository<int, Komisija>, IKomisijaRepository
    {
        private readonly DataContext _context;

        public KomisijaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Komisija GetById(Expression<Func<Komisija, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Komisija> query = _context.Set<Komisija>();
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

        public IEnumerable<Komisija> GetAll(string? includeProperties = null)
        {
            
            IQueryable<Komisija> query = _context.Set<Komisija>();
            
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public bool Delete(Expression<Func<Komisija, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Komisija> query = _context.Set<Komisija>();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (query == null) return false;


            _context.Set<Komisija>().Remove(query.FirstOrDefault());

            
                _context.SaveChanges();

            return true;
        }
    }
}
