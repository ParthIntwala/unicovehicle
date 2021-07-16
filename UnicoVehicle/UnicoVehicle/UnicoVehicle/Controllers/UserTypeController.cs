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
    public class UserTypeController : Controller
    {
        private readonly IUserTypeBLL _userTypeBll;
        bool _status;

        public UserTypeController(IUserTypeBLL userTypeBll)
        {
            _userTypeBll = userTypeBll;
        }

        [HttpGet]
        public List<UserType> GetUserTypes()
        {
            List<UserType> _allUserTypes = _userTypeBll.Get();
            return _allUserTypes;
        }

        [HttpGet("{Id}")]
        public UserType GetUserTypebyId(int id)
        {
            UserType _userType = _userTypeBll.GetUserTypebyId(id);
            return _userType;
        }

        [HttpPost]
        public bool InsertUserType([FromBody] UserType userType)
        {
            _status = _userTypeBll.InsertUserType(userType.UsersType);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteUserType(int id)
        {
            _status = _userTypeBll.DeleteUserType(id);
            return _status;
        }
    }
}
