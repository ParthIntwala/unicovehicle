using System;
namespace UnicoVehicle.DTO.Miscellaneous
{
    public class Showroom
    {
        public int ShowroomId { get; set; }
        public Company Company { get; set; }
        public District District { get; set; }
        public string ShowroomName { get; set; }
    }
}
