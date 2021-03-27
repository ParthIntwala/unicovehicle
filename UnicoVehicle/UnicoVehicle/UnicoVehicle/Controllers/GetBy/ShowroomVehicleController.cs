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
    public class ShowroomVehicleController : Controller
    {
        private readonly ITestDriveBLL _testDriveBll;

        public ShowroomVehicleController(ITestDriveBLL testDriveBLL)
        {
            _testDriveBll = testDriveBLL;
        }

        [HttpGet("{id}")]
        public List<TestDrive> GetTestDrivebyShowroomandVehicle(int id, int vehicleId)
        {
            List<TestDrive> testDrive = _testDriveBll.GetTestDrivebyShowroomandVehicle(id, vehicleId);
            return testDrive;
        }
    }
}
