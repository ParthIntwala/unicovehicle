using System;
namespace UnicoVehicle.DTO
{
    public class InsuranceType
    {
        public int InsuranceTypeId { get; set; }
        public string InsuranceTypeName { get; set; }
        public Miscellaneous.InsuranceCompany InsuranceCompany { get; set; }
    }
}
