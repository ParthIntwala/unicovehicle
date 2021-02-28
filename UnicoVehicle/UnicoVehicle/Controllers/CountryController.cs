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
    public class CountryController : Controller
    {
        private readonly ICountryBll _countryBll;
        bool _status;

        public CountryController(ICountryBll countryBll)
        {
            _countryBll = countryBll;
        }

        [HttpGet]
        public List<Country> GetCountries()
        {
            List<Country> _allCountries = _countryBll.Get();
            return _allCountries;
        }

        [HttpGet("{Id}")]
        public Country GetCountriesbyId(int id)
        {
            Country _country = _countryBll.GetCountrybyId(id);
            return _country;
        }

        [HttpPost]
        public bool InsertCountry([FromBody]Country country)
        {
            _status = _countryBll.InsertCountry(country.CountryName);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteCountry(int id)
        {
            _status = _countryBll.DeleteCountry(id);
            return _status;
        }
    }
}
