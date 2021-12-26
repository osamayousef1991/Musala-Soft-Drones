namespace Drones.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Find(int id);

        IQueryable<TEntity> GetAll();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);
    }
}