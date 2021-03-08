//using System;
//using UnicoVehicle.Utilities;
//using System.Data.SqlClient;
//using UnicoVehicle.DTO.Miscellaneous;

//namespace UnicoVehicle.DAL
//{
//    public class VehicleNameDAL
//    {
//        private readonly Connection _connection;
//        private readonly IUtils _utils;
//        private SqlCommand _userCommand;
//        private SqlDataReader _userReader;
//        int _success;

//        public VehicleNameDAL(Connection connection, IUtils utils)
//        {
//            _utils = utils;
//            _connection = connection;
//        }

//        public User GetUserbyId(int id)
//        {
//            _userCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetUserbyId);
//            _userCommand.Parameters.AddWithValue("@userId", id);
//            _userReader = _userCommand.ExecuteReader();

//            User _user = new User();

//            while (_userReader.Read())
//            {
//                _user = new DTO.Miscellaneous.User()
//                {
//                    UserId = id,
//                    UserType = new DTO.UserType
//                    {
//                        UserTypeId = int.Parse(_userReader["UserTypeId"].ToString()),
//                    },
//                    FirstName = _userReader["FirstName"].ToString(),
//                    LastName = _userReader["LastName"].ToString(),
//                };
//            }

//            _userReader.Close();
//            _connection.CloseConnection();

//            return _user;

//        }
//        public bool DeleteUser(int id)
//        {
//            _userCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.DeleteUser);
//            _userCommand.Parameters.AddWithValue("@userId", id);
//            _userCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

//            _success = _userCommand.ExecuteNonQuery();
//            _connection.CloseConnection();

//            if (_success > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public bool UpdateUser(User user, int id)
//        {
//            _userCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateUser);
//            _userCommand.Parameters.AddWithValue("@firstName", user.FirstName);
//            _userCommand.Parameters.AddWithValue("@lastName", user.LastName);
//            _userCommand.Parameters.AddWithValue("@userId", id);
//            _userCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

//            _success = _userCommand.ExecuteNonQuery();
//            _connection.CloseConnection();

//            if (_success > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }
//}
