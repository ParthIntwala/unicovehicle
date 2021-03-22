using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IOrderBLL
    {
        public Order GetbyId(int id);
        public List<Order> GetOrderbyCustomer(int id);
        public List<Order> GetOrderbyShowroom(int id);
        public List<Order> GetOrderbyShowroomandVehicle(int showroomId, int vehicleId);
        public List<Order> GetOrderbyShowroomCustomer(int customerId, int showroomId);
        public bool InsertOrder(Order order);
        public bool UpdateOrder(Order order, int orderId);
    }
}