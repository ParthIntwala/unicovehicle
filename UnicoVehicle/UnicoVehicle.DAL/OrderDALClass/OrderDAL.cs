using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class OrderDAL : IOrderDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _orderCommand;
        private SqlDataReader _orderReader;
        int _success;

        public OrderDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<Order> GetOrderbyShowroom(int id)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetOrderbyShowroom);
            _orderCommand.Parameters.AddWithValue("@showroomId", id);
            _orderReader = _orderCommand.ExecuteReader();

            Order _order;
            List<Order> _orders = new List<Order>();

            while (_orderReader.Read())
            {
                _order = new Order
                {
                    OrderId = int.Parse(_orderReader["OrderId"].ToString()),
                    DeliveryDate = Convert.ToDateTime(_orderReader["DeliveryDate"].ToString()),
                    Showroom = new Showroom
                    {
                        ShowroomId = id,
                    },
                    Vehicle = new Vehicle
                    {
                        VehicleId = int.Parse(_orderReader["VehicleId"].ToString()),
                    },
                    OrderStatus = new Status
                    {
                        StatusId = int.Parse(_orderReader["OrderStatusId"].ToString()),
                    },
                    Customer = new Customer
                    {
                        CustomerId = int.Parse(_orderReader["CustomerId"].ToString()),
                    },
                    FinalPrice = double.Parse(_orderReader["TestDriveStatusId"].ToString()),
                    hasLoan = bool.Parse(_orderReader["TestDriveStatusId"].ToString())
                };

                _orders.Add(_order);
            }

            _orderReader.Close();
            _connection.CloseConnection();

            return _orders;
        }

        public Order GetOrderbyId(int id)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetOrderbyId);
            _orderCommand.Parameters.AddWithValue("@orderId", id);
            _orderReader = _orderCommand.ExecuteReader();

            Order _order = new Order();

            while (_orderReader.Read())
            {
                _order = new Order
                {
                    OrderId = id,
                    DeliveryDate = Convert.ToDateTime(_orderReader["DeliveryDate"].ToString()),
                    Showroom = new Showroom
                    {
                        ShowroomId = int.Parse(_orderReader["ShowroomId"].ToString()),
                    },
                    Vehicle = new Vehicle
                    {
                        VehicleId = int.Parse(_orderReader["VehicleId"].ToString()),
                    },
                    OrderStatus = new Status
                    {
                        StatusId = int.Parse(_orderReader["OrderStatusId"].ToString()),
                    },
                    Customer = new Customer
                    {
                        CustomerId = int.Parse(_orderReader["CustomerId"].ToString()),
                    },
                    FinalPrice = double.Parse(_orderReader["TestDriveStatusId"].ToString()),
                    hasLoan = bool.Parse(_orderReader["TestDriveStatusId"].ToString())
                };
            }

            _orderReader.Close();
            _connection.CloseConnection();

            return _order;
        }

        public List<Order> GetOrder(int showroomId, int vehicleId)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetOrderbyShowroomandVehicle);
            _orderCommand.Parameters.AddWithValue("@vehicleId", vehicleId);
            _orderCommand.Parameters.AddWithValue("@showroomId", showroomId);
            _orderReader = _orderCommand.ExecuteReader();

            Order _order;
            List<Order> _orders = new List<Order>();

            while (_orderReader.Read())
            {
                _order = new Order
                {
                    OrderId = int.Parse(_orderReader["OrderId"].ToString()),
                    DeliveryDate = Convert.ToDateTime(_orderReader["DeliveryDate"].ToString()),
                    Showroom = new Showroom
                    {
                        ShowroomId = showroomId,
                    },
                    Vehicle = new Vehicle
                    {
                        VehicleId = vehicleId,
                    },
                    OrderStatus = new Status
                    {
                        StatusId = int.Parse(_orderReader["OrderStatusId"].ToString()),
                    },
                    Customer = new Customer
                    {
                        CustomerId = int.Parse(_orderReader["CustomerId"].ToString()),
                    },
                    FinalPrice = double.Parse(_orderReader["TestDriveStatusId"].ToString()),
                    hasLoan = bool.Parse(_orderReader["TestDriveStatusId"].ToString())
                };

                _orders.Add(_order);
            }

            _orderReader.Close();
            _connection.CloseConnection();

            return _orders;
        }

        public List<Order> GetOrderbyCustomer(int id)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetOrderbyCustomer);
            _orderCommand.Parameters.AddWithValue("@customerId", id);
            _orderReader = _orderCommand.ExecuteReader();

            Order _order;
            List<Order> _orders = new List<Order>();

            while (_orderReader.Read())
            {
                _order = new Order
                {
                    OrderId = int.Parse(_orderReader["OrderId"].ToString()),
                    DeliveryDate = Convert.ToDateTime(_orderReader["DeliveryDate"].ToString()),
                    Showroom = new Showroom
                    {
                        ShowroomId = int.Parse(_orderReader["ShowroomId"].ToString()),
                    },
                    Vehicle = new Vehicle
                    {
                        VehicleId = int.Parse(_orderReader["VehicleId"].ToString()),
                    },
                    OrderStatus = new Status
                    {
                        StatusId = int.Parse(_orderReader["OrderStatusId"].ToString()),
                    },
                    Customer = new Customer
                    {
                        CustomerId = id,
                    },
                    FinalPrice = double.Parse(_orderReader["TestDriveStatusId"].ToString()),
                    hasLoan = bool.Parse(_orderReader["TestDriveStatusId"].ToString())
                };

                _orders.Add(_order);
            }

            _orderReader.Close();
            _connection.CloseConnection();

            return _orders;
        }

        public List<Order> GetOrderbyCustomerShowroom(int customerId, int showroomId)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetOrderbyShowroomCustomer);
            _orderCommand.Parameters.AddWithValue("@customerId", customerId);
            _orderCommand.Parameters.AddWithValue("@showroomId", showroomId);
            _orderReader = _orderCommand.ExecuteReader();

            Order _order;
            List<Order> _orders = new List<Order>();

            while (_orderReader.Read())
            {
                _order = new Order
                {
                    OrderId = int.Parse(_orderReader["OrderId"].ToString()),
                    DeliveryDate = Convert.ToDateTime(_orderReader["DeliveryDate"].ToString()),
                    Showroom = new Showroom
                    {
                        ShowroomId = showroomId,
                    },
                    Vehicle = new Vehicle
                    {
                        VehicleId = int.Parse(_orderReader["VehicleId"].ToString()),
                    },
                    OrderStatus = new Status
                    {
                        StatusId = int.Parse(_orderReader["OrderStatusId"].ToString()),
                    },
                    Customer = new Customer
                    {
                        CustomerId = customerId,
                    },
                    FinalPrice = double.Parse(_orderReader["TestDriveStatusId"].ToString()),
                    hasLoan = bool.Parse(_orderReader["TestDriveStatusId"].ToString())
                };

                _orders.Add(_order);
            }

            _orderReader.Close();
            _connection.CloseConnection();

            return _orders;
        }

        public bool InsertOrder(Order order)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.InsertOrder);
            _orderCommand.Parameters.AddWithValue("@vehicleId", order.Vehicle.VehicleId);
            _orderCommand.Parameters.AddWithValue("@showroomId", order.Showroom.ShowroomId);
            _orderCommand.Parameters.AddWithValue("@customerId", order.Customer.CustomerId);
            _orderCommand.Parameters.AddWithValue("@orderStatusId", order.OrderStatus.StatusId);
            _orderCommand.Parameters.AddWithValue("@deliveryDate", order.DeliveryDate);
            _orderCommand.Parameters.AddWithValue("@hasLoan", order.hasLoan);
            _orderCommand.Parameters.AddWithValue("@finalPrice", order.FinalPrice);
            _orderCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _orderCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateOrder(Order order, int id)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.UpdateOrder);
            _orderCommand.Parameters.AddWithValue("@orderId", id);
            _orderCommand.Parameters.AddWithValue("@deliveryDate", order.DeliveryDate);
            _orderCommand.Parameters.AddWithValue("@finalPrice", order.FinalPrice);
            _orderCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _orderCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateOrderStatus(Status status, int id)
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.UpdateOrderStatus);
            _orderCommand.Parameters.AddWithValue("@orderId", id);
            _orderCommand.Parameters.AddWithValue("@orderStatusId", status.StatusId);
            _orderCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _orderCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetOrderId()
        {
            _orderCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetmaxOrderId);
            _orderReader = _orderCommand.ExecuteReader();

            int orderId = -1;

            while (_orderReader.Read())
            {
                orderId = int.Parse(_orderReader["OrderId"].ToString());
            }

            _orderReader.Close();
            _connection.CloseConnection();

            return orderId;
        }
    }
}
