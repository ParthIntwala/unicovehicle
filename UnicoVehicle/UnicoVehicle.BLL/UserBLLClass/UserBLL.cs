﻿using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;
        private readonly IUserTypeBLL _userTypeBLL;
        bool _status;

        public UserBLL(IUserDAL userDAL, IUserTypeBLL userTypeBLL)
        {
            _userDAL = userDAL;
            _userTypeBLL = userTypeBLL;
        }

        public List<User> Get()
        {
            List<User> _user = _userDAL.GetUser();

            foreach (User user in _user)
            {
                user.UserType = _userTypeBLL.GetUserTypebyId(user.UserType.UserTypeId);
            }

            return _user;
        }

        public User GetUserbyId(int id)
        {
            User _user = _userDAL.GetUserbyId(id);

            if (_user.UserId != 0)
            {
                _user.UserType = _userTypeBLL.GetUserTypebyId(_user.UserType.UserTypeId);
            }

            return _user;
        }

        public bool InsertUser(User user)
        {
            _status = _userDAL.InsertUser(user);
            return _status;
        }

        public bool DeleteUser(int id)
        {
            _status = _userDAL.DeleteUser(id);
            return _status;
        }

        public bool UpdateUser(User user, int userId)
        {
            _status = _userDAL.UpdateUser(user, userId);
            return _status;
        }
    }
}
