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
    public class VehiclebyNameController : Controller
    {
        private readonly IVehicleBLL _vehicleBll;
        
        public VehiclebyNameController(IVehicleBLL vehicleBLL)
        {
            _vehicleBll = vehicleBLL;
        }

        [HttpGet("{id}")]
        public List<Vehicle> GetVehiclebyName(int id)
        {
            List<Vehicle> vehicle = _vehicleBll.GetVehiclebyName(id);
            return vehicle;
        }
    }
}