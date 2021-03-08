using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class InsuranceTypeBLL : IInsuranceTypeBLL
    {
        private readonly IInsuranceTypeDAL _insuranceTypeDAL;
        private readonly IMiscellaneousCalls _miscellaneousCalls;
        bool _status;

        public InsuranceTypeBLL(IInsuranceTypeDAL insuranceTypeDAL, IMiscellaneousCalls miscellaneousCalls)
        {
            _insuranceTypeDAL = insuranceTypeDAL;
            _miscellaneousCalls = miscellaneousCalls;
        }

        public List<InsuranceType> Get()
        {
            List<InsuranceType> _insuranceType = _insuranceTypeDAL.GetInsuranceType();

            foreach(InsuranceType insuranceType in _insuranceType)
            {
                insuranceType.InsuranceCompany = _miscellaneousCalls.GetInsuranceCompanybyId(insuranceType.InsuranceCompany.InsuranceCompanyId);
            }

            return _insuranceType;
        }

        public InsuranceType GetInsuranceTypebyId(int id)
        {
            InsuranceType _insuranceType = _insuranceTypeDAL.GetInsuranceTypebyId(id);

            if(_insuranceType.InsuranceTypeId != 0)
            {
                _insuranceType.InsuranceCompany = _miscellaneousCalls.GetInsuranceCompanybyId(_insuranceType.InsuranceCompany.InsuranceCompanyId);
            }

            return _insuranceType;
        }

        public bool InsertInsuranceType(InsuranceType insuranceType)
        {
            _status = _insuranceTypeDAL.InsertInsuranceType(insuranceType);
            return _status;
        }

        public bool DeleteInsuranceType(int id)
        {
            _status = _insuranceTypeDAL.DeleteInsuranceType(id);
            return _status;
        }

        public bool UpdateInsuranceType(InsuranceType insuranceType, int insuranceTypeId)
        {
            _status = _insuranceTypeDAL.UpdateInsuranceType(insuranceType, insuranceTypeId);
            return _status;
        }
    }
}
