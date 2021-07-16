using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace UnicoVehicle.DAL
{
    public class TransmissionTypeDAL : ITransmissionTypeDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _transmissionCommand;
        private SqlDataReader _transmissionReader;
        int _success;

        public TransmissionTypeDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<TransmissionType> GetTransmissionType()
        {
            _transmissionCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetTransmissionType);
            _transmissionReader = _transmissionCommand.ExecuteReader();

            TransmissionType _transmissionType;
            List<TransmissionType> _transmissionTypes = new List<TransmissionType>();

            while (_transmissionReader.Read())
            {
                _transmissionType = new TransmissionType()
                {
                    TransmissionTypeId = int.Parse(_transmissionReader["TransmissionTypeId"].ToString()),
                    GearTransmission = _transmissionReader["TransmissionType"].ToString(),
                };

                _transmissionTypes.Add(_transmissionType);
            }

            _transmissionReader.Close();
            _connection.CloseConnection();

            return _transmissionTypes;
        }

        public TransmissionType GetTransmissionTypebyId(int id)
        {
            _transmissionCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetTransmissionTypebyId);
            _transmissionCommand.Parameters.AddWithValue("@transmissionTypeId", id);
            _transmissionReader = _transmissionCommand.ExecuteReader();

            TransmissionType _transmissionType = new TransmissionType();

            while (_transmissionReader.Read())
            {
                _transmissionType = new TransmissionType
                {
                    GearTransmission = _transmissionReader["TransmissionType"].ToString(),
                    TransmissionTypeId = id,
                };
            }

            _transmissionReader.Close();
            _connection.CloseConnection();

            return _transmissionType;

        }

        public bool InsertTransmissionType(string transmissionType)
        {
            _transmissionCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertTransmissionType);
            _transmissionCommand.Parameters.AddWithValue("@transmissionType", transmissionType);
            _transmissionCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _transmissionCommand.ExecuteNonQuery();
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

        public bool DeleteTransmissionType(int id)
        {
            _transmissionCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteTransmissionType);
            _transmissionCommand.Parameters.AddWithValue("@transmissionTypeId", id);
            _transmissionCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _transmissionCommand.ExecuteNonQuery();
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
