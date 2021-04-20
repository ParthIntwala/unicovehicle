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
    public class AccessoriesTypeController : Controller
    {
        private readonly IAccessoriesTypeBLL _accessoriesBll;
        bool _status;

        public AccessoriesTypeController(IAccessoriesTypeBLL accessoriesBll)
        {
            _accessoriesBll = accessoriesBll;
        }

        [HttpGet]
        public List<AccessoriesType> GetAccessoriesTypes()
        {
            List<AccessoriesType> _allaccessoriesTypes = _accessoriesBll.Get();
            return _allaccessoriesTypes;
        }

        [HttpGet("{Id}")]
        public AccessoriesType GetAccessoriesTypebyId(int id)
        {
            AccessoriesType _accessoriesType = _accessoriesBll.GetAccessoriesTypebyId(id);
            return _accessoriesType;
        }

        [HttpPost]
        public bool InsertAccessoriesType([FromBody] AccessoriesType accessoriesType)
        {
            _status = _accessoriesBll.InsertAccessoriesType(accessoriesType.Accessories);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteAccessoriesType(int id)
        {
            _status = _accessoriesBll.DeleteAccessoriesType(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateAccessoriesType(int id, [FromBody] AccessoriesType accessoriesType)
        {
            _status = _accessoriesBll.UpdateAccessoriesType(accessoriesType.Accessories, id);
            return _status;
        }
    }
}
