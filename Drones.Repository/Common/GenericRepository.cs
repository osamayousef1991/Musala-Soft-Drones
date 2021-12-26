using Drones.Domain.IRepositories;
using Drones.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Drones.Repository.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DronesDbContext Context;

        public GenericRepository(DronesDbContext droneDbContext)
        {
            Context = droneDbContext;
        }

        public TEntity Find(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Add(TEntity insertEntity)
        {
            Context.Set<TEntity>().Add(insertEntity);
            return insertEntity;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}