using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class AccessoriesTypeDAL : IAccessoriesTypeDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _accessoriesCommand;
        private SqlDataReader _accessoriesReader;
        int _success;

        public AccessoriesTypeDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<AccessoriesType> GetAccessoryType()
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetAccessoriesType);
            _accessoriesReader = _accessoriesCommand.ExecuteReader();

            AccessoriesType _accessoriesType;
            List<AccessoriesType> _accessoryTypes = new List<AccessoriesType>();

            while (_accessoriesReader.Read())
            {
                _accessoriesType = new AccessoriesType()
                {
                    AccessoriesTypeId = int.Parse(_accessoriesReader["AccessoriesTypeId"].ToString()),
                    Accessories = _accessoriesReader["AccessoriesType"].ToString(),
                };

                _accessoryTypes.Add(_accessoriesType);
            }

            _accessoriesReader.Close();
            _connection.CloseConnection();

            return _accessoryTypes;
        }

        public AccessoriesType GetAccessoriesTypebyId(int id)
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetAccessoriesTypebyId);
            _accessoriesCommand.Parameters.AddWithValue("@accessoriesTypeId", id);
            _accessoriesReader = _accessoriesCommand.ExecuteReader();

            AccessoriesType _accessoriesType = new AccessoriesType();

            while (_accessoriesReader.Read())
            {
                _accessoriesType = new AccessoriesType
                {
                    Accessories = _accessoriesReader["AccessoriesType"].ToString(),
                    AccessoriesTypeId = id,
                };
            }

            _accessoriesReader.Close();
            _connection.CloseConnection();

            return _accessoriesType;

        }

        public bool InsertAccessoriesType(string accessoriesType)
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertAccessoriesType);
            _accessoriesCommand.Parameters.AddWithValue("@accessoriesType", accessoriesType);
            _accessoriesCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _accessoriesCommand.ExecuteNonQuery();
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
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteAccessoriesType);
            _accessoriesCommand.Parameters.AddWithValue("@accessoriesTypeId", id);
            _accessoriesCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _accessoriesCommand.ExecuteNonQuery();
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

        public bool UpdateAccessoriesType(string accessoriesType, int accessoriesTypeId)
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.UpdateAccessoriesType);
            _accessoriesCommand.Parameters.AddWithValue("@accessoriesType", accessoriesType);
            _accessoriesCommand.Parameters.AddWithValue("accessoriesTypeId", accessoriesTypeId);
            _accessoriesCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _accessoriesCommand.ExecuteNonQuery();
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
