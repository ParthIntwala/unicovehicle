using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class VehiclePriceDAL : IVehiclePriceDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _priceCommand;
        private SqlDataReader _priceReader;
        int _success;

        public VehiclePriceDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<VehiclePrice> GetVehiclePricebyShowroom(int id)
        {
            _priceCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehiclePricebyShowroom);
            _priceCommand.Parameters.AddWithValue("@showroomId", id);
            _priceReader = _priceCommand.ExecuteReader();

            VehiclePrice _price;
            List<VehiclePrice> _prices = new List<VehiclePrice>();

            while (_priceReader.Read())
            {
                _price = new VehiclePrice
                {
                    VehiclePriceId = int.Parse(_priceReader["VehiclePriceId"].ToString()),
                    Price = double.Parse(_priceReader["VehiclePrice"].ToString()),
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = int.Parse(_priceReader["ShowroomId"].ToString()),
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_priceReader["VehicleId"].ToString()),
                    }
                };

                _prices.Add(_price);
            }

            _priceReader.Close();
            _connection.CloseConnection();

            return _prices;
        }

        public List<VehiclePrice> GetVehiclePricebyVehicle(int id)
        {
            _priceCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehiclePricebyVehicle);
            _priceCommand.Parameters.AddWithValue("@vehicleId", id);
            _priceReader = _priceCommand.ExecuteReader();

            VehiclePrice _price;
            List<VehiclePrice> _prices = new List<VehiclePrice>();

            while (_priceReader.Read())
            {
                _price = new VehiclePrice
                {
                    VehiclePriceId = int.Parse(_priceReader["VehiclePriceId"].ToString()),
                    Price = double.Parse(_priceReader["VehiclePrice"].ToString()),
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = int.Parse(_priceReader["ShowroomId"].ToString()),
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_priceReader["VehicleId"].ToString()),
                    }
                };

                _prices.Add(_price);
            }

            _priceReader.Close();
            _connection.CloseConnection();

            return _prices;
        }

        public bool InsertVehiclePrice(VehiclePrice price)
        {
            _priceCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertVehiclePrice);
            _priceCommand.Parameters.AddWithValue("@vehicleId", price.Vehicle.VehicleId);
            _priceCommand.Parameters.AddWithValue("@showroomId", price.Showroom.ShowroomId);
            _priceCommand.Parameters.AddWithValue("@price", price.Price);
            _priceCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _priceCommand.ExecuteNonQuery();
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

        public bool UpdateVehiclePrice(VehiclePrice price, int id)
        {
            _priceCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateVehiclePrice);
            _priceCommand.Parameters.AddWithValue("@vehiclePriceId", id);
            _priceCommand.Parameters.AddWithValue("@price", price.Price);
            _priceCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _priceCommand.ExecuteNonQuery();
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
