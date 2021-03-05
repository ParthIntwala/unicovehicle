using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IUserBLL
    {
        public bool DeleteUser(int id);
        public List<User> Get();
        public User GetUserbyId(int id);
        public bool InsertUser(User user);
        public bool UpdateUser(User user, int userId);
    }
}