using System;
namespace UnicoVehicle.DTO
{
    public class Showroom
    {
        public int ShowroomId { get; set; }
        public Miscellaneous.Company Company { get; set; }
        public Miscellaneous.District District { get; set; }
        public string ShowroomName { get; set; }
        public string Address { get; set; }
        public int PINCODE { get; set; }
        public string Manager { get; set; }
        public bool hasSales { get; set; }
        public bool hasService { get; set; }
        public bool isOperational { get; set; }
    }
}
