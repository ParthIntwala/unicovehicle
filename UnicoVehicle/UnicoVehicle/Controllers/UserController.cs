using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserBLL _userBll;
        bool _status;

        public UserController(IUserBLL userBLL)
        {
            _userBll = userBLL;
        }

        [HttpGet]
        public List<User> GetUser()
        {
            List<User> _users = _userBll.Get();
            return _users;
        }

        [HttpGet("{Id}")]
        public User GetUserbyId(int id)
        {
            User _user = _userBll.GetUserbyId(id);
            return _user;
        }

        [HttpPost]
        public bool InsertUser([FromBody] User user)
        {
            _status = _userBll.InsertUser(user);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteUser(int id)
        {
            _status = _userBll.DeleteUser(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateUser([FromBody] User user, int id)
        {
            _status = _userBll.UpdateUser(user, id);
            return _status;
        }
    }
}
