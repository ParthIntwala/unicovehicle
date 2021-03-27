using System;
namespace UnicoVehicle.DTO.Miscellaneous
{
    public class Order
    {
        public int OrderId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
    }
}
