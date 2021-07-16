using System;
namespace UnicoVehicle.DTO
{
    public class Company
    {
        public int CompanyId { get; set; }
        public Miscellaneous.District District { get; set; }
        public string CompanyName { get; set; }
        public string CompanyHead { get; set; }
    }
}
