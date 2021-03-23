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
    public class StockbyVehicleController : Controller
    {
        private readonly IVehicleStockBLL _vehicleStockBll;

        public StockbyVehicleController(IVehicleStockBLL vehicleStockBll)
        {
            _vehicleStockBll = vehicleStockBll;
        }

        [HttpGet("{id}")]
        public List<VehicleStock> GetVehicleStockbyVehicle(int id)
        {
            List<VehicleStock> _stock = _vehicleStockBll.GetbyVehicle(id);
            return _stock;
        }
    }
}