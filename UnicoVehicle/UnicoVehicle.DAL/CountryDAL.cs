using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class CountryDAL : ICountryDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _countryCommand;
        private SqlDataReader _countryReader;
        int _success;

        public CountryDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<Country> getCountry()
        {
            _countryCommand = _utils.CommandGenerator(DALResources.GetCountry);
            _countryReader = _countryCommand.ExecuteReader();

            Country _country;
            List<Country> _countries = new List<Country>();

            while (_countryReader.Read())
            {
                _country = new Country()
                {
                    CountryId = int.Parse(_countryReader["CountryId"].ToString()),
                    CountryName = _countryReader["Country"].ToString(),
                };

                _countries.Add(_country);
            }

            _countryReader.Close();
            _connection.CloseConnection();

            return _countries;
        }

        public Country getCountrybyId(int id)
        {
            _countryCommand = _utils.CommandGenerator(DALResources.GetCountrybyId);
            _countryCommand.Parameters.AddWithValue("@countryId", id);
            _countryReader = _countryCommand.ExecuteReader();
            Country _country = new Country();

            while (_countryReader.Read())
            {
                _country = new Country
                {
                    CountryName = _countryReader["Country"].ToString(),
                    CountryId = id,
                };
            }

            _countryReader.Close();
            _connection.CloseConnection();

            return _country;

        }

        public bool insertCountry(string country)
        {
            _countryCommand = _utils.CommandGenerator(DALResources.InsertCountry);
            _countryCommand.Parameters.AddWithValue("@country", country);
            _countryCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _countryCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if(_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
