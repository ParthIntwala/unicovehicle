using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _userCommand;
        private SqlDataReader _userReader;
        int _success;

        public UserDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public User GetUserbyId(int id)
        {
            _userCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.GetUserbyId);
            _userCommand.Parameters.AddWithValue("@userId", id);
            _userReader = _userCommand.ExecuteReader();

            User _user = new User();

            while (_userReader.Read())
            {
                _user = new User()
                {
                    UserId = id,
                    UserType = new UserType
                    {
                        UserTypeId = int.Parse(_userReader["UserTypeId"].ToString()),
                    },
                    FirstName = _userReader["FirstName"].ToString(),
                    LastName = _userReader["LastName"].ToString(),
                    Email = _userReader["EmailId"].ToString(),
                };
            }

            _userReader.Close();
            _connection.CloseConnection();

            return _user;

        }public bool DeleteUser(int id)
        {
            _userCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.DeleteUser);
            _userCommand.Parameters.AddWithValue("@userId", id);
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

        public bool UpdateUser(User user, int id)
        {
            _userCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.UpdateUser);
            _userCommand.Parameters.AddWithValue("@firstName", user.FirstName);
            _userCommand.Parameters.AddWithValue("@lastName", user.LastName);
            _userCommand.Parameters.AddWithValue("@userId", id);
            _userCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

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
