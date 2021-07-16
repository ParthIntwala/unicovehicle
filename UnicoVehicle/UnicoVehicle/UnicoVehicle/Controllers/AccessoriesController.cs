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
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesBLL _accessoriesBLL;
        bool _status;

        public AccessoriesController(IAccessoriesBLL accessoriesBLL)
        {
            _accessoriesBLL = accessoriesBLL;
        }

        [HttpGet]
        public List<Accessories> GetAccessories()
        {
            List<Accessories> accessories = _accessoriesBLL.Get();
            return accessories;
        }

        [HttpPost]
        public bool InsertAccessories([FromBody] Accessories accessories)
        {
            _status = _accessoriesBLL.InsertAccessories(accessories);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteAccessories(int id)
        {
            _status = _accessoriesBLL.DeleteAccessories(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateAccessories([FromBody] Accessories accessories, int id)
        {
            _status = _accessoriesBLL.UpdateAccessories(accessories, id);
            return _status;
        }
    }
}
