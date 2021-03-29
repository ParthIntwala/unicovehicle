using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IRegistrationBLL
    {
        public RegisterUser Login(RegisterUser login);
        public string Registration(RegisterUser register);
        public bool UpdatePassword(string password, int userId);
    }
}