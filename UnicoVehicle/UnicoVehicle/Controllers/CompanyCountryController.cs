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
    public class CompanyCountryController : Controller
    {
        private readonly ICompanyCountryBLL _companyCountryBll;
        bool _status;

        public CompanyCountryController(ICompanyCountryBLL companyCountryBll)
        {
            _companyCountryBll = companyCountryBll;
        }

        [HttpGet]
        public List<CompanyCountry> GetCompanyCountry()
        {
            List<CompanyCountry> _allCompanies = _companyCountryBll.Get();
            return _allCompanies;
        }

        [HttpGet("{Id}")]
        public CompanyCountry GetCompanyCountrybyId(int id)
        {
            CompanyCountry _company = _companyCountryBll.GetCompanyCountrybyId(id);
            return _company;
        }

        [HttpPost]
        public bool InsertCompanyCountry([FromBody] CompanyCountry company)
        {
            _status = _companyCountryBll.InsertCompanyCountry(company);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteCompanyCountry(int id)
        {
            _status = _companyCountryBll.DeleteCompanyCountry(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool DeleteCompanyCountry(CompanyCountry company, int id)
        {
            _status = _companyCountryBll.UpdateCompanyCountry(company, id);
            return _status;
        }
    }
}
