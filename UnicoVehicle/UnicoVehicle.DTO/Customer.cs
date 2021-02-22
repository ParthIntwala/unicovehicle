using System;
namespace UnicoVehicle.DTO
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public User User { get; set; }
        public District District { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string photograph { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string StandardIDNumber { get; set; }
        public string IncomeTaxIDNumber { get; set; }
        public string LastITReturn { get; set; }
        public string BankPassbookPhoto { get; set; }
    }
}