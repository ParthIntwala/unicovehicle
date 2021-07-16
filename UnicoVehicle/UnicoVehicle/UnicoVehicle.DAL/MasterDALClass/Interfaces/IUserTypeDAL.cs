using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IUserTypeDAL
    {
        public bool DeleteUserType(int id);
        public List<UserType> GetUserType();
        public UserType GetUserTypebyId(int id);
        public bool InsertUserType(string userType);
    }
}