using System;
namespace UnicoVehicle.DTO
{
    public class PostBuyingDetail
    {
        public int PostBuyingDetailId { get; set; }
        public int OrderId { get; set; }
        public Miscellaneous.InsuranceCompany InsuranceCompany { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public double LoanEMI { get; set; }
        public double InsurancePremium { get; set; }
        public DateTime TaxValidity { get; set; }
        public DateTime InsuranceValidity { get; set; }
        public int FreeService { get; set; }
        public bool PaymentReceived { get; set; }
    }
}
