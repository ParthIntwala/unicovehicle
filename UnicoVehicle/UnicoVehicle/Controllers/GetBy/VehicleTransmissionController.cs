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
    public class VehicleTransmissionController : Controller
    {
        private readonly IVehicleBLL _vehicleBll;

        public VehicleTransmissionController(IVehicleBLL vehicleBLL)
        {
            _vehicleBll = vehicleBLL;
        }

        [HttpGet("{id}")]
        public List<Vehicle> GetVehiclebyTransmission(int id, int nameId)
        {
            List<Vehicle> vehicle = _vehicleBll.GetVehiclebyTransmission(id, nameId);
            return vehicle;
        }
    }
}