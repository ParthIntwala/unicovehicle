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
    public class DistrictController : Controller
    {
        private readonly IDistrictBLL _districtBLL;
        bool _status;

        public DistrictController(IDistrictBLL districtBll)
        {
            _districtBLL = districtBll;
        }

        [HttpPost]
        public bool InsertDistrict([FromBody] District district)
        {
            _status = _districtBLL.InsertDistrict(district.DistrictName, district.State.StateId);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteDistrict(int id)
        {
            _status = _districtBLL.DeleteDistrict(id);
            return _status;
        }
    }
}
