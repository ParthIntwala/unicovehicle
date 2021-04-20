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
    public class CompanyController : Controller
    {
        private readonly ICompanyBLL _companyBll;
        bool _status;

        public CompanyController(ICompanyBLL companyBll)
        {
            _companyBll = companyBll;
        }

        [HttpGet]
        public List<Company> GetCompanys()
        {
            List<Company> _allCompanies = _companyBll.Get();
            return _allCompanies;
        }

        [HttpGet("{Id}")]
        public Company GetCompanybyId(int id)
        {
            Company _company = _companyBll.GetCompanybyId(id);
            return _company;
        }

        [HttpPost]
        public bool InsertCompany([FromBody] Company company)
        {
            _status = _companyBll.InsertCompany(company);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteCompany(int id)
        {
            _status = _companyBll.DeleteCompany(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateCompany([FromBody] Company company, int id)
        {
            _status = _companyBll.UpdateCompany(company, id);
            return _status;
        }
    }
}
