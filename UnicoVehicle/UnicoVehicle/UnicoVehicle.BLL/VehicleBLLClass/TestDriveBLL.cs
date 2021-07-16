using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class TestDriveBLL : ITestDriveBLL
    {
        private readonly ITestDriveDAL _testDriveDAL;
        private readonly IMiscellaneousCallsBLL _miscellaneousCallsBLL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        private readonly IStatusBLL _statusBLL;
        bool _status;

        public TestDriveBLL(ITestDriveDAL testDriveDAL, IStatusBLL statusBLL, IMiscellaneousCallsBLL miscellaneousCallsBLL, IMiscellaneousCallsDAL miscellaneousCallsDAL)
        {
            _testDriveDAL = testDriveDAL;
            _miscellaneousCallsBLL = miscellaneousCallsBLL;
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
            _statusBLL = statusBLL;
        }

        public List<TestDrive> GetTestDrivebyShowroom(int id)
        {
            List<TestDrive> _testDrive = _testDriveDAL.GetTestDrivebyShowroom(id);

            foreach (TestDrive testDrive in _testDrive)
            {
                testDrive.Showroom = _miscellaneousCallsBLL.GetShowroombyId(testDrive.Showroom.ShowroomId);
                testDrive.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(testDrive.Vehicle.VehicleId);
                testDrive.User = _miscellaneousCallsDAL.GetUserbyId(testDrive.User.UserId);
                testDrive.TestDriveStatus = _statusBLL.GetStatusbyId(testDrive.TestDriveStatus.StatusId);
            }

            return _testDrive;
        }

        public List<TestDrive> GetTestDrivebyUser(int id)
        {
            List<TestDrive> _testDrive = _testDriveDAL.GetTestDrivebyUser(id);

            foreach (TestDrive testDrive in _testDrive)
            {
                testDrive.TestDriveStatus = _statusBLL.GetStatusbyId(testDrive.TestDriveStatus.StatusId);
                testDrive.Showroom = _miscellaneousCallsBLL.GetShowroombyId(testDrive.Showroom.ShowroomId);
                testDrive.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(testDrive.Vehicle.VehicleId);
                testDrive.User = _miscellaneousCallsDAL.GetUserbyId(testDrive.User.UserId);
            }

            return _testDrive;
        }

        public List<TestDrive> GetTestDrivebyShowroomandVehicle(int showroomId, int vehicleId)
        {
            List<TestDrive> _testDrive = _testDriveDAL.GetTestDrive(showroomId, vehicleId);

            foreach (TestDrive testDrive in _testDrive)
            {
                testDrive.Showroom = _miscellaneousCallsBLL.GetShowroombyId(testDrive.Showroom.ShowroomId);
                testDrive.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(testDrive.Vehicle.VehicleId);
                testDrive.User = _miscellaneousCallsDAL.GetUserbyId(testDrive.User.UserId);
                testDrive.TestDriveStatus = _statusBLL.GetStatusbyId(testDrive.TestDriveStatus.StatusId);
            }

            return _testDrive;
        }

        public TestDrive GetbyId(int id)
        {
            TestDrive _testDrive = _testDriveDAL.GetTestDrivebyId(id);

            if (_testDrive.TestDriveId != 0)
            {
                _testDrive.Showroom = _miscellaneousCallsBLL.GetShowroombyId(_testDrive.Showroom.ShowroomId);
                _testDrive.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(_testDrive.Vehicle.VehicleId);
                _testDrive.User = _miscellaneousCallsDAL.GetUserbyId(_testDrive.User.UserId);
                _testDrive.TestDriveStatus = _statusBLL.GetStatusbyId(_testDrive.TestDriveStatus.StatusId);
            }

            return _testDrive;
        }

        public bool InsertTestDrive(TestDrive testDrive)
        {
            _status = _testDriveDAL.InsertTestDrive(testDrive);
            return _status;
        }

        public bool UpdateTestDrive(TestDrive testDrive, int testDriveId)
        {
            _status = _testDriveDAL.UpdateTestDrive(testDrive, testDriveId);
            return _status;
        }
    }
}
