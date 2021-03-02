using System;
namespace UnicoVehicle.DTO
{
    public class CompanyCountry
    {
        public int CompanyCountryId { get; set; }
        public Company Company { get; set; }
        public District District { get; set; }
        public string CountryHead { get; set; }
        public bool isOperational { get; set; }
    }
}
