﻿using System;
namespace UnicoVehicle.DTO
{
    public class RegisterUser
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class LoginUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
    }
}
