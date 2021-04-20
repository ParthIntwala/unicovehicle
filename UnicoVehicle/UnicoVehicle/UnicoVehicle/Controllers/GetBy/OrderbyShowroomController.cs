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
    public class OrderbyShowroomController : Controller
    {
        private readonly IOrderBLL _orderBLL;

        public OrderbyShowroomController(IOrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet("{id}")]
        public List<Order> GetOrderbyShowroom(int id)
        {
            List<Order> _order = _orderBLL.GetOrderbyShowroom(id);
            return _order;
        }
    }
}
