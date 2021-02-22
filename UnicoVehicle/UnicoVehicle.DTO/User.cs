using System;
namespace UnicoVehicle.DTO
{
    public class User
    {
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
