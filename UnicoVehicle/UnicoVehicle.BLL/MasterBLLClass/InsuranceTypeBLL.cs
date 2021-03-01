using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class InsuranceTypeBLL : IInsuranceTypeBLL
    {
        private readonly IInsuranceTypeDAL _insuranceTypeDAL;
        bool _status;

        public InsuranceTypeBLL(IInsuranceTypeDAL insuranceTypeDAL)
        {
            _insuranceTypeDAL = insuranceTypeDAL;
        }

        public List<InsuranceType> Get()
        {
            List<InsuranceType> _insuranceType = _insuranceTypeDAL.GetInsuranceType();
            return _insuranceType;
        }

        public InsuranceType GetInsuranceTypebyId(int id)
        {
            InsuranceType _insuranceType = _insuranceTypeDAL.GetInsuranceTypebyId(id);
            return _insuranceType;
        }

        public bool InsertInsuranceType(string insuranceType)
        {
            _status = _insuranceTypeDAL.InsertInsuranceType(insuranceType);
            return _status;
        }

        public bool DeleteInsuranceType(int id)
        {
            _status = _insuranceTypeDAL.DeleteInsuranceType(id);
            return _status;
        }

        public bool UpdateInsuranceType(string insuranceType, int insuranceTypeId)
        {
            _status = _insuranceTypeDAL.UpdateInsuranceType(insuranceType, insuranceTypeId);
            return _status;
        }
    }
}
