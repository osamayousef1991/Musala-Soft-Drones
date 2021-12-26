using Drones.Domain;
using Drones.Domain.IRepositories;

namespace Drones.Handler
{
    // We use the handler to execute the functionality of the API endpoint

    public class DroneCheckingLoads : IDroneCheckingLoads
    {
        private readonly IDroneLoadRepository _droneLoadRepository;

        public DroneCheckingLoads(IDroneLoadRepository droneLoadRepository)
        {
            _droneLoadRepository = droneLoadRepository;
        }

        public ResponseModel Execute(int droneId)
        {
            return Get(droneId);
        }

        private ResponseModel Get(int droneId)
        {
            var droneLoads = _droneLoadRepository.GetDroneLoads(droneId);

            // we can return any value or map the entity to model
            return new SuccessResponseModel { Result = droneLoads };
        }
    }
}