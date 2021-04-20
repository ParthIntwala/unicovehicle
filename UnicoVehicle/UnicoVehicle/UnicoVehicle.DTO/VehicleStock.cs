using System;
namespace UnicoVehicle.DTO
{
    public class VehicleStock
    {
        public int VehicleStockId { get; set; }
        public Miscellaneous.Vehicle Vehicle { get; set; }
        public Miscellaneous.Showroom Showroom { get; set; }
        public int Stock { get; set; }
    }
}
