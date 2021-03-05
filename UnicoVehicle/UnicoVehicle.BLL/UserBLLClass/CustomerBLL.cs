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
        private readonly IDistrictBLL _districtBLL;
        bool _status;

        public CustomerBLL(ICustomerDAL customerDAL, IDistrictBLL districtBLL, IUserBLL userBLL)
        {
            _customerDAL = customerDAL;
            _districtBLL = districtBLL;
            _userBLL = userBLL;
        }

        public List<Customer> Get()
        {
            List<Customer> _customer = _customerDAL.GetCustomer();

            foreach (Customer customer in _customer)
            {
                customer.User = _userBLL.GetUserbyId(customer.User.UserId);
                customer.District = _districtBLL.GetDistrictbyId(customer.District.DistrictId);
            }

            return _customer;
        }

        public Customer GetCustomerbyId(int id)
        {
            Customer _customer = _customerDAL.GetCustomerbyId(id);

            if (_customer.CustomerId != 0)
            {
                _customer.User = _userBLL.GetUserbyId(_customer.User.UserId);
                _customer.District = _districtBLL.GetDistrictbyId(_customer.District.DistrictId);
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
