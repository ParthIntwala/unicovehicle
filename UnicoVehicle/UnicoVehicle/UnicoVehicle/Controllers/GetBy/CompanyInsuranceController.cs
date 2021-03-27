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
    public class CompanyInsuranceController : Controller
    {
        private readonly IInsuranceTypeBLL _insuranceTypeBll;

        public CompanyInsuranceController(IInsuranceTypeBLL insuranceTypeBll)
        {
            _insuranceTypeBll = insuranceTypeBll;
        }

        [HttpGet("{id}")]
        public List<InsuranceType> GetInsuranceTypebyCompany(int id)
        {
            List<InsuranceType> _insuranceType = _insuranceTypeBll.Get(id);
            return _insuranceType;
        }
    }
}
