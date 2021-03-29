using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IRegistrationBLL
    {
        public LoginUser Login(LoginUser login);
        public string Registration(RegisterUser register);
        public bool UpdatePassword(string password, int userId);
    }
}