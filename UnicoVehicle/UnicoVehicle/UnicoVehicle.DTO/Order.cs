using System;
namespace UnicoVehicle.DTO
{
    public class Order
    {
        public int OrderId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Showroom Showroom { get; set; }
        public Status OrderStatus { get; set; }
        public Customer Customer { get; set; }
        public double FinalPrice { get; set; }
        public bool hasLoan { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
