using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDriveController : Controller
    {
        private readonly ITestDriveBLL _testDriveBll;
        bool _status;

        public TestDriveController(ITestDriveBLL testDriveBLL)
        {
            _testDriveBll = testDriveBLL;
        }

        [HttpGet("{Id}")]
        public TestDrive GetTestDrivebyId(int id)
        {
            TestDrive testDrive = _testDriveBll.GetbyId(id);
            return testDrive;
        }

        [HttpPost]
        public bool InsertVehicle([FromBody] TestDrive testDrive)
        {
            _status = _testDriveBll.InsertTestDrive(testDrive);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateVehicle([FromBody] TestDrive testDrive, int id)
        {
            _status = _testDriveBll.UpdateTestDrive(testDrive, id);
            return _status;
        }
    }
}
