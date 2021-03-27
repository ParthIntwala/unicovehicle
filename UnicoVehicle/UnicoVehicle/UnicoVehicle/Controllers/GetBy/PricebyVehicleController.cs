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
    public class PricebyVehicleController : Controller
    {
        private readonly IVehiclePriceBLL _vehiclePriceBll;

        public PricebyVehicleController(IVehiclePriceBLL vehiclePriceBLL)
        {
            _vehiclePriceBll = vehiclePriceBLL;
        }

        [HttpGet("{id}")]
        public List<VehiclePrice> GetVehiclePricebyVehicle(int id)
        {
            List<VehiclePrice> _price = _vehiclePriceBll.GetbyVehicle(id);
            return _price;
        }
    }
}