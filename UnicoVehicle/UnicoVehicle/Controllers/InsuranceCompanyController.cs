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
    public class InsuranceCompanyController : Controller
    {
        private readonly IInsuranceCompanyBLL _insuranceCompanyBll;
        bool _status;

        public InsuranceCompanyController(IInsuranceCompanyBLL insuranceCompanyBll)
        {
            _insuranceCompanyBll = insuranceCompanyBll;
        }

        [HttpGet]
        public List<InsuranceCompany> GetInsuranceCompany()
        {
            List<InsuranceCompany> _insuranceCompany = _insuranceCompanyBll.Get();
            return _insuranceCompany;
        }

        [HttpGet("{Id}")]
        public InsuranceCompany GetInsuranceCompanybyId(int id)
        {
            InsuranceCompany _insuranceCompany = _insuranceCompanyBll.GetInsuranceCompanybyId(id);
            return _insuranceCompany;
        }

        [HttpPost]
        public bool InsertInsuranceCompany([FromBody] InsuranceCompany insuranceCompany)
        {
            _status = _insuranceCompanyBll.InsertInsuranceCompany(insuranceCompany);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteInsuranceCompany(int id)
        {
            _status = _insuranceCompanyBll.DeleteInsuranceCompany(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateInsuranceCompany(int id, [FromBody] InsuranceCompany insuranceCompany)
        {
            _status = _insuranceCompanyBll.UpdateInsuranceCompany(insuranceCompany, id);
            return _status;
        }
    }
}
