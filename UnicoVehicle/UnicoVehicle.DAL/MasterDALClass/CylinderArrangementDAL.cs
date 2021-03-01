using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class CylinderArrangementDAL : ICylinderArrangementDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _cylinderCommand;
        private SqlDataReader _cylinderReader;
        int _success;

        public CylinderArrangementDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public List<CylinderArrangement> GetCylinderArrangement()
        {
            _cylinderCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetCylinderArrangement);
            _cylinderReader = _cylinderCommand.ExecuteReader();

            CylinderArrangement _cylinderArrangement;
            List<CylinderArrangement> _cylinderArrangements = new List<CylinderArrangement>();

            while (_cylinderReader.Read())
            {
                _cylinderArrangement = new CylinderArrangement()
                {
                    CylinderArrangementId = int.Parse(_cylinderReader["CylinderArrangementId"].ToString()),
                    CylinderArrangementName = _cylinderReader["CylinderArrangement"].ToString(),
                };

                _cylinderArrangements.Add(_cylinderArrangement);
            }

            _cylinderReader.Close();
            _connection.CloseConnection();

            return _cylinderArrangements;
        }

        public CylinderArrangement GetCylinderArrangementbyId(int id)
        {
            _cylinderCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetCylinderArrangementbyId);
            _cylinderCommand.Parameters.AddWithValue("@cylinderArrangementId", id);
            _cylinderReader = _cylinderCommand.ExecuteReader();

            CylinderArrangement _cylinderArrangement = new CylinderArrangement();

            while (_cylinderReader.Read())
            {
                _cylinderArrangement = new CylinderArrangement
                {
                    CylinderArrangementName = _cylinderReader["CylinderArrangement"].ToString(),
                    CylinderArrangementId = id,
                };
            }

            _cylinderReader.Close();
            _connection.CloseConnection();

            return _cylinderArrangement;

        }

        public bool InsertCylinderArrangement(string cylinderArrangement)
        {
            _cylinderCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertCylinderArrangement);
            _cylinderCommand.Parameters.AddWithValue("@cylinderArrangement", cylinderArrangement);
            _cylinderCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _cylinderCommand.ExecuteNonQuery();
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

        public bool DeleteCylinderArrangement(int id)
        {
            _cylinderCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteCylinderArrangement);
            _cylinderCommand.Parameters.AddWithValue("@cylinderArrangementId", id);
            _cylinderCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _cylinderCommand.ExecuteNonQuery();
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
