namespace Drones.Domain.Enums
{
    public class Enumeration
    {
        public enum DroneModel
        {
            Lightweight = 1,
            Middleweight = 2,
            Cruiserweight = 3,
            Heavyweight = 4
        }

        public enum DroneState
        {
            IDLE = 1,
            LOADING = 2,
            LOADED = 3,
            DELIVERING = 4,
            DELIVERED = 5,
            RETURNING = 6
        }
    }
}