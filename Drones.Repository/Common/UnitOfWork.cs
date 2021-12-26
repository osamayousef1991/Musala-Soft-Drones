using Drones.Persistence;

namespace Drones.Repository.Common
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        public DronesDbContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWork(DronesDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            // Save changes with the default options
            return Context.SaveChanges();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}