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
    public class VehicleReviewVehicleController : Controller
    {
        private readonly IVehicleReviewBLL _vehicleReviewBLL;

        public VehicleReviewVehicleController(IVehicleReviewBLL vehicleReviewBLL)
        {
            _vehicleReviewBLL = vehicleReviewBLL;
        }

        [HttpGet("{Id}")]
        public List<VehicleReview> GetVehicleReviewbyVehicle(int id)
        {
            List<VehicleReview> _vehicleReview = _vehicleReviewBLL.GetbyVehicle(id);
            return _vehicleReview;
        }
    }
}
