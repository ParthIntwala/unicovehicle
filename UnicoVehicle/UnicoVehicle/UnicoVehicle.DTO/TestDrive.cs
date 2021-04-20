using System;
namespace UnicoVehicle.DTO
{
    public class TestDrive
    {
        public int TestDriveId { get; set; }
        public Miscellaneous.User User { get; set; }
        public Miscellaneous.Showroom Showroom { get; set; }
        public Miscellaneous.Vehicle Vehicle { get; set; }
        public Status TestDriveStatus { get; set; }
        public DateTime TestDriveDate { get; set; }
    }
}
