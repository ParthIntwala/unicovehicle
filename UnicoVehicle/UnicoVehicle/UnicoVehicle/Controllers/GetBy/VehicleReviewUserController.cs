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
    public class VehicleReviewUserController : Controller
    {
        private readonly IVehicleReviewBLL _vehicleReviewBLL;

        public VehicleReviewUserController(IVehicleReviewBLL vehicleReviewBLL)
        {
            _vehicleReviewBLL = vehicleReviewBLL;
        }

        [HttpGet("{Id}")]
        public List<VehicleReview> GetVehicleReviewbyUser(int id)
        {
            List<VehicleReview> _vehicleReview = _vehicleReviewBLL.GetbyUser(id);
            return _vehicleReview;
        }
    }
}
