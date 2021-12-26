using Drones.Domain;
using Drones.Domain.IRepositories;

namespace Drones.Handler
{
    // We use the handler to execute the functionality of the API endpoint

    public class DroneBattery : IDroneBattery
    {
        private readonly IDroneRepository _droneRepository;

        public DroneBattery(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }

        public ResponseModel Execute(int droneId)
        {
            return Get(droneId);
        }

        private ResponseModel Get(int droneId)
        {
            var drone = _droneRepository.GetById(droneId);
            if (drone == null) return new FailureResponseModel { Message = "Drone don't exist" };

            // we can return any value or map the entity to model
            return new SuccessResponseModel { Result = drone.BatteryCapacity };
        }
    }
}