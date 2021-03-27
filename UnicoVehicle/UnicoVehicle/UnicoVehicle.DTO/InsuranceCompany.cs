using System;
namespace UnicoVehicle.DTO
{
    public class InsuranceCompany
    {
        public int InsuranceCompanyId { get; set; }
        public Miscellaneous.District District { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string Address { get; set; }
        public string CountryHead { get; set; }
    }
}
