using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class StatusDAL : IStatusDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _statusCommand;
        private SqlDataReader _statusReader;
        int _success;

        public StatusDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<Status> GetStatus()
        {
            _statusCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetStatus);
            _statusReader = _statusCommand.ExecuteReader();

            Status _status;
            List<Status> _statuses = new List<Status>();

            while (_statusReader.Read())
            {
                _status = new Status()
                {
                    StatusId = int.Parse(_statusReader["StatusId"].ToString()),
                    TransactionStatus = _statusReader["Status"].ToString(),
                };

                _statuses.Add(_status);
            }

            _statusReader.Close();
            _connection.CloseConnection();

            return _statuses;
        }

        public Status GetStatusbyId(int id)
        {
            _statusCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetStatusbyId);
            _statusCommand.Parameters.AddWithValue("@statusId", id);
            _statusReader = _statusCommand.ExecuteReader();

            Status _status = new Status();

            while (_statusReader.Read())
            {
                _status = new Status
                {
                    TransactionStatus = _statusReader["Status"].ToString(),
                    StatusId = id,
                };
            }

            _statusReader.Close();
            _connection.CloseConnection();

            return _status;

        }

        public bool InsertStatus(string status)
        {
            _statusCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertStatus);
            _statusCommand.Parameters.AddWithValue("@status", status);
            _statusCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _statusCommand.ExecuteNonQuery();
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

        public bool DeleteStatus(int id)
        {
            _statusCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteStatus);
            _statusCommand.Parameters.AddWithValue("@statusId", id);
            _statusCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _statusCommand.ExecuteNonQuery();
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

        public bool UpdateStatus(string accessoriesType, int accessoriesTypeId)
        {
            _statusCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.UpdateStatus);
            _statusCommand.Parameters.AddWithValue("@status", accessoriesType);
            _statusCommand.Parameters.AddWithValue("@statusId", accessoriesTypeId);
            _statusCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _statusCommand.ExecuteNonQuery();
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
