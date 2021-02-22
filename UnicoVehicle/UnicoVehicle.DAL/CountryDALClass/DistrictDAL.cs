using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class DistrictDAL : IDistrictDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _districtCommand;
        private SqlDataReader _districtReader;
        int _success;

        public DistrictDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<District> GetDistrict()
        {
            _districtCommand = _utils.CommandGenerator(ResourceFiles.CountryDALResources.GetDistrict);
            _districtReader = _districtCommand.ExecuteReader();

            District _district;
            List<District> _districts = new List<District>();

            while (_districtReader.Read())
            {
                _district = new District()
                {
                    DistrictId = int.Parse(_districtReader["DistrictId"].ToString()),
                    DistrictName = _districtReader["District"].ToString(),


                    StateName = new State()
                    {
                        StateId = int.Parse(_districtReader["StateId"].ToString()),
                    },
                };

                _districts.Add(_district);
            }

            _districtReader.Close();
            _connection.CloseConnection();

            return _districts;
        }

        public District GetDistrictbyId(int id)
        {
            _districtCommand = _utils.CommandGenerator(ResourceFiles.CountryDALResources.GetDistrictbyId);
            _districtCommand.Parameters.AddWithValue("@districtId", id);
            _districtReader = _districtCommand.ExecuteReader();
            District _district = new District();

            while (_districtReader.Read())
            {
                _district = new District()
                {
                    DistrictId = int.Parse(_districtReader["DistrictId"].ToString()),
                    DistrictName = _districtReader["District"].ToString(),


                    StateName = new State()
                    {
                        StateId = int.Parse(_districtReader["StateId"].ToString()),
                    },
                };
            }

            _districtReader.Close();
            _connection.CloseConnection();

            return _district;

        }

        public bool InsertDistrict(string district, int stateId)
        {
            _districtCommand = _utils.CommandGenerator(ResourceFiles.CountryDALResources.InsertDistrict);
            _districtCommand.Parameters.AddWithValue("@district", district);
            _districtCommand.Parameters.AddWithValue("@stateId", stateId);
            _districtCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _districtCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDistrict(int id)
        {
            _districtCommand = _utils.CommandGenerator(ResourceFiles.CountryDALResources.DeleteDistrict);
            _districtCommand.Parameters.AddWithValue("@districtId", id);
            _districtCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _districtCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
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

