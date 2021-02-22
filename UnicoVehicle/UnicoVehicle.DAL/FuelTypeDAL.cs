using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class FuelTypeDAL
    {
        //Changes are left to be made in resource file for correct query string and asssigning them to proper variable

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

        public List<FuelType> GetAccessoryType()
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetAccessoriesType);
            _fuelTypeReader = _fuelTypeCommand.ExecuteReader();

            FuelType _fuelType;
            List<FuelType> _fuelTypes = new List<FuelType>();

            while (_fuelTypeReader.Read())
            {
                _fuelType = new FuelType()
                {
                    FuelTypeId = int.Parse(_fuelTypeReader["AccessoriesTypeId"].ToString()),
                    FuelTypeName = _fuelTypeReader["AccessoriesType"].ToString(),
                };

                _fuelTypes.Add(_fuelType);
            }

            _fuelTypeReader.Close();
            _connection.CloseConnection();

            return _fuelTypes;
        }

        public FuelType GetAccessoriesTypebyId(int id)
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetAccessoriesTypebyId);
            _fuelTypeCommand.Parameters.AddWithValue("@accessoriesTypeId", id);
            _fuelTypeReader = _fuelTypeCommand.ExecuteReader();

            FuelType _fuelType = new FuelType();

            while (_fuelTypeReader.Read())
            {
                _fuelType = new FuelType
                {
                    FuelTypeName = _fuelTypeReader["AccessoriesType"].ToString(),
                    FuelTypeId = id,
                };
            }

            _fuelTypeReader.Close();
            _connection.CloseConnection();

            return _fuelType;

        }

        public bool InsertAccessoriesType(string fuelType)
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertAccessoriesType);
            _fuelTypeCommand.Parameters.AddWithValue("@accessoriesType", fuelType);
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

        public bool DeleteAccessoriesType(int id)
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteAccessoriesType);
            _fuelTypeCommand.Parameters.AddWithValue("@accessoriesTypeId", id);
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

        public bool UpdateAccessoriesType(string fuelType, int fuelTypeId)
        {
            _fuelTypeCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.UpdateAccessoriesType);
            _fuelTypeCommand.Parameters.AddWithValue("@accessoriesType", fuelType);
            _fuelTypeCommand.Parameters.AddWithValue("accessoriesTypeId", fuelTypeId);
            _fuelTypeCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

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
