using Drones.Domain.Entities;
using Drones.Domain.IRepositories;
using Drones.Persistence;
using Drones.Repository.Common;

namespace Drones.Repository
{
    public class DroneLoadRepository : GenericRepository<DroneLoad>, IDroneLoadRepository
    {
        public DroneLoadRepository(DronesDbContext droneDbContext) : base(droneDbContext)
        {
        }

        public List<DroneLoad> GetDroneLoads(int droneId)
        {
            return GetAll().Where(d => d.DroneId == droneId).ToList();
        }
    }
}