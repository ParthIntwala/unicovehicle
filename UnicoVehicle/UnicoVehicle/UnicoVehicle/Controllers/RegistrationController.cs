using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;
using UnicoVehicle;

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
        public string Login(LoginUser login)
        {
            LoginUser _user = _registrationBll.Login(login);

            if(_user.UserId == -1)
            {
                return "You are not Registered! Consider, registering yourself before you try to log in again";
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
        public bool UpdatePassword([FromBody] string password, int id)
        {
            _status = _registrationBll.UpdatePassword(password, id);
            return _status;
        }
    }
}

