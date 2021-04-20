using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class BoughtAccessoriesDAL : IBoughtAccessoriesDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _boughtCommand;
        private SqlDataReader _boughtReader;
        int _success;

        public BoughtAccessoriesDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<BoughtAccessories> GetBoughtAccessoriesbyId(int id)
        {
            _boughtCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetBoughtAccessories);
            _boughtCommand.Parameters.AddWithValue("@orderId", id);
            _boughtReader = _boughtCommand.ExecuteReader();

            BoughtAccessories _bought = new BoughtAccessories();
            List<BoughtAccessories> _boughtAccessories = new List<BoughtAccessories>();

            while (_boughtReader.Read())
            {
                _bought = new BoughtAccessories
                {
                    BoughtAccessoriesId = int.Parse(_boughtReader["BoughtAccessoriesId"].ToString()),
                    Accessories = new Accessories
                    {
                        AccessoriesId = int.Parse(_boughtReader["AccessoriesId"].ToString()),
                    }
                };

                _boughtAccessories.Add(_bought);
            }

            _boughtReader.Close();
            _connection.CloseConnection();

            return _boughtAccessories;
        }

        public bool InsertPostBuyingDetail(BoughtAccessories boughtAccessories, int id)
        {
            _boughtCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.InsertBoughtAccessories);
            _boughtCommand.Parameters.AddWithValue("@accessoriesId", boughtAccessories.Accessories.AccessoriesId);
            _boughtCommand.Parameters.AddWithValue("@orderId", id);
            _boughtCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _boughtCommand.ExecuteNonQuery();
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

        public bool DeleteBoughtAccessories(int id)
        {
            _boughtCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.DeleteBoughtAccessories);
            _boughtCommand.Parameters.AddWithValue("@orderId", id);
            _boughtCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _boughtCommand.ExecuteNonQuery();
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
