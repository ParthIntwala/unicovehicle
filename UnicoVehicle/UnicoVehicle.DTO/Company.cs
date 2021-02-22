using System;
namespace UnicoVehicle.DTO
{
    public class Company
    {
        public int CompanyId { get; set; }
        public Country Country { get; set; }
        public string CompanyName { get; set; }
        public string CompanyHead { get; set; }
        public bool isOperational { get; set; }
    }
}
