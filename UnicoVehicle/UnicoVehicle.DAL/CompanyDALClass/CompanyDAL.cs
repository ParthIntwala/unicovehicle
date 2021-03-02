using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class CompanyDAL : ICompanyDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _companyCommand;
        private SqlDataReader _companyReader;
        int _success;

        public CompanyDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public List<Company> GetCompany()
        {
            _companyCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetCompany);
            _companyReader = _companyCommand.ExecuteReader();

            Company _company;
            List<Company> _companies = new List<Company>();

            while (_companyReader.Read())
            {
                _company = new Company()
                {
                    CompanyId = int.Parse(_companyReader["CompanyId"].ToString()),
                    District = new District
                    {
                        DistrictId = int.Parse(_companyReader["DistrictId"].ToString()),
                    },
                    CompanyName = _companyReader["CompanyName"].ToString(),
                    CompanyHead = _companyReader["CompanyHead"].ToString(),
                };

                _companies.Add(_company);
            }

            _companyReader.Close();
            _connection.CloseConnection();

            return _companies;
        }

        public Company GetCompanybyId(int id)
        {
            _companyCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetCompanybyId);
            _companyCommand.Parameters.AddWithValue("@companyId", id);
            _companyReader = _companyCommand.ExecuteReader();

            Company _company = new Company();

            while (_companyReader.Read())
            {
                _company = new Company()
                {
                    CompanyId = id,
                    District = new District
                    {
                        DistrictId = int.Parse(_companyReader["DistrictId"].ToString()),
                    },
                    CompanyName = _companyReader["CompanyName"].ToString(),
                    CompanyHead = _companyReader["CompanyHead"].ToString(),
                };
            }

            _companyReader.Close();
            _connection.CloseConnection();

            return _company;

        }

        public bool InsertCompany(Company company)
        {
            _companyCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.InsertCompany);
            _companyCommand.Parameters.AddWithValue("@districtId", company.District.DistrictId);
            _companyCommand.Parameters.AddWithValue("@companyName", company.CompanyName);
            _companyCommand.Parameters.AddWithValue("@companyHead", company.CompanyHead);
            _companyCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _companyCommand.ExecuteNonQuery();
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

        public bool DeleteCompany(int id)
        {
            _companyCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.DeleteCompany);
            _companyCommand.Parameters.AddWithValue("@companyId", id);
            _companyCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _companyCommand.ExecuteNonQuery();
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

        public bool UpdateCompany(Company company, int id)
        {
            _companyCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.UpdateCompany);
            _companyCommand.Parameters.AddWithValue("@districtId", company.District.DistrictId);
            _companyCommand.Parameters.AddWithValue("@companyName", company.CompanyName);
            _companyCommand.Parameters.AddWithValue("@companyHead", company.CompanyHead);
            _companyCommand.Parameters.AddWithValue("@companyId", id);
            _companyCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _companyCommand.ExecuteNonQuery();
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
