using Drones.Domain;
using Drones.Domain.Entities;

namespace Drones.Handler
{
    public interface IDroneCheckingLoads
    {
        ResponseModel Execute(int droneId);
    }
}