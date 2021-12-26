using Drones.Domain.ViewModels;
using Drones.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Drones.API.Controllers
{
    // the controller is used just like a getaway to execute the handler

    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private readonly IDroneRegistration _registerDrone;
        private readonly IDroneLoading _loadDrone;
        private readonly IDroneBattery _droneBattery;
        private readonly IDroneCheckingLoads _droneCheckingLoads;
        private readonly IAvailableDrones _availableDrones;

        public DroneController(IDroneRegistration registerDrone, IDroneLoading loadDrone, IDroneBattery droneBattery, IDroneCheckingLoads droneCheckingLoads, IAvailableDrones availableDrones)
        {
            _registerDrone = registerDrone;
            _loadDrone = loadDrone;
            _droneBattery = droneBattery;
            _droneCheckingLoads = droneCheckingLoads;
            _availableDrones = availableDrones;
        }

        [HttpPost]
        public IActionResult Add(DroneRequestModel droneModel)
        {
            return Ok(_registerDrone.Execute(droneModel));
        }

        [HttpPost("load")]
        public IActionResult LoadDrone(DroneLoadingRequestModel droneLoadingModel)
        {
            return Ok(_loadDrone.Execute(droneLoadingModel));
        }

        [HttpGet("{droneId}/checkLoads")]
        public IActionResult CheckDroneLoading(int droneId)
        {
            return Ok(_droneCheckingLoads.Execute(droneId));
        }

        [HttpGet("{droneId}/batteryLevel")]
        public IActionResult CheckDroneBattery(int droneId)
        {
            return Ok(_droneBattery.Execute(droneId));
        }

        [HttpGet("available")]
        public IActionResult CheckAvailableDrones()
        {
            return Ok(_availableDrones.Execute());
        }
    }
}