﻿using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class InsuranceCompanyBLL : IInsuranceCompanyBLL
    {
        private readonly IInsuranceCompanyDAL _insuranceCompanyDAL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public InsuranceCompanyBLL(IInsuranceCompanyDAL insuranceCompanyDAL, IMiscellaneousCallsDAL miscellaneousCallsDAL)
        {
            _insuranceCompanyDAL = insuranceCompanyDAL;
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
        }

        public List<InsuranceCompany> Get()
        {
            List<InsuranceCompany> _insuranceCompany = _insuranceCompanyDAL.GetInsuranceCompany();

            foreach (InsuranceCompany insuranceCompany in _insuranceCompany)
            {
                insuranceCompany.District = _miscellaneousCallsDAL.GetDistrictbyId(insuranceCompany.District.DistrictId);
            }

            return _insuranceCompany;
        }

        public InsuranceCompany GetInsuranceCompanybyId(int id)
        {
            InsuranceCompany _insuranceCompany = _insuranceCompanyDAL.GetInsuranceCompanybyId(id);

            if (_insuranceCompany.InsuranceCompanyId != 0)
            {
                _insuranceCompany.District = _miscellaneousCallsDAL.GetDistrictbyId(_insuranceCompany.District.DistrictId);
            }

            return _insuranceCompany;
        }

        public bool InsertInsuranceCompany(InsuranceCompany insuranceCompany)
        {
            _status = _insuranceCompanyDAL.InsertInsuranceCompany(insuranceCompany);
            return _status;
        }

        public bool DeleteInsuranceCompany(int id)
        {
            _status = _insuranceCompanyDAL.DeleteInsuranceCompany(id);
            return _status;
        }

        public bool UpdateInsuranceCompany(InsuranceCompany InsuranceCompany, int insuranceCompanyId)
        {
            _status = _insuranceCompanyDAL.UpdateInsuranceCompany(InsuranceCompany, insuranceCompanyId);
            return _status;
        }
    }
}
