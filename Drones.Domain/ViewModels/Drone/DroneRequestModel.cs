using static Drones.Domain.Enums.Enumeration;

namespace Drones.Domain.ViewModels
{
    public class DroneRequestModel
    {
        public string SerialNumber { get; set; }
        public DroneModel Model { get; set; }
        public float WeightLimit { get; set; }
        public float BatteryCapacity { get; set; }

        // we did the validation for every request in the related request model
        public string Validate()
        {
            if (SerialNumber.Length > 100)
                return "The serial number should be less than or equal to 100 characters";
            if (WeightLimit > 500)
                return "The drone weight limit is 500 gr";
            return "";
        }
    }
}