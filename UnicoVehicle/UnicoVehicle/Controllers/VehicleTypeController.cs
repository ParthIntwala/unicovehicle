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
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeBLL _vehicleTypeBll;
        bool _status;

        public VehicleTypeController(IVehicleTypeBLL vehicleTypeBll)
        {
            _vehicleTypeBll = vehicleTypeBll;
        }

        [HttpGet]
        public List<VehicleType> GetVehicleTypes()
        {
            List<VehicleType> _allFuelTypes = _vehicleTypeBll.Get();
            return _allFuelTypes;
        }

        [HttpGet("{Id}")]
        public VehicleType GetVehicleTypebyId(int id)
        {
            VehicleType _fuelType = _vehicleTypeBll.GetVehicleTypebyId(id);
            return _fuelType;
        }

        [HttpPost]
        public bool insertVehicleType([FromBody] VehicleType vehicleType)
        {
            _status = _vehicleTypeBll.InsertVehicleType(vehicleType.VehicleTypeName);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool deleteVehicleType(int id)
        {
            _status = _vehicleTypeBll.DeleteVehicleType(id);
            return _status;
        }
    }
}
