using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace UnicoVehicle.DAL
{
    public class UserTypeDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _userCommand;
        private SqlDataReader _userReader;
        int _success;

        public UserTypeDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<UserType> GetUserType()
        {
            _userCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetVehicleType);
            _userReader = _userCommand.ExecuteReader();

            UserType _userType;
            List<UserType> _userTypes = new List<UserType>();

            while (_userReader.Read())
            {
                _userType = new UserType()
                {
                    UserTypeId = int.Parse(_userReader["VehicleTypeId"].ToString()),
                    UsersType = _userReader["VehicleType"].ToString(),
                };

                _userTypes.Add(_userType);
            }

            _userReader.Close();
            _connection.CloseConnection();

            return _userTypes;
        }

        public UserType GetUserTypebyId(int id)
        {
            _userCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetVehicleTypebyId);
            _userCommand.Parameters.AddWithValue("@vehicleTypeId", id);
            _userReader = _userCommand.ExecuteReader();

            UserType _userType = new UserType();

            while (_userReader.Read())
            {
                _userType = new UserType
                {
                    UsersType = _userReader["VehicleType"].ToString(),
                    UserTypeId = id,
                };
            }

            _userReader.Close();
            _connection.CloseConnection();

            return _userType;

        }

        public bool InsertUserType(string vehicleType)
        {
            _userCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertVehicleType);
            _userCommand.Parameters.AddWithValue("@vehicleType", vehicleType);
            _userCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _userCommand.ExecuteNonQuery();
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

        public bool DeleteUserType(int id)
        {
            _userCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteVehicleType);
            _userCommand.Parameters.AddWithValue("@vehicleTypeId", id);
            _userCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _userCommand.ExecuteNonQuery();
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
