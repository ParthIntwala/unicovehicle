using System;
using System.Data.SqlClient;
using UnicoVehicle.DTO.Miscellaneous;
using UnicoVehicle.Utilities;

namespace UnicoVehicle.DAL
{
    public class MiscellaneousCallsDAL : IMiscellaneousCallsDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _command;
        private SqlDataReader _reader;
        int _success;

        public MiscellaneousCallsDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public District GetDistrictbyId(int id)
        {
            _command = _utils.CommandGenerator(ResourceFiles.MescellaneousResources.GetDistrictbyId);
            _command.Parameters.AddWithValue("@districtId", id);
            _reader = _command.ExecuteReader();

            District _district = new District();

            while (_reader.Read())
            {
                _district = new District()
                {
                    DistrictId = id,
                    DistrictName = _reader["District"].ToString(),
                };
            }

            _reader.Close();
            _connection.CloseConnection();

            return _district;
        }

        public Company GetCompanybyId(int id)
        {
            _command = _utils.CommandGenerator(ResourceFiles.MescellaneousResources.GetCompanybyId);
            _command.Parameters.AddWithValue("@companyId", id);
            _reader = _command.ExecuteReader();

            Company _company = new Company();

            while (_reader.Read())
            {
                _company = new Company()
                {
                    CompanyId = id,
                    CompanyName = _reader["CompanyName"].ToString(),
                };
            }

            _reader.Close();
            _connection.CloseConnection();

            return _company;
        }

        public InsuranceCompany GetInsuranceCompanybyId(int id)
        {
            _command = _utils.CommandGenerator(ResourceFiles.MescellaneousResources.GetInsuranceCompanybyId);
            _command.Parameters.AddWithValue("@insuranceCompanyId", id);
            _reader = _command.ExecuteReader();

            InsuranceCompany _insuranceCompany = new InsuranceCompany();

            while (_reader.Read())
            {
                _insuranceCompany = new InsuranceCompany()
                {
                    InsuranceCompanyId = id,
                    InsuranceCompanyName = _reader["InsuranceCompany"].ToString(),
                };
            }

            _reader.Close();
            _connection.CloseConnection();

            return _insuranceCompany;
        }

        public State GetStatebyId(int id)
        {
            _command = _utils.CommandGenerator(ResourceFiles.MescellaneousResources.GetStatebyId);
            _command.Parameters.AddWithValue("@stateId", id);
            _reader = _command.ExecuteReader();

            State _state = new State();

            while (_reader.Read())
            {
                _state = new State()
                {
                    StateId = id,
                    StateName = _reader["State"].ToString(),
                };
            }

            _reader.Close();
            _connection.CloseConnection();

            return _state;
        }

        public Showroom GetShowroombyId(int id)
        {
            _command = _utils.CommandGenerator(ResourceFiles.MescellaneousResources.GetShowroombyId);
            _command.Parameters.AddWithValue("@showroomId", id);
            _reader = _command.ExecuteReader();

            Showroom _showroom = new Showroom();

            while (_reader.Read())
            {
                _showroom = new Showroom()
                {
                    ShowroomId = id,
                    ShowroomName = _reader["ShowroomName"].ToString(),
                    Company = new Company
                    {
                        CompanyId = int.Parse(_reader["CompanyId"].ToString()),
                    },
                    District = new District
                    {
                        DistrictId = int.Parse(_reader["DistrictId"].ToString()),
                    }
                };
            }

            _reader.Close();
            _connection.CloseConnection();

            return _showroom;
        }

        public Vehicle GetVehiclebyId(int id)
        {
            _command = _utils.CommandGenerator(ResourceFiles.MescellaneousResources.GetVehiclebyId);
            _command.Parameters.AddWithValue("@vehicleId", id);
            _reader = _command.ExecuteReader();

            Vehicle _vehicle = new Vehicle();

            while (_reader.Read())
            {
                _vehicle = new Vehicle()
                {
                    VehicleId = id,
                    VehicleName = new DTO.VehicleName
                    {
                        VehicleNameId = int.Parse(_reader["VehicleNameId"].ToString()),
                    },
                    VehicleVariant = new DTO.VehicleVariant
                    {
                        VehicleVariantId = int.Parse(_reader["VehicleVariantId"].ToString()),
                    }
                };
            }

            _reader.Close();
            _connection.CloseConnection();

            return _vehicle;
        }

        public User GetUserbyId(int id)
        {
            _command = _utils.CommandGenerator(ResourceFiles.MescellaneousResources.GetUserbyId);
            _command.Parameters.AddWithValue("@userId", id);
            _reader = _command.ExecuteReader();

            User _user = new User();

            while (_reader.Read())
            {
                _user = new User()
                {
                    UserId = id,
                    FirstName = _reader["FirstName"].ToString(),
                    LastName = _reader["LastName"].ToString()
                };
            }

            _reader.Close();
            _connection.CloseConnection();

            return _user;
        }
    }
}
