namespace OglasURIS.Interfaces
{
    public interface IBaseRepository<in TKey, TEntity> where TEntity : class
    {
        TEntity GetById(TKey id);

        bool Add(TEntity entity, bool persist = true);

        bool Update(TEntity entity, int id, bool persist = true);

        bool Delete(int id, bool persist = true);
    }
}
