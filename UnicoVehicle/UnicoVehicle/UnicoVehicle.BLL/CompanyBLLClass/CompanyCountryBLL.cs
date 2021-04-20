using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class CompanyCountryBLL : ICompanyCountryBLL
    {
        private readonly ICompanyCountryDAL _companyCountryDAL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public CompanyCountryBLL(IMiscellaneousCallsDAL miscellaneousCallsDAL, ICompanyCountryDAL companyCountryDAL)
        {
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
            _companyCountryDAL = companyCountryDAL;
        }

        public CompanyCountry GetCompanyCountrybyId(int id)
        {
            CompanyCountry _company = _companyCountryDAL.GetCompanyCountrybyId(id);

            if(_company.CompanyCountryId != 0)
            {
                _company.District = _miscellaneousCallsDAL.GetDistrictbyId(_company.District.DistrictId);
                _company.Company = _miscellaneousCallsDAL.GetCompanybyId(_company.Company.CompanyId);
            }

            return _company;
        }

        public List<CompanyCountry> GetCompanybyCountry(int id)
        {
            List<CompanyCountry> _companies = _companyCountryDAL.GetCompanybyCountry(id);

            foreach (CompanyCountry _company in _companies)
            {
                _company.District = _miscellaneousCallsDAL.GetDistrictbyId(_company.District.DistrictId);
                _company.Company = _miscellaneousCallsDAL.GetCompanybyId(_company.Company.CompanyId);
            }

            return _companies;
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
