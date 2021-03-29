using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IRegistrationBLL
    {
        public dynamic Login(LoginUser login);
        public string Registration(RegisterUser register);
        public bool UpdatePassword(string password, int userId);
    }
}