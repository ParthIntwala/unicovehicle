using System;
using UnicoVehicle.Utilities;
using System.Data.SqlClient;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public class CompanyCountryDAL : ICompanyCountryDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _companyCountryCommand;
        private SqlDataReader _companyCountryReader;
        int _success;

        public CompanyCountryDAL(Connection connection, IUtils utils)
        {
            _utils = utils;
            _connection = connection;
        }

        public CompanyCountry GetCompanyCountrybyId(int id)
        {
            _companyCountryCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetCompanyCountrybyId);
            _companyCountryCommand.Parameters.AddWithValue("@companyCountryId", id);
            _companyCountryReader = _companyCountryCommand.ExecuteReader();

            CompanyCountry _company = new CompanyCountry();

            while (_companyCountryReader.Read())
            {
                _company = new CompanyCountry()
                {
                    CompanyCountryId = id,
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_companyCountryReader["CompanyId"].ToString()),
                    },
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_companyCountryReader["DistrictId"].ToString()),
                    },
                    CountryHead = _companyCountryReader["CountryHead"].ToString(),
                    isOperational = bool.Parse(_companyCountryReader["isOperational"].ToString()),
                };
            }

            _companyCountryReader.Close();
            _connection.CloseConnection();

            return _company;
        }

        public bool InsertCompanyCountry(CompanyCountry company)
        {
            _companyCountryCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.InsertCompanyCountry);
            _companyCountryCommand.Parameters.AddWithValue("@districtId", company.District.DistrictId);
            _companyCountryCommand.Parameters.AddWithValue("@companyId", company.Company.CompanyId);
            _companyCountryCommand.Parameters.AddWithValue("@countryHead", company.CountryHead);
            _companyCountryCommand.Parameters.AddWithValue("@isOperational", company.isOperational);
            _companyCountryCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _companyCountryCommand.ExecuteNonQuery();
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

        public bool DeleteCompanyCountry(int id)
        {
            _companyCountryCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.DeleteCompanyCountry);
            _companyCountryCommand.Parameters.AddWithValue("@companyCountryId", id);
            _companyCountryCommand.Parameters.AddWithValue("@deletedDate", DateTime.Now);

            _success = _companyCountryCommand.ExecuteNonQuery();
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

        public bool UpdateCompanyCountry(CompanyCountry company, int id)
        {
            _companyCountryCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.UpdateCompanyCountry);
            _companyCountryCommand.Parameters.AddWithValue("@districtId", company.District.DistrictId);
            _companyCountryCommand.Parameters.AddWithValue("@countryHead", company.CountryHead);
            _companyCountryCommand.Parameters.AddWithValue("@isOperational", company.isOperational);
            _companyCountryCommand.Parameters.AddWithValue("@companyCountryId", id);
            _companyCountryCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _companyCountryCommand.ExecuteNonQuery();
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

        public List<CompanyCountry> GetCompanybyCountry(int id)
        {
            _companyCountryCommand = _utils.CommandGenerator(ResourceFiles.CompanyDALResources.GetCompanybyCountry);
            _companyCountryCommand.Parameters.AddWithValue("@countryId", id);
            _companyCountryReader = _companyCountryCommand.ExecuteReader();

            List<CompanyCountry> _companies = new List<CompanyCountry>();
            CompanyCountry _company;

            while (_companyCountryReader.Read())
            {
                _company = new CompanyCountry()
                {
                    CompanyCountryId = id,
                    Company = new DTO.Miscellaneous.Company
                    {
                        CompanyId = int.Parse(_companyCountryReader["CompanyId"].ToString()),
                    },
                    District = new DTO.Miscellaneous.District
                    {
                        DistrictId = int.Parse(_companyCountryReader["DistrictId"].ToString()),
                    },
                    CountryHead = _companyCountryReader["CountryHead"].ToString(),
                    isOperational = bool.Parse(_companyCountryReader["isOperational"].ToString()),
                };

                _companies.Add(_company);
            }

            _companyCountryReader.Close();
            _connection.CloseConnection();

            return _companies;

        }
    }
}
