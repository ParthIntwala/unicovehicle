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
    public class ShowroomTestDriveController : Controller
    {
        private readonly ITestDriveBLL _testDriveBll;

        public ShowroomTestDriveController(ITestDriveBLL testDriveBll)
        {
            _testDriveBll = testDriveBll;
        }

        [HttpGet("{id}")]
        public List<TestDrive> GetTestDrivebyShowroom(int id)
        {
            List<TestDrive> testDrive = _testDriveBll.GetTestDrivebyShowroom(id);
            return testDrive;
        }
    }
}
