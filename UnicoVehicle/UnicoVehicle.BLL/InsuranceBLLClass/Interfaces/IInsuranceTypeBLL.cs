using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IInsuranceTypeBLL
    {
        public bool DeleteInsuranceType(int id);
        public List<InsuranceType> Get();
        public InsuranceType GetInsuranceTypebyId(int id);
        public bool InsertInsuranceType(InsuranceType insuranceType);
        public bool UpdateInsuranceType(InsuranceType insuranceType, int insuranceTypeId);
    }
}