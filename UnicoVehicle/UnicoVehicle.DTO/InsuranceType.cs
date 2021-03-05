using System;
namespace UnicoVehicle.DTO
{
    public class InsuranceType
    {
        public int InsuranceTypeId { get; set; }
        public string InsuranceTypeName { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
    }
}
