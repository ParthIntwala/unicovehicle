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
    public class VehicleReviewController : Controller
    {
        private readonly IVehicleReviewBLL _vehicleReviewBLL;
        bool _status;

        public VehicleReviewController(IVehicleReviewBLL vehicleReviewBLL)
        {
            _vehicleReviewBLL = vehicleReviewBLL;
        }

        [HttpGet("{Id}")]
        public VehicleReview GetVehicleReviewbyId(int id)
        {
            VehicleReview _vehicleReview = _vehicleReviewBLL.GetVehicleReviewbyId(id);
            return _vehicleReview;
        }

        [HttpPost]
        public bool InsertVehicleReview([FromBody] VehicleReview vehicleReview)
        {
            _status = _vehicleReviewBLL.InsertVehicleReview(vehicleReview);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteVehicleReview(int id)
        {
            _status = _vehicleReviewBLL.DeleteVehicleReview(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateVehicleReview([FromBody] VehicleReview vehicleReview, int id)
        {
            _status = _vehicleReviewBLL.UpdateVehicleReview(vehicleReview, id);
            return _status;
        }
    }
}
