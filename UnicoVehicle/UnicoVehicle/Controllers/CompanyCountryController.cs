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

        [HttpGet("{Id}")]
        public CompanyCountry GetCompanyCountrybyId(int id)
        {
            CompanyCountry _company = _companyCountryBll.GetCompanyCountrybyId(id);
            return _company;
        }

        [HttpGet]
        public List<CompanyCountry> GetCompanybyCountry(int countryId)
        {
            List<CompanyCountry> _company = _companyCountryBll.GetCompanybyCountry(countryId);
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
        public bool UpdateCompanyCountry([FromBody] CompanyCountry company, int id)
        {
            _status = _companyCountryBll.UpdateCompanyCountry(company, id);
            return _status;
        }
    }
}
