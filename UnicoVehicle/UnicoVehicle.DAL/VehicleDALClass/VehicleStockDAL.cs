using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class VehicleStockDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _stockCommand;
        private SqlDataReader _stockReader;
        int _success;

        public VehicleStockDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<VehicleStock> GetVehicleStockbyShowroom(int id)
        {
            _stockCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetVehicleVariantbyCompany);
            _stockCommand.Parameters.AddWithValue("@showroomId", id);
            _stockReader = _stockCommand.ExecuteReader();

            VehicleStock _stock;
            List<VehicleStock> _stocks = new List<VehicleStock>();

            while (_stockReader.Read())
            {
                _stock = new VehicleStock
                {
                    VehicleStockId = int.Parse(_stockReader["VehicleStockId"].ToString()),
                    Stock = int.Parse(_stockReader["VehicleVariant"].ToString()),
                    Showroom = new DTO.Miscellaneous.Showroom
                    {
                        ShowroomId = int.Parse(_stockReader["ShowroomId"].ToString()),
                    },
                    Vehicle = new DTO.Miscellaneous.Vehicle
                    {
                        VehicleId = int.Parse(_stockReader["VehicleId"].ToString()),
                    }
                };

                _stocks.Add(_stock);
            }

            _stockReader.Close();
            _connection.CloseConnection();

            return _stocks;
        }

        public bool InsertVehicleStock(VehicleStock stock)
        {
            _stockCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertVehicleVariant);
            _stockCommand.Parameters.AddWithValue("@vehicleId", stock.Vehicle.VehicleId);
            _stockCommand.Parameters.AddWithValue("@showroomId", stock.Showroom.ShowroomId);
            _stockCommand.Parameters.AddWithValue("@stock", stock.Stock);
            _stockCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _stockCommand.ExecuteNonQuery();
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
