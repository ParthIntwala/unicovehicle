using System;
namespace UnicoVehicle.DTO
{
    public class Accessories
    {
        public int AccessoriesId { get; set; }
        public AccessoriesType AccessoriesType { get; set; }
        public string AccessoriesName { get; set; }
        public double Price { get; set; }
        public AccessoryBrand AccessoryBrand { get; set; }
    }
}
