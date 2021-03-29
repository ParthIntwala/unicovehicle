using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IRegistrationDAL
    {
        public int GetUser(string Email);
        public LoginUser Login(LoginUser login);
        public bool RegisterUser(RegisterUser register);
        public bool UpdateUserPassword(string password, int id);
    }
}