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
    public class FuelTypeController : Controller
    {
        private readonly IFuelTypeBLL _fuelTypeBll;
        bool _status;

        public FuelTypeController(IFuelTypeBLL fuelTypeBll)
        {
            _fuelTypeBll = fuelTypeBll;
        }

        [HttpGet]
        public List<FuelType> GetFuelTypes()
        {
            List<FuelType > _allFuelTypes = _fuelTypeBll.Get();
            return _allFuelTypes;
        }

        [HttpPost]
        public bool InsertFuelType([FromBody] FuelType fuelType)
        {
            _status = _fuelTypeBll.InsertFuelType(fuelType.FuelTypeName);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteFuelType(int id)
        {
            _status = _fuelTypeBll.DeleteFuelType(id);
            return _status;
        }
    }
}
