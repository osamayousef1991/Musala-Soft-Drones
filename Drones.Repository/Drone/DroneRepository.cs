using Drones.Domain.Entities;
using Drones.Domain.IRepositories;
using Drones.Persistence;
using Drones.Repository.Common;

namespace Drones.Repository
{
    public class DroneRepository : GenericRepository<Drone>, IDroneRepository
    {
        public DroneRepository(DronesDbContext droneDbContext) : base(droneDbContext)
        {
        }

        // we can map the drone entity to model and return useful items for the user
        public List<Drone> GetAvailableDrones()
        {
            return GetAll().Where(d => !d.IsDeleted && d.State == Domain.Enums.Enumeration.DroneState.IDLE).ToList();
        }

        public Drone GetById(int id)
        {
            return GetAll().FirstOrDefault(d => d.Id == id && !d.IsDeleted);
        }
    }
}