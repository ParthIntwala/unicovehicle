using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class InsuranceCompanyDAL : IInsuranceCompanyDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _insuranceCommand;
        private SqlDataReader _insuranceReader;
        int _success;

        public InsuranceCompanyDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<InsuranceCompany> GetInsuranceCompany()
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.GetInsuranceCompany);
            _insuranceReader = _insuranceCommand.ExecuteReader();

            InsuranceCompany _insuranceCompany;
            List<InsuranceCompany> _insuranceCompanies = new List<InsuranceCompany>();

            while (_insuranceReader.Read())
            {
                _insuranceCompany = new InsuranceCompany()
                {
                    InsuranceCompanyId = int.Parse(_insuranceReader["InsuranceCompanyId"].ToString()),
                    InsuranceCompanyName = _insuranceReader["InsuranceCompany"].ToString(),
                    Address = _insuranceReader["AddressLine1"].ToString(),
                    CountryHead = _insuranceReader["CountryHead"].ToString(),
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_insuranceReader["DistrictId"].ToString()),
                    }
                };

                _insuranceCompanies.Add(_insuranceCompany);
            }

            _insuranceReader.Close();
            _connection.CloseConnection();

            return _insuranceCompanies;
        }

        public InsuranceCompany GetInsuranceCompanybyId(int id)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.GetInsuranceCompanybyId);
            _insuranceCommand.Parameters.AddWithValue("@insuranceCompanyId", id);
            _insuranceReader = _insuranceCommand.ExecuteReader();

            InsuranceCompany _insuranceCompany = new InsuranceCompany();

            while (_insuranceReader.Read())
            {
                _insuranceCompany = new InsuranceCompany
                {
                    InsuranceCompanyId = id,
                    InsuranceCompanyName = _insuranceReader["InsuranceCompany"].ToString(),
                    Address = _insuranceReader["AddressLine1"].ToString(),
                    CountryHead = _insuranceReader["CountryHead"].ToString(),
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_insuranceReader["DistrictId"].ToString()),
                    }
                };
            }

            _insuranceReader.Close();
            _connection.CloseConnection();

            return _insuranceCompany;

        }

        public bool InsertInsuranceCompany(InsuranceCompany insuranceCompany)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.InsertInsuranceCompany);
            _insuranceCommand.Parameters.AddWithValue("@insuranceCompany", insuranceCompany.InsuranceCompanyName);
            _insuranceCommand.Parameters.AddWithValue("@districtId", insuranceCompany.District.DistrictId);
            _insuranceCommand.Parameters.AddWithValue("@countryHead", insuranceCompany.CountryHead);
            _insuranceCommand.Parameters.AddWithValue("@address", insuranceCompany.Address);
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

        public bool DeleteInsuranceCompany(int id)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.DeleteInsuranceCompany);
            _insuranceCommand.Parameters.AddWithValue("@insuranceCompanyId", id);
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

        public bool UpdateInsuranceCompany(InsuranceCompany insuranceCompany, int insuranceCompanyId)
        {
            _insuranceCommand = _utils.CommandGenerator(ResourceFiles.InsuranceDALResources.UpdateInsuranceCompany);
            _insuranceCommand.Parameters.AddWithValue("@insuranceCompany", insuranceCompany.InsuranceCompanyName);
            _insuranceCommand.Parameters.AddWithValue("@districtId", insuranceCompany.District.DistrictId);
            _insuranceCommand.Parameters.AddWithValue("@countryHead", insuranceCompany.CountryHead);
            _insuranceCommand.Parameters.AddWithValue("@address", insuranceCompany.Address);
            _insuranceCommand.Parameters.AddWithValue("@insuranceCompanyId", insuranceCompanyId);
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
