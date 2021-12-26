namespace Drones.Domain.ViewModels
{
    public class DroneLoadingRequestModel
    {
        public int DroneId { get; set; }
        public string LoadName { get; set; }
        public float LoadWeight { get; set; }
        public string LoadCode { get; set; }
        public string LoadImage { get; set; }
    }
}