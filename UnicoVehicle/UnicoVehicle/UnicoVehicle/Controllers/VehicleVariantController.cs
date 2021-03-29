using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleVariantController : Controller
    {
        private readonly IVehicleVariantBLL _vehicleVariantBll;
        bool _status;

        public VehicleVariantController(IVehicleVariantBLL vehicleVariantBLL)
        {
            _vehicleVariantBll = vehicleVariantBLL;
        }

        [HttpGet("{Id}")]
        public VehicleVariant GetVehicleVariantsbyId(int id)
        {
            VehicleVariant _vehicleVariant = _vehicleVariantBll.GetVehicleVariantbyId(id);
            return _vehicleVariant;
        }

        [HttpPost]
        public bool InsertVehicleVariant([FromBody] VehicleVariant vehicleVariant)
        {
            _status = _vehicleVariantBll.InsertVehicleVariant(vehicleVariant);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteVehicleVariant(int id)
        {
            _status = _vehicleVariantBll.DeleteVehicleVariant(id);
            return _status;
        }
    }
}
