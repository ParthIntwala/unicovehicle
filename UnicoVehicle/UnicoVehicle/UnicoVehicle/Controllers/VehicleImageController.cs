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
    public class VehicleImageController : Controller
    {
        private readonly IVehicleImageBLL _vehicleImageBLL;
        bool _status;

        public VehicleImageController(IVehicleImageBLL vehicleImageBLL)
        {
            _vehicleImageBLL = vehicleImageBLL;
        }

        [HttpGet("{Id}")]
        public VehicleImages GetVehicleImagesbyId(int id)
        {
            VehicleImages images = _vehicleImageBLL.GetVehicleImagesbyId(id);
            return images;
        }

        [HttpPost("{Id}")]
        public bool InsertVehicleImages([FromBody] VehicleImages images, int id)
        {
            _status = _vehicleImageBLL.InsertVehicleImages(images, id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateVehicleImages([FromBody] VehicleImages images, int id)
        {
            _status = _vehicleImageBLL.UpdateVehicleImages(images, id);
            return _status;
        }
    }
}
