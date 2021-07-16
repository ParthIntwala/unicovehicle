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
    public class VariantbyCompanyController : Controller
    {
        private readonly IVehicleVariantBLL _vehicleVariantBll;
        
        public VariantbyCompanyController(IVehicleVariantBLL vehicleVariantBLL)
        {
            _vehicleVariantBll = vehicleVariantBLL;
        }

        [HttpGet("{Id}")]
        public List<VehicleVariant> GetVehicleVariantbyCompany(int id)
        {
            List<VehicleVariant> _vehicleVariants = _vehicleVariantBll.Get(id);
            return _vehicleVariants;
        }
    }
}
