using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class CountryBll : ICountryBll
    {
        private readonly ICountryDAL _countryDAL;
        bool _status;

        public CountryBll(ICountryDAL countryDAL)
        {
            _countryDAL = countryDAL;
        }

        public List<Country> get()
        {
            List<Country> _countries = _countryDAL.getCountry();

            return _countries;
        }

        public Country getCountrybyId(int id)
        {
            Country _country = _countryDAL.getCountrybyId(id);
            return _country;
        }

        public bool insertCountry(string country)
        {
            _status = _countryDAL.insertCountry(country);
            return _status;
        }

        public bool deleteCountry(int id)
        {
            _status = _countryDAL.deleteCountry(id);
            return _status;
        }
    }
}
