using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace UnicoVehicle.DAL
{
    public class AccessoryBrandDAL : IAccessoryBrandDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _accessoryCommand;
        private SqlDataReader _accessoryReader;
        int _success;

        public AccessoryBrandDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<AccessoryBrand> GetAccessoryBrand()
        {
            _accessoryCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetAccessoryBrand);
            _accessoryReader = _accessoryCommand.ExecuteReader();

            AccessoryBrand _accessoryBrand;
            List<AccessoryBrand> _accessoryBrands = new List<AccessoryBrand>();

            while (_accessoryReader.Read())
            {
                _accessoryBrand = new AccessoryBrand()
                {
                    AccessoryBrandId = int.Parse(_accessoryReader["AccessoryBrandId"].ToString()),
                    AccessoryBrandName = _accessoryReader["AccessoryBrand"].ToString(),
                };

                _accessoryBrands.Add(_accessoryBrand);
            }

            _accessoryReader.Close();
            _connection.CloseConnection();

            return _accessoryBrands;
        }

        public AccessoryBrand GetAccessoryBrandbyId(int id)
        {
            _accessoryCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetAccessoryBrandbyId);
            _accessoryCommand.Parameters.AddWithValue("@accessoryBrandId", id);
            _accessoryReader = _accessoryCommand.ExecuteReader();

            AccessoryBrand _accessoryBrand = new AccessoryBrand();

            while (_accessoryReader.Read())
            {
                _accessoryBrand = new AccessoryBrand
                {
                    AccessoryBrandId = id,
                    AccessoryBrandName = _accessoryReader["AccessoryBrand"].ToString(),
                };
            }

            _accessoryReader.Close();
            _connection.CloseConnection();

            return _accessoryBrand;

        }

        public bool InsertAccessoryBrand(string accessoryBrand)
        {
            _accessoryCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertAccessoryBrand);
            _accessoryCommand.Parameters.AddWithValue("@accessoryBrand", accessoryBrand);
            _accessoryCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _accessoryCommand.ExecuteNonQuery();
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

        public bool DeleteAccessoryBrand(int id)
        {
            _accessoryCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteAccessoryBrand);
            _accessoryCommand.Parameters.AddWithValue("@accessoryBrandId", id);
            _accessoryCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _accessoryCommand.ExecuteNonQuery();
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
