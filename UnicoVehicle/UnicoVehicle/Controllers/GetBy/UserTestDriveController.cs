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
    public class UserTestDriveController : Controller
    {
        private readonly ITestDriveBLL _testDriveBll;

        public UserTestDriveController(ITestDriveBLL testDriveBll)
        {
            _testDriveBll = testDriveBll;
        }

        [HttpGet("{id}")]
        public List<TestDrive> GetTestDrivebyUser(int id)
        {
            List<TestDrive> _testDrive = _testDriveBll.GetTestDrivebyUser(id);
            return _testDrive;
        }

        [HttpGet]
        public List<TestDrive> GetTestDrivebyShowroom(int showroomId)
        {
            List<TestDrive> testDrive = _testDriveBll.GetTestDrivebyShowroom(showroomId);
            return testDrive;
        }
    }
}
