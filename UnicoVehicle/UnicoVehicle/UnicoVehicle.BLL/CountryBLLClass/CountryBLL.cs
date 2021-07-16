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

        public List<Country> Get()
        {
            List<Country> _countries = _countryDAL.GetCountry();

            return _countries;
        }

        public bool InsertCountry(string country)
        {
            _status = _countryDAL.InsertCountry(country);
            return _status;
        }

        public bool DeleteCountry(int id)
        {
            _status = _countryDAL.DeleteCountry(id);
            return _status;
        }
    }
}
