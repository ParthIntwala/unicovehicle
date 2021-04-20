using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IUserTypeBLL
    {
        public bool DeleteUserType(int id);
        public List<UserType> Get();
        public UserType GetUserTypebyId(int id);
        public bool InsertUserType(string userType);
    }
}