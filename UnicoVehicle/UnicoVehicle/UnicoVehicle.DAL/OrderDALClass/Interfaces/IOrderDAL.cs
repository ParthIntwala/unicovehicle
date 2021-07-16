using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IOrderDAL
    {
        public List<Order> GetOrder(int showroomId, int vehicleId);
        public List<Order> GetOrderbyCustomer(int id);
        public List<Order> GetOrderbyCustomerShowroom(int customerId, int showroomId);
        public Order GetOrderbyId(int id);
        public List<Order> GetOrderbyShowroom(int id);
        public bool InsertOrder(Order order);
        public bool UpdateOrder(Order order, int id);
        public bool UpdateOrderStatus(Status status, int id);
        public int GetOrderId(Order order);
    }
}