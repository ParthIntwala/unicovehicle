﻿using System;
namespace UnicoVehicle.DTO.Miscellaneous
{
    public class User
    {
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }   
}
