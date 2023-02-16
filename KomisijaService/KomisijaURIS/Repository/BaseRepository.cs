using KomisijaURIS.Data;
using KomisijaURIS.Interfaces;

namespace KomisijaURIS.Repository
{
    public abstract class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : class, new()
    {
        private readonly DataContext _context;

        protected BaseRepository(DataContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual bool Add(TEntity entity, bool persist = true)
        {
            _context.Set<TEntity>().Add(entity);

            if (persist)
                _context.SaveChanges();

            return true;
        }

        public virtual bool Update(TEntity entity, int id, bool persist = true)
        {
            TEntity e = _context.Set<TEntity>().Find(id);

            if (e == null) return false;


            _context.Entry(e).CurrentValues.SetValues(entity);

            if (persist)
                _context.SaveChanges();


            return true;

        }

        public virtual bool Delete(int id, bool persist = true)
        {
            TEntity e = _context.Set<TEntity>().Find(id);

            if (e == null) return false;


            _context.Set<TEntity>().Remove(e);

            if (persist)
                _context.SaveChanges();

            return true;
        }

    }
}
