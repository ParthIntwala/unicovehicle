using System;
namespace UnicoVehicle.DTO
{
    public class CompanyCountry
    {
        public int CompanyCountryId { get; set; }
        public Miscellaneous.Company Company { get; set; }
        public Miscellaneous.District District { get; set; }
        public Country Country { get; set; }
        public string CountryHead { get; set; }
        public bool isOperational { get; set; }
    }
}
