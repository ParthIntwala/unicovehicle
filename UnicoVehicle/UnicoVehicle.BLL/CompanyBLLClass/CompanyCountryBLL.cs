using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class CompanyCountryBLL : ICompanyCountryBLL
    {
        private readonly ICompanyCountryDAL _companyCountryDAL;
        private readonly ICompanyBLL _companyBLL;
        private readonly IDistrictBLL _districtBLL;
        bool _status;

        public CompanyCountryBLL(ICompanyBLL companyBLL, IDistrictBLL districtBLL, ICompanyCountryDAL companyCountryDAL)
        {
            _companyBLL = companyBLL;
            _districtBLL = districtBLL;
            _companyCountryDAL = companyCountryDAL;
        }

        public List<CompanyCountry> Get()
        {
            List<CompanyCountry> _company = _companyCountryDAL.GetCompanyCountry();

            foreach (CompanyCountry company in _company)
            {
                company.District = _districtBLL.GetDistrictbyId(company.District.DistrictId);
                company.Company = _companyBLL.GetCompanybyId(company.Company.CompanyId);
            }

            return _company;
        }

        public CompanyCountry GetCompanyCountrybyId(int id)
        {
            CompanyCountry _company = _companyCountryDAL.GetCompanyCountrybyId(id);

            if(_company.CompanyCountryId != 0)
            {
                _company.District = _districtBLL.GetDistrictbyId(_company.District.DistrictId);
                _company.Company = _companyBLL.GetCompanybyId(_company.Company.CompanyId);
            }

            return _company;
        }

        public bool InsertCompanyCountry(CompanyCountry company)
        {
            _status = _companyCountryDAL.InsertCompanyCountry(company);
            return _status;
        }

        public bool DeleteCompanyCountry(int id)
        {
            _status = _companyCountryDAL.DeleteCompanyCountry(id);
            return _status;
        }

        public bool UpdateCompanyCountry(CompanyCountry company, int companyCountryId)
        {
            _status = _companyCountryDAL.UpdateCompanyCountry(company, companyCountryId);
            return _status;
        }
    }
}
