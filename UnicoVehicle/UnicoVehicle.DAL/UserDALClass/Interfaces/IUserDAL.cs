using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IUserDAL
    {
        public bool DeleteUser(int id);
        public List<User> GetUser();
        public User GetUserbyId(int id);
        public bool InsertUser(User user);
        public bool UpdateUser(User user, int id);
    }
}