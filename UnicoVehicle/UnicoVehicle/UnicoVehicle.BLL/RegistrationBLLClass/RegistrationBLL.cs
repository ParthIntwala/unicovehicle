using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class RegistrationBLL : IRegistrationBLL
    {
        private readonly IRegistrationDAL _registrationDAL;
        bool _status;

        public RegistrationBLL(IRegistrationDAL registrationDAL)
        {
            _registrationDAL = registrationDAL;
        }

        public string Registration(RegisterUser register)
        {
            int userId = _registrationDAL.GetUser(register.Email);

            if (userId != -1)
            {
                return "User Already Exists! Try Logging In";
            }

            _status = _registrationDAL.RegisterUser(register);

            if (_status)
            {
                return "Registration Successful";
            }
            else
            {
                return "Registration Unsuccesful";
            }
        }

        public RegisterUser Login(RegisterUser login)
        {
            int userId = _registrationDAL.GetUser(login.Email);

            if (userId == -1)
            {
                return new RegisterUser
                {
                    UserId = -1,
                };
            }

            RegisterUser user = _registrationDAL.Login(login);

            return user;
        }

        public bool UpdatePassword(string password, int userId)
        {
            _status = _registrationDAL.UpdateUserPassword(password, userId);
            return _status;
        }
    }
}

