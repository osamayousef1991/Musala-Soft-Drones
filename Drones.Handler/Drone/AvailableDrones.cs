using Drones.Domain;
using Drones.Domain.IRepositories;

namespace Drones.Handler
{
    // We use the handler to execute the functionality of the API endpoint

    public class AvailableDrones : IAvailableDrones
    {
        private readonly IDroneRepository _droneRepository;

        public AvailableDrones(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }

        public ResponseModel Execute()
        {
            return Get();
        }

        private ResponseModel Get()
        {
            var availableDrones = _droneRepository.GetAvailableDrones();

            // we can return any value or map the entity to model
            return new SuccessResponseModel { Result = availableDrones };
        }
    }
}