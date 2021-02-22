using System;
namespace UnicoVehicle.DTO
{
    public class PostBuyingDetail
    {
        public int PostBuyingDetailId { get; set; }
        public Order Order { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public float LoanEMI { get; set; }
        public float InsurancePremium { get; set; }
        public DateTime TaxValidity { get; set; }
        public int FreeService { get; set; }
    }
}
