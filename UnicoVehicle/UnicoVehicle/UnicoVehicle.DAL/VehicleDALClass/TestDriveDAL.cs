using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class TestDriveDAL : ITestDriveDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _testDriveCommand;
        private SqlDataReader _testDriveReader;
        int _success;

        public TestDriveDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<TestDrive> GetTestDrivebyShowroom(int id)
        {
            _testDriveCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetTestDrivebyShowroom);
            _testDriveCommand.Parameters.AddWithValue("@showroomId", id);
            _testDriveReader = _testDriveCommand.ExecuteReader();

            TestDrive _testDrive;
            List<TestDrive> _testDrives = new List<TestDrive>();

            while (_testDriveReader.Read())
            {
                _testDrive = new TestDrive
                {
                    TestDriveId = int.Parse(_testDriveReader["TestDriveId"].ToString()),
                    TestDriveDate = Convert.ToDateTime(_testDriveReader["TestDriveDateTime"].ToString()),
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = id,
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_testDriveReader["VehicleId"].ToString()),
                    },
                    TestDriveStatus = new Status
                    {
                        StatusId = int.Parse(_testDriveReader["TestDriveStatusId"].ToString()),
                    },
                    User = new DTO.Miscellaneous.User
                    {
                        UserId = int.Parse(_testDriveReader["UserId"].ToString()),
                    }
                };

                _testDrives.Add(_testDrive);
            }

            _testDriveReader.Close();
            _connection.CloseConnection();

            return _testDrives;
        }

        public TestDrive GetTestDrivebyId(int id)
        {
            _testDriveCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetTestDrivebyId);
            _testDriveCommand.Parameters.AddWithValue("@testDriveId", id);
            _testDriveReader = _testDriveCommand.ExecuteReader();

            TestDrive _testDrive = new TestDrive();

            while (_testDriveReader.Read())
            {
                _testDrive = new TestDrive
                {
                    TestDriveId = id,
                    TestDriveDate = Convert.ToDateTime(_testDriveReader["TestDriveDateTime"].ToString()),
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = int.Parse(_testDriveReader["ShowroomId"].ToString()),
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_testDriveReader["VehicleId"].ToString()),
                    },
                    TestDriveStatus = new Status
                    {
                        StatusId = int.Parse(_testDriveReader["TestDriveStatusId"].ToString()),
                    },
                    User = new DTO.Miscellaneous.User
                    {
                        UserId = int.Parse(_testDriveReader["UserId"].ToString()),
                    }
                };
            }

            _testDriveReader.Close();
            _connection.CloseConnection();

            return _testDrive;
        }

        public List<TestDrive> GetTestDrive(int showroomId, int vehicleId)
        {
            _testDriveCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetTestDrivebyShowroomandVehicle);
            _testDriveCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            _testDriveCommand.Parameters.AddWithValue("@showroomId", showroomId);
            _testDriveReader = _testDriveCommand.ExecuteReader();

            TestDrive _testDrive;
            List<TestDrive> _testDrives = new List<TestDrive>();

            while (_testDriveReader.Read())
            {
                _testDrive = new TestDrive
                {
                    TestDriveId = int.Parse(_testDriveReader["TestDriveId"].ToString()),
                    TestDriveDate = Convert.ToDateTime(_testDriveReader["TestDriveDateTime"].ToString()),
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = showroomId,
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = vehicleId,
                    },
                    TestDriveStatus = new Status
                    {
                        StatusId = int.Parse(_testDriveReader["TestDriveStatusId"].ToString()),
                    },
                    User = new DTO.Miscellaneous.User
                    {
                        UserId = int.Parse(_testDriveReader["UserId"].ToString()),
                    }
                };

                _testDrives.Add(_testDrive);
            }

            _testDriveReader.Close();
            _connection.CloseConnection();

            return _testDrives;
        }

        public List<TestDrive> GetTestDrivebyUser(int id)
        {
            _testDriveCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetTestDrivebyUser);
            _testDriveCommand.Parameters.AddWithValue("@userId", id);
            _testDriveReader = _testDriveCommand.ExecuteReader();

            TestDrive _testDrive;
            List<TestDrive> _testDrives = new List<TestDrive>();

            while (_testDriveReader.Read())
            {
                _testDrive = new TestDrive
                {
                    TestDriveId = int.Parse(_testDriveReader["TestDriveId"].ToString()),
                    TestDriveDate = Convert.ToDateTime(_testDriveReader["TestDriveDateTime"].ToString()),
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = int.Parse(_testDriveReader["ShowroomId"].ToString()),
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_testDriveReader["VehicleId"].ToString()),
                    },
                    TestDriveStatus = new Status
                    {
                        StatusId = int.Parse(_testDriveReader["TestDriveStatusId"].ToString()),
                    },
                    User = new DTO.Miscellaneous.User
                    {
                        UserId = id,
                    }
                };

                _testDrives.Add(_testDrive);
            }

            _testDriveReader.Close();
            _connection.CloseConnection();

            return _testDrives;
        }

        public bool InsertTestDrive(TestDrive testDrive)
        {
            _testDriveCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertTestDrive);
            _testDriveCommand.Parameters.AddWithValue("@vehicleId", testDrive.Vehicle.VehicleId);
            _testDriveCommand.Parameters.AddWithValue("@showroomId", testDrive.Showroom.ShowroomId);
            _testDriveCommand.Parameters.AddWithValue("@userId", testDrive.User.UserId);
            _testDriveCommand.Parameters.AddWithValue("@testDriveStatusId", testDrive.TestDriveStatus.StatusId);
            _testDriveCommand.Parameters.AddWithValue("@testDriveDateTime", testDrive.TestDriveDate);
            _testDriveCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _testDriveCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTestDrive(TestDrive testDrive, int id)
        {
            _testDriveCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateTestDrive);
            _testDriveCommand.Parameters.AddWithValue("@testDriveId", id);
            _testDriveCommand.Parameters.AddWithValue("@testDriveStatusId", testDrive.TestDriveStatus.StatusId);
            _testDriveCommand.Parameters.AddWithValue("@testDriveDateTime", testDrive.TestDriveDate);
            _testDriveCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _testDriveCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
