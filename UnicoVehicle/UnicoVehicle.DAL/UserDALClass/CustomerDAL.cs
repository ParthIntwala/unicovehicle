using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class CustomerDAL : ICustomerDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _customerCommand;
        private SqlDataReader _customerReader;
        int _success;

        public CustomerDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<Customer> GetCustomer()
        {
            _customerCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.GetCustomer);
            _customerReader = _customerCommand.ExecuteReader();

            Customer _customer;
            List<Customer> _customers = new List<Customer>();

            while (_customerReader.Read())
            {
                _customer = new Customer()
                {
                    User = new User
                    {
                        UserId = int.Parse(_customerReader["UserId"].ToString()),
                    },
                    District = new District
                    {
                        DistrictId = int.Parse(_customerReader["DistrictId"].ToString()),
                    },
                    Address = _customerReader["Address"].ToString(),
                    BankPassbookPhoto = _customerReader["BankPassbookPhoto"].ToString(),
                    DrivingLicenseNumber = _customerReader["DrivingLicenseNumber"].ToString(),
                    Photograph = _customerReader["Photograph"].ToString(),
                    IncomeTaxIDNumber = _customerReader["IncomeTaxIDNumber"].ToString(),
                    LastITReturn = _customerReader["LastITReturn"].ToString(),
                    StandardIDNumber = _customerReader["StandardIDNumber"].ToString(),
                    CustomerId = int.Parse(_customerReader["CustomerId"].ToString()),
                };

                _customers.Add(_customer);
            }

            _customerReader.Close();
            _connection.CloseConnection();

            return _customers;
        }

        public Customer GetCustomerbyId(int id)
        {
            _customerCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.GetCustomerbyId);
            _customerCommand.Parameters.AddWithValue("@customerId", id);
            _customerReader = _customerCommand.ExecuteReader();

            Customer _customer = new Customer();

            while (_customerReader.Read())
            {
                _customer = new Customer()
                {
                    User = new User
                    {
                        UserId = int.Parse(_customerReader["UserId"].ToString()),
                    },
                    District = new District
                    {
                        DistrictId = int.Parse(_customerReader["DistrictId"].ToString()),
                    },
                    Address = _customerReader["Address"].ToString(),
                    BankPassbookPhoto = _customerReader["BankPassbookPhoto"].ToString(),
                    DrivingLicenseNumber = _customerReader["DrivingLicenseNumber"].ToString(),
                    Photograph = _customerReader["Photograph"].ToString(),
                    IncomeTaxIDNumber = _customerReader["IncomeTaxIDNumber"].ToString(),
                    LastITReturn = _customerReader["LastITReturn"].ToString(),
                    StandardIDNumber = _customerReader["StandardIDNumber"].ToString(),
                    CustomerId = id,
                };
            }

            _customerReader.Close();
            _connection.CloseConnection();

            return _customer;

        }

        public bool InsertCustomer(Customer customer)
        {
            _customerCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.InsertCustomer);
            _customerCommand.Parameters.AddWithValue("@userId", customer.User.UserId);
            _customerCommand.Parameters.AddWithValue("@districtId", customer.District.DistrictId);
            _customerCommand.Parameters.AddWithValue("@address", customer.Address);
            _customerCommand.Parameters.AddWithValue("@bankPassbookPhoto", customer.BankPassbookPhoto);
            _customerCommand.Parameters.AddWithValue("@drivingLicenseNumber", customer.DrivingLicenseNumber);
            _customerCommand.Parameters.AddWithValue("@photograph", customer.Photograph);
            _customerCommand.Parameters.AddWithValue("@incomeTaxIDNumber", customer.IncomeTaxIDNumber);
            _customerCommand.Parameters.AddWithValue("@lastITReturn", customer.LastITReturn);
            _customerCommand.Parameters.AddWithValue("@standardIDNumber", customer.StandardIDNumber);
            _customerCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _customerCommand.ExecuteNonQuery();
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

        public bool DeleteCustomer(int id)
        {
            _customerCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.DeleteCustomer);
            _customerCommand.Parameters.AddWithValue("@customerId", id);
            _customerCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _customerCommand.ExecuteNonQuery();
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

        public bool UpdateCustomer(Customer customer, int id)
        {
            _customerCommand = _utils.CommandGenerator(ResourceFiles.UserDALResources.UpdateCustomer);
            _customerCommand.Parameters.AddWithValue("@districtId", customer.District.DistrictId);
            _customerCommand.Parameters.AddWithValue("@address", customer.Address);
            _customerCommand.Parameters.AddWithValue("@bankPassbookPhoto", customer.BankPassbookPhoto);
            _customerCommand.Parameters.AddWithValue("@drivingLicenseNumber", customer.DrivingLicenseNumber);
            _customerCommand.Parameters.AddWithValue("@photograph", customer.Photograph);
            _customerCommand.Parameters.AddWithValue("@lastITReturn", customer.LastITReturn);
            _customerCommand.Parameters.AddWithValue("@customerId", id);
            _customerCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _customerCommand.ExecuteNonQuery();
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
    }
}
