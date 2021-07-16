using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class OrderBLL : IOrderBLL
    {
        private readonly IOrderDAL _orderDAL;
        private readonly IVehicleBLL _vehicleBLL;
        private readonly IShowroomBLL _showroomBLL;
        private readonly ICustomerBLL _customerBLL;
        private readonly IStatusBLL _statusBLL;
        bool _status;

        public OrderBLL(IOrderDAL orderDAL, IVehicleBLL vehicleBLL, IShowroomBLL showroomBLL, ICustomerBLL customerBLL, IStatusBLL statusBLL)
        {
            _orderDAL = orderDAL;
            _vehicleBLL = vehicleBLL;
            _showroomBLL = showroomBLL;
            _customerBLL = customerBLL;
            _statusBLL = statusBLL;
        }

        public List<Order> GetOrderbyShowroom(int id)
        {
            List<Order> _order = _orderDAL.GetOrderbyShowroom(id);

            foreach (Order order in _order)
            {
                order.Showroom = _showroomBLL.GetShowroombyId(order.Showroom.ShowroomId);
                order.Vehicle = _vehicleBLL.GetVehiclebyId(order.Vehicle.VehicleId);
                order.Customer = _customerBLL.GetCustomerbyId(order.Customer.CustomerId);
                order.OrderStatus = _statusBLL.GetStatusbyId(order.OrderStatus.StatusId);
            }

            return _order;
        }

        public List<Order> GetOrderbyShowroomCustomer(int customerId, int showroomId)
        {
            List<Order> _order = _orderDAL.GetOrderbyCustomerShowroom(customerId, showroomId);

            foreach (Order order in _order)
            {
                order.Showroom = _showroomBLL.GetShowroombyId(order.Showroom.ShowroomId);
                order.Vehicle = _vehicleBLL.GetVehiclebyId(order.Vehicle.VehicleId);
                order.Customer = _customerBLL.GetCustomerbyId(order.Customer.CustomerId);
                order.OrderStatus = _statusBLL.GetStatusbyId(order.OrderStatus.StatusId);
            }

            return _order;
        }

        public List<Order> GetOrderbyCustomer(int id)
        {
            List<Order> _order = _orderDAL.GetOrderbyCustomer(id);

            foreach (Order order in _order)
            {
                order.Showroom = _showroomBLL.GetShowroombyId(order.Showroom.ShowroomId);
                order.Vehicle = _vehicleBLL.GetVehiclebyId(order.Vehicle.VehicleId);
                order.Customer = _customerBLL.GetCustomerbyId(order.Customer.CustomerId);
                order.OrderStatus = _statusBLL.GetStatusbyId(order.OrderStatus.StatusId);
            }

            return _order;
        }

        public List<Order> GetOrderbyShowroomandVehicle(int showroomId, int vehicleId)
        {
            List<Order> _order = _orderDAL.GetOrder(showroomId, vehicleId);

            foreach (Order order in _order)
            {
                order.Showroom = _showroomBLL.GetShowroombyId(order.Showroom.ShowroomId);
                order.Vehicle = _vehicleBLL.GetVehiclebyId(order.Vehicle.VehicleId);
                order.Customer = _customerBLL.GetCustomerbyId(order.Customer.CustomerId);
                order.OrderStatus = _statusBLL.GetStatusbyId(order.OrderStatus.StatusId);
            }

            return _order;
        }

        public Order GetbyId(int id)
        {
            Order _order = _orderDAL.GetOrderbyId(id);

            if (_order.OrderId != 0)
            {
                _order.Showroom = _showroomBLL.GetShowroombyId(_order.Showroom.ShowroomId);
                _order.Vehicle = _vehicleBLL.GetVehiclebyId(_order.Vehicle.VehicleId);
                _order.Customer = _customerBLL.GetCustomerbyId(_order.Customer.CustomerId);
                _order.OrderStatus = _statusBLL.GetStatusbyId(_order.OrderStatus.StatusId);
            }

            return _order;
        }

        public int InsertOrder(Order order)
        {
            int orderId = -1;
            _status = _orderDAL.InsertOrder(order);

            if(_status)
            {
                orderId = _orderDAL.GetOrderId(order);
            }

            return orderId;
        }

        public bool UpdateOrder(Order order, int orderId)
        {
            _status = _orderDAL.UpdateOrder(order, orderId);
            return _status;
        }

        public bool UpdateOrderStatus(Status status, int orderId)
        {
            _status = _orderDAL.UpdateOrderStatus(status, orderId);
            return _status;
        }
    }
}
