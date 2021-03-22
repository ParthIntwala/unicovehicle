using System.Collections.Generic;
namespace UnicoVehicle.DTO
{
    public class BoughtAccessories
    {
        public List<int> BoughtAccessoriesId { get; set; }
        public Miscellaneous.Order Order { get; set; }
        public List<Accessories> Accessories { get; set; }
    }
}
