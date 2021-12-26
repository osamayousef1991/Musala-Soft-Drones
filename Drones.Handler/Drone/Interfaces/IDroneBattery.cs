using Drones.Domain;

namespace Drones.Handler
{
    public interface IDroneBattery
    {
        ResponseModel Execute(int droneId);
    }
}