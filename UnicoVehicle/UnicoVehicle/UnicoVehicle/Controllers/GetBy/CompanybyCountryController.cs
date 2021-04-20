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
    public class CompanybyCountryController : Controller
    {
        private readonly ICompanyCountryBLL _companyCountryBll;

        public CompanybyCountryController(ICompanyCountryBLL companyCountryBll)
        {
            _companyCountryBll = companyCountryBll;
        }

        [HttpGet("{Id}")]
        public List<CompanyCountry> GetCompanybyCountry(int Id)
        {
            List<CompanyCountry> _company = _companyCountryBll.GetCompanybyCountry(Id);
            return _company;
        }
    }
}

