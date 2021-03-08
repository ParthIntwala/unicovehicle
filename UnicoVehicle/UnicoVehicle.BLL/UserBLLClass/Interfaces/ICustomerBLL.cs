using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICustomerBLL
    {
        public bool DeleteCustomer(int id);
        public List<DTO.Miscellaneous.Customer> Get();
        public Customer GetCustomerbyId(int id);
        public bool InsertCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer, int customerId);
    }
}