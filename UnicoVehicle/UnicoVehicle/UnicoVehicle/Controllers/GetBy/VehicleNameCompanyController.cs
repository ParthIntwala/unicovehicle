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
    public class VehicleNameCompanyController : Controller
    {
        private readonly IVehicleNameBLL _vehicleNameBll;

        public VehicleNameCompanyController(IVehicleNameBLL vehicleNameBLL)
        {
            _vehicleNameBll = vehicleNameBLL;
        }

        [HttpGet("{id}")]
        public List<VehicleName> GetVehiclebyName(int Id)
        {
            List<VehicleName> vehicleName = _vehicleNameBll.Get(Id);
            return vehicleName;
        }
    }
}