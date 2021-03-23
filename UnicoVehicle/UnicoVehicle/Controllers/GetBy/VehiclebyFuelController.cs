using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclebyFuelController : Controller
    {
        private readonly IVehicleBLL _vehicleBll;

        public VehiclebyFuelController(IVehicleBLL vehicleBLL)
        {
            _vehicleBll = vehicleBLL;
        }

        [HttpGet("{id}")]
        public List<Vehicle> GetVehiclebyFuel(int id, int nameId)
        {
            List<Vehicle> vehicle = _vehicleBll.GetVehiclebyFuel(id, nameId);
            return vehicle;
        }
    }
}