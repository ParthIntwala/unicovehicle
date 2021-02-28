using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class UserTypeBLL : IUserTypeBLL
    {
        private readonly IUserTypeDAL _userTypeDAL;
        bool _status;

        public UserTypeBLL(IUserTypeDAL userTypeDAL)
        {
            _userTypeDAL = userTypeDAL;
        }

        public List<UserType> Get()
        {
            List<UserType> _userTypes = _userTypeDAL.GetUserType();
            return _userTypes;
        }

        public UserType GetUserTypebyId(int id)
        {
            UserType _userType = _userTypeDAL.GetUserTypebyId(id);
            return _userType;
        }

        public bool InsertUserType(string userType)
        {
            _status = _userTypeDAL.InsertUserType(userType);
            return _status;
        }

        public bool DeleteUserType(int id)
        {
            _status = _userTypeDAL.DeleteUserType(id);
            return _status;
        }
    }
}
