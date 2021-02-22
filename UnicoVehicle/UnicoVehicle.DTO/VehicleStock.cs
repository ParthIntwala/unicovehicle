using System;
namespace UnicoVehicle.DTO
{
    public class VehicleStock
    {
        public int VehicleStockId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Showroom Showroom { get; set; }
        public int Stock { get; set; }
    }
}
