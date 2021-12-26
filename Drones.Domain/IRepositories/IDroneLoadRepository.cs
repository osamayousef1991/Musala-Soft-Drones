using Drones.Domain.Entities;

namespace Drones.Domain.IRepositories
{
    public interface IDroneLoadRepository : IGenericRepository<DroneLoad>
    {
        List<DroneLoad> GetDroneLoads(int droneId);
    }
}