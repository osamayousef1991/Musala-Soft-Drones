using Drones.Domain;
using Drones.Domain.Entities;
using Drones.Domain.IRepositories;
using Drones.Domain.ViewModels;
using Drones.Repository.Common;

namespace Drones.Handler
{
    // We use the handler to execute the functionality of the API endpoint
    public class DroneLoading : IDroneLoading
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDroneRepository _droneRepository;
        private readonly IDroneLoadRepository _droneLoadRepository;

        public DroneLoading(IUnitOfWork unitOfWork, IDroneRepository droneRepository, IDroneLoadRepository droneLoadRepository)
        {
            _unitOfWork = unitOfWork;
            _droneRepository = droneRepository;
            _droneLoadRepository = droneLoadRepository;
        }

        public ResponseModel Execute(DroneLoadingRequestModel droneLoadingModel)
        {
            return Load(droneLoadingModel);
        }

        private ResponseModel Load(DroneLoadingRequestModel droneLoadingModel)
        {
            var drone = _droneRepository.GetById(droneLoadingModel.DroneId);
            if (drone == null) return new FailureResponseModel { Message = "Drone not exist" };

            var error = drone.CheckForLoading(droneLoadingModel);
            if (!string.IsNullOrEmpty(error)) return new FailureResponseModel { Message = error };

            var droneLoad = new DroneLoad(droneLoadingModel);

            // uploadImage
            //   droneLoad.ImageUrl = uploadImage result;

            _droneLoadRepository.Add(droneLoad);

            _unitOfWork.Commit();

            // we can return any value or model we want
            return new SuccessResponseModel { Result = droneLoad };
        }
    }
}