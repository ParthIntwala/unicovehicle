using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class CompanyCountryBLL : ICompanyCountryBLL
    {
        private readonly ICompanyCountryDAL _companyCountryDAL;
        private readonly IMiscellaneousCalls _miscellaneousCalls;
        bool _status;

        public CompanyCountryBLL(IMiscellaneousCalls miscellaneousCalls, ICompanyCountryDAL companyCountryDAL)
        {
            _miscellaneousCalls = miscellaneousCalls;
            _companyCountryDAL = companyCountryDAL;
        }

        public CompanyCountry GetCompanyCountrybyId(int id)
        {
            CompanyCountry _company = _companyCountryDAL.GetCompanyCountrybyId(id);

            if(_company.CompanyCountryId != 0)
            {
                _company.District = _miscellaneousCalls.GetDistrictbyId(_company.District.DistrictId);
                _company.Company = _miscellaneousCalls.GetCompanybyId(_company.Company.CompanyId);
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
