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
    public class OrderController : Controller
    {
        private readonly IOrderBLL _orderBLL;
        bool _status;

        public OrderController(IOrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet("{Id}")]
        public Order GetOrderbyId(int id)
        {
            Order order = _orderBLL.GetbyId(id);
            return order;
        }

        [HttpPost]
        public int InsertOrder([FromBody] Order order)
        {
            int orderId = _orderBLL.InsertOrder(order);
            return orderId;
        }

        [HttpPut("{Id}")]
        public bool UpdateOrder([FromBody] Order order, int id)
        {
            _status = _orderBLL.UpdateOrder(order, id);
            return _status;
        }

        [HttpPut]
        public bool UpdateOrderStatus([FromBody] Status orderStatus, int id)
        {
            _status = _orderBLL.UpdateOrderStatus(orderStatus, id);
            return _status;
        }
    }
}
