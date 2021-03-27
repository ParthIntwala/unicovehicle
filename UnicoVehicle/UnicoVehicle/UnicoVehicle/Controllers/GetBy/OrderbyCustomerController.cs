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
    public class OrderbyCustomerController : Controller
    {
        private readonly IOrderBLL _orderBLL;

        public OrderbyCustomerController(IOrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet("{id}")]
        public List<Order> GetOrderbyCustomer(int id)
        {
            List<Order> _order = _orderBLL.GetOrderbyCustomer(id);
            return _order;
        }
    }
}
