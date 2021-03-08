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
    public class CustomerController : Controller
    {
        private readonly ICustomerBLL _customerBll;
        bool _status;

        public CustomerController(ICustomerBLL customerBLL)
        {
            _customerBll = customerBLL;
        }

        [HttpGet]
        public List<DTO.Miscellaneous.Customer> GetUser()
        {
            List<DTO.Miscellaneous.Customer> _customers = _customerBll.Get();
            return _customers;
        }

        [HttpGet("{Id}")]
        public Customer GetUserbyId(int id)
        {
            Customer _customer = _customerBll.GetCustomerbyId(id);
            return _customer;
        }

        [HttpPost]
        public bool InsertUser([FromBody] Customer customer)
        {
            _status = _customerBll.InsertCustomer(customer);
            return _status;
        }

        [HttpDelete("{Id}")]
        public bool DeleteUser(int id)
        {
            _status = _customerBll.DeleteCustomer(id);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdateUser([FromBody] Customer user, int id)
        {
            _status = _customerBll.UpdateCustomer(user, id);
            return _status;
        }
    }
}
