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
    public class OrderbyShowroomVehicleController : Controller
    {
        private readonly IOrderBLL _orderBLL;

        public OrderbyShowroomVehicleController(IOrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet("{id}")]
        public List<Order> GetOrderbyShowroomVehicle(int id, int vehicleId)
        {
            List<Order> _order = _orderBLL.GetOrderbyShowroomandVehicle(id, vehicleId);
            return _order;
        }
    }
}
