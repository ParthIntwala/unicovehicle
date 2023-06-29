using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IUserDAL
    {
        public bool DeleteUser(int id);
        public User GetUserbyId(int id);
        public bool UpdateUser(User user, int id);
    }
}