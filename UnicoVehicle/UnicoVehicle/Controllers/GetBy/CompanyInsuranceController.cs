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

        [HttpGet]
        public List<InsuranceType> GetInsuranceType(int companyId)
        {
            List<InsuranceType> _insuranceType = _insuranceTypeBll.Get(companyId);
            return _insuranceType;
        }
    }
}
