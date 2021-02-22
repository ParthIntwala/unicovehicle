using System;
namespace UnicoVehicle.DTO
{
    public class VehiclePrice
    {
        public int VehiclePriceId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Showroom Showroom { get; set; }
        public float Price { get; set; }
    }
}
