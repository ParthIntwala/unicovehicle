using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            List<Country> _allCountries = _countryBll.get();
            return _allCountries;
        }

        [HttpGet("{Id}")]
        public Country GetCountriesbyId(int id)
        {
            Country _country = _countryBll.getCountrybyId(id);
            return _country;
        }

        [HttpPost]
        public bool insertCountry([FromBody]Country country)
        {
            _status = _countryBll.insertCountry(country.CountryName);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool deleteCountry(int id)
        {
            _status = _countryBll.deleteCountry(id);
            return _status;
        }
    }
}
