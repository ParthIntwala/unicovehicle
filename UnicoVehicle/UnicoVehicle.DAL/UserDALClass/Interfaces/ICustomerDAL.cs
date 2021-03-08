using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ICustomerDAL
    {
        public bool DeleteCustomer(int id);
        public List<DTO.Miscellaneous.Customer> GetCustomer();
        public Customer GetCustomerbyId(int id);
        public bool InsertCustomer(Customer user);
        public bool UpdateCustomer(Customer user, int id);
    }
}