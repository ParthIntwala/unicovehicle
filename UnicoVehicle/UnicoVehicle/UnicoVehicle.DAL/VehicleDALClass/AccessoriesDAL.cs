using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class AccessoriesDAL : IAccessoriesDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _accessoriesCommand;
        private SqlDataReader _accessoriesReader;
        int _success;

        public AccessoriesDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<Accessories> GetAccessories()
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetAccessories);
            _accessoriesReader = _accessoriesCommand.ExecuteReader();

            Accessories _accessories;
            List<Accessories> _accessoriess = new List<Accessories>();

            while (_accessoriesReader.Read())
            {
                _accessories = new Accessories
                {
                    AccessoriesId = int.Parse(_accessoriesReader["AccessoriesId"].ToString()),
                    Price = double.Parse(_accessoriesReader["Price"].ToString()),
                    AccessoriesName = _accessoriesReader["Accessory"].ToString(),
                    AccessoryBrand = new AccessoryBrand
                    {
                        AccessoryBrandId = int.Parse(_accessoriesReader["AccessoryBrandId"].ToString()),
                    },
                    VehicleName = new VehicleName
                    {
                        VehicleNameId = int.Parse(_accessoriesReader["VehicleNameId"].ToString()),
                    },
                    AccessoriesType = new AccessoriesType
                    {
                        AccessoriesTypeId = int.Parse(_accessoriesReader["AccessoryTypeId"].ToString()),
                    }
                };

                _accessoriess.Add(_accessories);
            }

            _accessoriesReader.Close();
            _connection.CloseConnection();

            return _accessoriess;
        }

        public Accessories GetAccessoriesbyId(int id)
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.GetAccessoriesbyId);
            _accessoriesCommand.Parameters.AddWithValue("@accessoriesId", id);
            _accessoriesReader = _accessoriesCommand.ExecuteReader();

            Accessories _accessories = new Accessories();
            while (_accessoriesReader.Read())
            {
                _accessories = new Accessories
                {
                    AccessoriesId = id,
                    Price = double.Parse(_accessoriesReader["Price"].ToString()),
                    AccessoriesName = _accessoriesReader["Accessory"].ToString(),
                    AccessoryBrand = new AccessoryBrand
                    {
                        AccessoryBrandId = int.Parse(_accessoriesReader["AccessoryBrandId"].ToString()),
                    },
                    VehicleName = new VehicleName
                    {
                        VehicleNameId = int.Parse(_accessoriesReader["VehicleNameId"].ToString()),
                    },
                    AccessoriesType = new AccessoriesType
                    {
                        AccessoriesTypeId = int.Parse(_accessoriesReader["AccessoryTypeId"].ToString()),
                    }
                };
            }

            _accessoriesReader.Close();
            _connection.CloseConnection();

            return _accessories;
        }

        public bool InsertAccessories(Accessories accessories)
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.InsertAccessory);
            _accessoriesCommand.Parameters.AddWithValue("@vehicleNameId", accessories.VehicleName.VehicleNameId);
            _accessoriesCommand.Parameters.AddWithValue("@accessoryTypeId", accessories.AccessoriesType.AccessoriesTypeId);
            _accessoriesCommand.Parameters.AddWithValue("@accessoryBrandId", accessories.AccessoryBrand.AccessoryBrandId);
            _accessoriesCommand.Parameters.AddWithValue("@price", accessories.Price);
            _accessoriesCommand.Parameters.AddWithValue("@accessory", accessories.AccessoriesName);
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

        public bool UpdateAccessories(Accessories accessories, int id)
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.UpdateAccessory);
            _accessoriesCommand.Parameters.AddWithValue("@accessoriesId", id);
            _accessoriesCommand.Parameters.AddWithValue("@price", accessories.Price);
            _accessoriesCommand.Parameters.AddWithValue("@accessory", accessories.AccessoriesName);
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

        public bool DeleteAccessories(int id)
        {
            _accessoriesCommand = _utils.CommandGenerator(ResourceFiles.VehicleDALResources.DeleteAccessory);
            _accessoriesCommand.Parameters.AddWithValue("@accessoriesId", id);
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
    }
}
