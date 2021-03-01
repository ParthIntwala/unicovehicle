using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class InsuranceTypeDAL : IInsuranceTypeDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _insuranceCommand;
        private SqlDataReader _insuranceReader;
        int _success;

        public InsuranceTypeDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<InsuranceType> GetInsuranceType()
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetInsuranceType);
            _insuranceReader = _insuranceCommand.ExecuteReader();

            InsuranceType _insuranceType;
            List<InsuranceType> _insuranceTypes = new List<InsuranceType>();

            while (_insuranceReader.Read())
            {
                _insuranceType = new InsuranceType()
                {
                    InsuranceTypeId = int.Parse(_insuranceReader["InsuranceTypeId"].ToString()),
                    InsuranceTypeName = _insuranceReader["InsuranceType"].ToString(),
                };

                _insuranceTypes.Add(_insuranceType);
            }

            _insuranceReader.Close();
            _connection.CloseConnection();

            return _insuranceTypes;
        }

        public InsuranceType GetInsuranceTypebyId(int id)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.GetInsuranceTypebyId);
            _insuranceCommand.Parameters.AddWithValue("@insuranceTypeId", id);
            _insuranceReader = _insuranceCommand.ExecuteReader();

            InsuranceType _insuranceType = new InsuranceType();

            while (_insuranceReader.Read())
            {
                _insuranceType = new InsuranceType
                {
                    InsuranceTypeName = _insuranceReader["InsuranceType"].ToString(),
                    InsuranceTypeId = id,
                };
            }

            _insuranceReader.Close();
            _connection.CloseConnection();

            return _insuranceType;

        }

        public bool InsertInsuranceType(string insuranceType)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.InsertStatus);
            _insuranceCommand.Parameters.AddWithValue("@insuranceType", insuranceType);
            _insuranceCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _insuranceCommand.ExecuteNonQuery();
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

        public bool DeleteInsuranceType(int id)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.DeleteStatus);
            _insuranceCommand.Parameters.AddWithValue("@insuranceTypeId", id);
            _insuranceCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _insuranceCommand.ExecuteNonQuery();
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

        public bool UpdateInsuranceType(string insuranceType, int insuranceTypeId)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.MasterDALResources.UpdateStatus);
            _insuranceCommand.Parameters.AddWithValue("@insuranceType", insuranceType);
            _insuranceCommand.Parameters.AddWithValue("@insuranceTypeId", insuranceTypeId);
            _insuranceCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _insuranceCommand.ExecuteNonQuery();
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
