using Drones.Domain;
using Drones.Domain.Entities;
using Drones.Domain.IRepositories;
using Drones.Domain.ViewModels;
using Drones.Repository.Common;

namespace Drones.Handler
{
    // We use the handler to execute the functionality of the API endpoint
    public class DroneRegistration : IDroneRegistration
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDroneRepository _droneRepository;

        public DroneRegistration(IUnitOfWork unitOfWork, IDroneRepository droneRepository)
        {
            _unitOfWork = unitOfWork;
            _droneRepository = droneRepository;
        }

        public ResponseModel Execute(DroneRequestModel RegisterModel)
        {
            return Register(RegisterModel);
        }

        private ResponseModel Register(DroneRequestModel registerModel)
        {
            var error = registerModel.Validate();
            if (!string.IsNullOrEmpty(error)) return new FailureResponseModel { Message = error };

            var drone = new Drone(registerModel);
            _droneRepository.Add(drone);
            _unitOfWork.Commit();

            // we can return any value or map the entity to model
            return new SuccessResponseModel { Result = drone };
        }
    }
}