using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class FuelTypeDAL : IFuelTypeDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _fuelTypeCommand;
        private SqlDataReader _fuelTypeReader;
        int _success;

        public FuelTypeDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<FuelType> GetFuelType()
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetFuelType);
            _fuelTypeReader = _fuelTypeCommand.ExecuteReader();

            FuelType _fuelType;
            List<FuelType> _fuelTypes = new List<FuelType>();

            while (_fuelTypeReader.Read())
            {
                _fuelType = new FuelType()
                {
                    FuelTypeId = int.Parse(_fuelTypeReader["FuelTypeId"].ToString()),
                    FuelTypeName = _fuelTypeReader["FuelType"].ToString(),
                };

                _fuelTypes.Add(_fuelType);
            }

            _fuelTypeReader.Close();
            _connection.CloseConnection();

            return _fuelTypes;
        }

        public FuelType GetFuelTypebyId(int id)
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetFuelTypebyId);
            _fuelTypeCommand.Parameters.AddWithValue("@fuelTypeId", id);
            _fuelTypeReader = _fuelTypeCommand.ExecuteReader();

            FuelType _fuelType = new FuelType();

            while (_fuelTypeReader.Read())
            {
                _fuelType = new FuelType
                {
                    FuelTypeName = _fuelTypeReader["FuelType"].ToString(),
                    FuelTypeId = id,
                };
            }

            _fuelTypeReader.Close();
            _connection.CloseConnection();

            return _fuelType;

        }

        public bool InsertFuelType(string fuelType)
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertFuelType);
            _fuelTypeCommand.Parameters.AddWithValue("@fuelType", fuelType);
            _fuelTypeCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _fuelTypeCommand.ExecuteNonQuery();
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

        public bool DeleteFuelType(int id)
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteFuelType);
            _fuelTypeCommand.Parameters.AddWithValue("@fuelTypeId", id);
            _fuelTypeCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _fuelTypeCommand.ExecuteNonQuery();
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
