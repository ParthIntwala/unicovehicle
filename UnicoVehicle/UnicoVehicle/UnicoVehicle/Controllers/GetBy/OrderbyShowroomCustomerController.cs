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
    public class OrderbyShowroomCustomerController : Controller
    {
        private readonly IOrderBLL _orderBLL;

        public OrderbyShowroomCustomerController(IOrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet("{id}")]
        public List<Order> GetOrderbyShowroomandCustomer(int id, int customerId)
        {
            List<Order> _order = _orderBLL.GetOrderbyShowroomCustomer(customerId, id);
            return _order;
        }
    }
}
