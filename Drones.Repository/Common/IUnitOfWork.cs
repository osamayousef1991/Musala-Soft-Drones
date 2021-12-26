using Drones.Persistence;

namespace Drones.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        DronesDbContext Context { get; }

        int Commit();
    }
}