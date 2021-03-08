using System.Collections.Generic;
using UnicoVehicle.DTO.Miscellaneous;

namespace UnicoVehicle.BLL
{
    public interface IUserBLL
    {
        public bool DeleteUser(int id);
        public User GetUserbyId(int id);
        public bool UpdateUser(User user, int userId);
    }
}