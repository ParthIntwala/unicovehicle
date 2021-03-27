using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ITestDriveDAL
    {
        public List<TestDrive> GetTestDrive(int showroomId, int vehicleId);
        public TestDrive GetTestDrivebyId(int id);
        public List<TestDrive> GetTestDrivebyShowroom(int id);
        public List<TestDrive> GetTestDrivebyUser(int id);
        public bool InsertTestDrive(TestDrive testDrive);
        public bool UpdateTestDrive(TestDrive testDrive, int id);
    }
}