using Drones.Domain;
using Drones.Domain.ViewModels;

namespace Drones.Handler
{
    public interface IDroneRegistration
    {
        ResponseModel Execute(DroneRequestModel RegisterModel);
    }
}