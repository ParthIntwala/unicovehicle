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
    public class VehicleStockController : Controller
    {
        private readonly IVehicleStockBLL _vehicleStockBll;
        bool _status;

        public VehicleStockController(IVehicleStockBLL vehicleStockBll)
        {
            _vehicleStockBll = vehicleStockBll;
        }

        [HttpGet]
        public List<VehicleStock> GetVehicleStockbyVehicle(int id)
        {
            List<VehicleStock> _stock = _vehicleStockBll.GetbyVehicle(id);
            return _stock;
        }

        [HttpGet("{id}")]
        public List<VehicleStock> GetVehicleStockbyShowroom(int id)
        {
            List<VehicleStock> _stock = _vehicleStockBll.GetbyShowroom(id);
            return _stock;
        }

        [HttpPost]
        public bool InsertVehicleStock([FromBody] VehicleStock vehicleStock)
        {
            _status = _vehicleStockBll.InsertVehicleStock(vehicleStock);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool DeleteVehicleStock([FromBody] VehicleStock vehicleStock, int id)
        {
            _status = _vehicleStockBll.UpdateVehicleStock(vehicleStock, id);
            return _status;
        }
    }
}
