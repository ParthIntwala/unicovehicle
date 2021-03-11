using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class CompanyBLL : ICompanyBLL
    {
        private readonly ICompanyDAL _companyDAL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public CompanyBLL(ICompanyDAL companyDAL, IMiscellaneousCallsDAL miscellaneousCallsDAL)
        {
            _companyDAL = companyDAL;
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
        }

        public List<Company> Get()
        {
            List<Company> _company = _companyDAL.GetCompany();

            foreach (Company company in _company)
            {
                company.District = _miscellaneousCallsDAL.GetDistrictbyId(company.District.DistrictId);
            }

            return _company;
        }

        public Company GetCompanybyId(int id)
        {
            Company _company = _companyDAL.GetCompanybyId(id);

            if(_company.CompanyId != 0)
                _company.District = _miscellaneousCallsDAL.GetDistrictbyId(_company.District.DistrictId);

            return _company;
        }

        public bool InsertCompany(Company company)
        {
            _status = _companyDAL.InsertCompany(company);
            return _status;
        }

        public bool DeleteCompany(int id)
        {
            _status = _companyDAL.DeleteCompany(id);
            return _status;
        }

        public bool UpdateCompany(Company company, int companyId)
        {
            _status = _companyDAL.UpdateCompany(company, companyId);
            return _status;
        }
    }
}
