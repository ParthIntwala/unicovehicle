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
    public class InsuranceTypeController : Controller
    {
        private readonly IInsuranceTypeBLL _insuranceTypeBll;
        bool _status;

        public InsuranceTypeController(IInsuranceTypeBLL insuranceTypeBll)
        {
            _insuranceTypeBll = insuranceTypeBll;
        }

        [HttpGet]
        public List<InsuranceType> GetInsuranceTypes()
        {
            List<InsuranceType> _insuranceType = _insuranceTypeBll.Get();
            return _insuranceType;
        }

        [HttpGet("{Id}")]
        public InsuranceType GetInsuranceTypebyId(int id)
        {
            InsuranceType _insuranceType = _insuranceTypeBll.GetInsuranceTypebyId(id);
            return _insuranceType;
        }

        [HttpPost]
        public bool InsertInsuranceType([FromBody] InsuranceType insuranceType)
        {
            _status = _insuranceTypeBll.InsertInsuranceType(insuranceType);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteInsuranceType(int id)
        {
            _status = _insuranceTypeBll.DeleteInsuranceType(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateInsuranceType(int id, [FromBody] InsuranceType insuranceType)
        {
            _status = _insuranceTypeBll.UpdateInsuranceType(insuranceType, id);
            return _status;
        }
    }
}
