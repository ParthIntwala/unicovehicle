using System;
namespace UnicoVehicle.DTO
{
    public class VehiclePrice
    {
        public int VehiclePriceId { get; set; }
        public Miscellaneous.Vehicle Vehicle { get; set; }
        public Miscellaneous.Showroom Showroom { get; set; }
        public double Price { get; set; }
    }
}
