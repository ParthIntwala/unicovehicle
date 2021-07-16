using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;
using UnicoVehicle;
using Microsoft.AspNetCore.Authorization;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationBLL _registrationBll;
        bool _status;

        public RegistrationController(IRegistrationBLL registrationBLL)
        {
            _registrationBll = registrationBLL;
        }

        [HttpGet]
        public string Login(RegisterUser login)
        {
            RegisterUser _user = _registrationBll.Login(login);

            if(_user.UserId == -1)
            {
                return "You are not Registered! Consider, registering yourself before you try to log in again";
            }

            if (_user.UserId == 0)
            {
                return "Password Incorrect!";
            }

            string token = Authenticate.GenerateJSONWebToken(_user);

            return token;
        }

        [HttpPost]
        public string Register(RegisterUser register)
        {
            string status = _registrationBll.Registration(register);
            return status;
        }

        [HttpPut("{Id}")]
        public bool UpdatePassword([FromBody] RegisterUser user, int id)
        {
            _status = _registrationBll.UpdatePassword(user.Password, id);
            return true;
        }
    }
}

