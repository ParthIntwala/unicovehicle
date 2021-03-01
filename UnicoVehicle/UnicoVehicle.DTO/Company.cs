using System;
namespace UnicoVehicle.DTO
{
    public class Company
    {
        public int CompanyId { get; set; }
        public District District { get; set; }
        public string CompanyName { get; set; }
        public string CountryHead { get; set; }
        public bool isOperational { get; set; }
    }
}
