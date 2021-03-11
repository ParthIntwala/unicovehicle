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
    public class VehiclebyVariantController : Controller
    {
        private readonly IVehicleBLL _vehicleBll;

        public VehiclebyVariantController(IVehicleBLL vehicleBLL)
        {
            _vehicleBll = vehicleBLL;
        }

        [HttpGet]
        public Vehicle GetVehiclebyVariant(int id, int nameId)
        {
            Vehicle vehicle = _vehicleBll.GetVehiclebyVariant(id, nameId);
            return vehicle;
        }
    }
}