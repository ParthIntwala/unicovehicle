using System;
namespace UnicoVehicle.DTO
{
    public class BoughtAccessories
    {
        public int BoughtAccessoriesId { get; set; }
        public Order Order { get; set; }
        public Accessories Accessories { get; set; }
    }
}
