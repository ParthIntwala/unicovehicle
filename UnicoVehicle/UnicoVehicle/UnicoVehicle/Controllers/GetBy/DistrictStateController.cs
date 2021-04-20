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
    public class DistrictStateController : Controller
    {
        private readonly IDistrictBLL _districtBLL;
        
        public DistrictStateController(IDistrictBLL districtBll)
        {
            _districtBLL = districtBll;
        }

        [HttpGet("{Id}")]
        public List<District> GetDistrictbyState(int id)
        {
            List<District> _allDistricts = _districtBLL.Get(id);
            return _allDistricts;
        }
    }
}
