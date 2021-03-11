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
    public class VehiclebyTypeController : Controller
    {
        private readonly IVehicleBLL _vehicleBll;

        public VehiclebyTypeController(IVehicleBLL vehicleBLL)
        {
            _vehicleBll = vehicleBLL;
        }

        [HttpGet]
        public List<Vehicle> GetVehiclebyType(int id, int nameId)
        {
            List<Vehicle> vehicle = _vehicleBll.GetVehiclebyVehicleType(id, nameId);
            return vehicle;
        }
    }
}