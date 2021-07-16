using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class CustomerBLL : ICustomerBLL
    {
        private readonly ICustomerDAL _customerDAL;
        private readonly IUserBLL _userBLL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public CustomerBLL(ICustomerDAL customerDAL, IMiscellaneousCallsDAL miscellaneousCallsDAL, IUserBLL userBLL)
        {
            _customerDAL = customerDAL;
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
            _userBLL = userBLL;
        }

        public List<DTO.Miscellaneous.Customer> Get()
        {
            List<DTO.Miscellaneous.Customer> _customer = _customerDAL.GetCustomer();

            foreach (DTO.Miscellaneous.Customer customer in _customer)
            {
                customer.User = _miscellaneousCallsDAL.GetUserbyId(customer.User.UserId);
            }

            return _customer;
        }

        public Customer GetCustomerbyId(int id)
        {
            Customer _customer = _customerDAL.GetCustomerbyId(id);

            if (_customer.CustomerId != 0)
            {
                _customer.User = _miscellaneousCallsDAL.GetUserbyId(_customer.User.UserId);
                _customer.District = _miscellaneousCallsDAL.GetDistrictbyId(_customer.District.DistrictId);
            }

            return _customer;
        }

        public bool InsertCustomer(Customer customer)
        {
            _status = _customerDAL.InsertCustomer(customer);
            return _status;
        }

        public bool DeleteCustomer(int id)
        {
            _status = _customerDAL.DeleteCustomer(id);
            return _status;
        }

        public bool UpdateCustomer(Customer customer, int customerId)
        {
            _status = _customerDAL.UpdateCustomer(customer, customerId);
            return _status;
        }
    }
}
