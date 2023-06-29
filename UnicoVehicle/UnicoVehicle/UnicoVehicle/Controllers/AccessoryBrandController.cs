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
    public class AccessoryBrandController : Controller
    {
        private readonly IAccessoryBrandBLL _accessoryBrandBLL;
        bool _status;

        public AccessoryBrandController(IAccessoryBrandBLL accessoryBrandBLL)
        {
            _accessoryBrandBLL = accessoryBrandBLL;
        }

        [HttpGet]
        public List<AccessoryBrand> GetAccessoryBrand()
        {
            List<AccessoryBrand> _accessoryBrands = _accessoryBrandBLL.Get();
            return _accessoryBrands;
        }

        [HttpPost]
        public bool InsertAccessoryBrand([FromBody] AccessoryBrand accessoryBrand)
        {
            _status = _accessoryBrandBLL.InsertTransmissionType(accessoryBrand.AccessoryBrandName);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteAccessoryBrand(int id)
        {
            _status = _accessoryBrandBLL.DeleteTransmissionType(id);
            return _status;
        }
    }
}
