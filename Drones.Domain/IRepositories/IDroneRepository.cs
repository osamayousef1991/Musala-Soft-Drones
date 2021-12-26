using Drones.Domain.Entities;

namespace Drones.Domain.IRepositories
{
    public interface IDroneRepository : IGenericRepository<Drone>
    {
        Drone GetById(int id);

        List<Drone> GetAvailableDrones();
    }
}