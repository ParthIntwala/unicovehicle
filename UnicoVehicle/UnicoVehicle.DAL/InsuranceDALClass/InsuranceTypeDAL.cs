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
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.GetInsuranceType);
            _insuranceReader = _insuranceCommand.ExecuteReader();

            InsuranceType _insuranceType;
            List<InsuranceType> _insuranceTypes = new List<InsuranceType>();

            while (_insuranceReader.Read())
            {
                _insuranceType = new InsuranceType()
                {
                    InsuranceTypeId = int.Parse(_insuranceReader["InsuranceTypeId"].ToString()),
                    InsuranceTypeName = _insuranceReader["InsuranceType"].ToString(),
                    InsuranceCompany = new InsuranceCompany
                    {
                        InsuranceCompanyId = int.Parse(_insuranceReader["InsuranceCompanyId"].ToString()),
                    }
                };

                _insuranceTypes.Add(_insuranceType);
            }

            _insuranceReader.Close();
            _connection.CloseConnection();

            return _insuranceTypes;
        }

        public InsuranceType GetInsuranceTypebyId(int id)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.GetInsuranceTypebyId);
            _insuranceCommand.Parameters.AddWithValue("@insuranceTypeId", id);
            _insuranceReader = _insuranceCommand.ExecuteReader();

            InsuranceType _insuranceType = new InsuranceType();

            while (_insuranceReader.Read())
            {
                _insuranceType = new InsuranceType
                {
                    InsuranceTypeName = _insuranceReader["InsuranceType"].ToString(),
                    InsuranceTypeId = id,
                    InsuranceCompany = new InsuranceCompany
                    {
                        InsuranceCompanyId = int.Parse(_insuranceReader["InsuranceCompanyId"].ToString()),
                    }
                };
            }

            _insuranceReader.Close();
            _connection.CloseConnection();

            return _insuranceType;

        }

        public bool InsertInsuranceType(InsuranceType insuranceType)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.InsertInsuranceType);
            _insuranceCommand.Parameters.AddWithValue("@insuranceType", insuranceType.InsuranceTypeName);
            _insuranceCommand.Parameters.AddWithValue("@insuranceCompanyId", insuranceType.InsuranceCompany.InsuranceCompanyId);
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
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.DeleteInsuranceType);
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

        public bool UpdateInsuranceType(InsuranceType insuranceType, int insuranceTypeId)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.UpdateInsuranceType);
            _insuranceCommand.Parameters.AddWithValue("@insuranceType", insuranceType.InsuranceTypeName);
            _insuranceCommand.Parameters.AddWithValue("@insuranceTypeId", insuranceTypeId);
            _insuranceCommand.Parameters.AddWithValue("@insuranceCompanyId", insuranceType.InsuranceCompany.InsuranceCompanyId);
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
