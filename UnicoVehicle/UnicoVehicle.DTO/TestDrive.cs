using System;
namespace UnicoVehicle.DTO
{
    public class TestDrive
    {
        public int TestDriveId { get; set; }
        public User User { get; set; }
        public Showroom SHowroom { get; set; }
        public Vehicle Vehicle { get; set; }
        public Status TestDriveStatus { get; set; }
        public DateTime TestDriveDate { get; set; }
    }
}
