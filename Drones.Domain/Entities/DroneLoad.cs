using Drones.Domain.Entities.Common;
using Drones.Domain.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drones.Domain.Entities
{
    public class DroneLoad : AuditableEntity
    {
        public DroneLoad()
        {
        }

        public DroneLoad(DroneLoadingRequestModel droneLoadingModel)
        {
            Name = droneLoadingModel.LoadName;
            Weight = droneLoadingModel.LoadWeight;
            DroneId = droneLoadingModel.DroneId;
            Code = droneLoadingModel.LoadCode;
        }

        public string Name { get; set; }
        public float Weight { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("DroneId")]
        public Drone Drone { get; set; }

        public int DroneId { get; set; }
    }
}