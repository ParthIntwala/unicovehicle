using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ITestDriveBLL
    {
        public TestDrive GetbyId(int id);
        public List<TestDrive> GetTestDrivebyShowroom(int id);
        public List<TestDrive> GetTestDrivebyShowroomandVehicle(int showroomId, int vehicleId);
        public List<TestDrive> GetTestDrivebyUser(int id);
        public bool InsertTestDrive(TestDrive testDrive);
        public bool UpdateTestDrive(TestDrive testDrive, int testDriveId);
    }
}