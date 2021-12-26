using Drones.Domain.Entities.Common;
using Drones.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static Drones.Domain.Enums.Enumeration;

namespace Drones.Domain.Entities
{
    public class Drone : AuditableEntity
    {
        public Drone()
        {
        }

        // we use the constructor to create an object of the entity from the request model
        public Drone(DroneRequestModel registerModel)
        {
            SerialNumber = registerModel.SerialNumber;
            Model = registerModel.Model;
            WeightLimit = registerModel.WeightLimit;
            BatteryCapacity = registerModel.BatteryCapacity;
            State = DroneState.IDLE;
        }

        [MaxLength(100)]
        public string SerialNumber { get; set; }

        public DroneModel Model { get; set; }
        public float WeightLimit { get; set; }
        public float BatteryCapacity { get; set; }
        public DroneState State { get; set; }

        public ICollection<DroneLoad> DroneLoads { get; set; }

        public string CheckForLoading(DroneLoadingRequestModel droneLoadingModel)
        {
            //if (Regex.IsMatch(droneLoadingModel.LoadName, @"^[a-zA-Z0-9_.-]+$")) return "Name allowed only letters, numbers, ‘-‘, ‘_’";
            //if (Regex.IsMatch(droneLoadingModel.LoadCode, @"^[A-Z0-9_]+$")) return "Code allowed only upper case letters, underscore and numbers";

            if (State != DroneState.IDLE) return "the drone is not available";
            if (BatteryCapacity < 25) return "the drone battery capacity is less than 25 %";

            // if it possible to load more than one item for the drone then we can get a list of all loads on this drone and check for the total weight
            if (droneLoadingModel.LoadWeight > WeightLimit) return "Item Weight is larger than the drone weight limit";

            return "";
        }
    }
}