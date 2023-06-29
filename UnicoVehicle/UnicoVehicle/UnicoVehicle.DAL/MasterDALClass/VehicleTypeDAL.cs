using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace UnicoVehicle.DAL
{
    public class VehicleTypeDAL : IVehicleTypeDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _vehicleCommand;
        private SqlDataReader _vehicleReader;
        int _success;

        public VehicleTypeDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<VehicleType> GetVehicleType()
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetVehicleType);
            _vehicleReader = _vehicleCommand.ExecuteReader();

            VehicleType _vehicleType;
            List<VehicleType> _vehicleTypes = new List<VehicleType>();

            while (_vehicleReader.Read())
            {
                _vehicleType = new VehicleType()
                {
                    VehicleTypeId = int.Parse(_vehicleReader["VehicleTypeId"].ToString()),
                    VehicleTypeName = _vehicleReader["VehicleType"].ToString(),
                };

                _vehicleTypes.Add(_vehicleType);
            }

            _vehicleReader.Close();
            _connection.CloseConnection();

            return _vehicleTypes;
        }

        public VehicleType GetVehicleTypebyId(int id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetVehicleTypebyId);
            _vehicleCommand.Parameters.AddWithValue("@vehicleTypeId", id);
            _vehicleReader = _vehicleCommand.ExecuteReader();

            VehicleType _vehicleType = new VehicleType();

            while (_vehicleReader.Read())
            {
                _vehicleType = new VehicleType
                {
                    VehicleTypeName = _vehicleReader["VehicleType"].ToString(),
                    VehicleTypeId = id,
                };
            }

            _vehicleReader.Close();
            _connection.CloseConnection();

            return _vehicleType;

        }

        public bool InsertVehicleType(string vehicleType)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertVehicleType);
            _vehicleCommand.Parameters.AddWithValue("@vehicleType", vehicleType);
            _vehicleCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _vehicleCommand.ExecuteNonQuery();
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

        public bool DeleteVehicleType(int id)
        {
            _vehicleCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteVehicleType);
            _vehicleCommand.Parameters.AddWithValue("@vehicleTypeId", id);
            _vehicleCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _vehicleCommand.ExecuteNonQuery();
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
