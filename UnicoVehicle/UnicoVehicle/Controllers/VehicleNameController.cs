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
    public class VehicleNameController : Controller
    {
        private readonly IVehicleNameBLL _vehicleNameBll;
        bool _status;

        public VehicleNameController(IVehicleNameBLL vehicleNameBll)
        {
            _vehicleNameBll = vehicleNameBll;
        }

        [HttpGet]
        public List<VehicleName> GetVehicleName(int Id)
        {
            List<VehicleName> vehicleName = _vehicleNameBll.Get(Id);
            return vehicleName;
        }

        [HttpGet("{Id}")]
        public VehicleName GetVehicleNamebyId(int id)
        {
            VehicleName vehicleName = _vehicleNameBll.GetVehicleNamebyId(id);
            return vehicleName;
        }

        [HttpPost]
        public bool InsertVehicleName([FromBody] VehicleName vehicleName)
        {
            _status = _vehicleNameBll.InsertVehicleName(vehicleName);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteVehicleName(int id)
        {
            _status = _vehicleNameBll.DeleteVehicleName(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateVehicleName([FromBody] VehicleName vehicleName, int id)
        {
            _status = _vehicleNameBll.UpdateVehicleName(vehicleName.Name, id);
            return _status;
        }
    }
}
