using Drones.Domain;
using Drones.Domain.ViewModels;

namespace Drones.Handler
{
    public interface IDroneLoading
    {
        ResponseModel Execute(DroneLoadingRequestModel RegisterModel);
    }
}