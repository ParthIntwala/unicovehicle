using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class RegistrationDAL : IRegistrationDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _registerCommand;
        private SqlDataReader _registerReader;
        int _success;

        public RegistrationDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public int GetUser(string Email)
        {
            _registerCommand = _utils.CommandGenerator(ResourceFiles.RegistrationDALResources.UserExist);
            _registerCommand.Parameters.AddWithValue("@emailId", Email.ToLower());
            _registerReader = _registerCommand.ExecuteReader();

            int userId = -1;

            while (_registerReader.Read())
            {
                userId = int.Parse(_registerReader["UserId"].ToString());
            }

            _registerReader.Close();
            _connection.CloseConnection();

            return userId;
        }

        public bool RegisterUser(RegisterUser register)
        {
            _registerCommand = _utils.CommandGenerator(ResourceFiles.RegistrationDALResources.RegisterUser);
            _registerCommand.Parameters.AddWithValue("@userTypeId", register.UserTypeId);
            _registerCommand.Parameters.AddWithValue("@fistName", register.FirstName);
            _registerCommand.Parameters.AddWithValue("@lastName", register.LastName);
            _registerCommand.Parameters.AddWithValue("@emailId", register.Email);
            _registerCommand.Parameters.AddWithValue("@password", register.Password);
            _registerCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _registerCommand.ExecuteNonQuery();
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

        public bool UpdateUserPassword(string password, int id)
        {
            _registerCommand = _utils.CommandGenerator(ResourceFiles.RegistrationDALResources.ChangePassword);
            _registerCommand.Parameters.AddWithValue("@userId", id);
            _registerCommand.Parameters.AddWithValue("@password", password);
            _registerCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _registerCommand.ExecuteNonQuery();
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

        public LoginUser Login(LoginUser login)
        {
            _registerCommand = _utils.CommandGenerator(ResourceFiles.RegistrationDALResources.Login);
            _registerCommand.Parameters.AddWithValue("@emailId", login.Email);
            _registerCommand.Parameters.AddWithValue("@password", login.Password);
            _registerReader = _registerCommand.ExecuteReader();

            LoginUser loggedIn = new LoginUser();

            while (_registerReader.Read())
            {
                loggedIn = new LoginUser
                {
                    UserId = int.Parse(_registerReader["UserId"].ToString()),
                    UserTypeId = int.Parse(_registerReader["UserTypeId"].ToString()),
                };
            }

            _registerReader.Close();
            _connection.CloseConnection();

            return loggedIn;
        }
    }
}

