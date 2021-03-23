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
    public class VehiclePriceController : Controller
    {
        private readonly IVehiclePriceBLL _vehiclePriceBll;
        bool _status;

        public VehiclePriceController(IVehiclePriceBLL vehiclePriceBll)
        {
            _vehiclePriceBll = vehiclePriceBll;
        }

        [HttpGet("{id}")]
        public List<VehiclePrice> GetVehiclePricebyShowroom(int id)
        {
            List<VehiclePrice> _price = _vehiclePriceBll.GetbyShowroom(id);
            return _price;
        }

        [HttpPost]
        public bool InsertVehiclePrice([FromBody] VehiclePrice vehiclePrice)
        {
            _status = _vehiclePriceBll.InsertVehiclePrice(vehiclePrice);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool DeleteVehiclePrice([FromBody] VehiclePrice vehiclePrice, int id)
        {
            _status = _vehiclePriceBll.UpdateVehiclePrice(vehiclePrice, id);
            return _status;
        }
    }
}
