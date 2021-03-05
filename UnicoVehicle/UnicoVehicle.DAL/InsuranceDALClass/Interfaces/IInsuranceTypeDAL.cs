using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IInsuranceTypeDAL
    {
        public bool DeleteInsuranceType(int id);
        public List<InsuranceType> GetInsuranceType();
        public InsuranceType GetInsuranceTypebyId(int id);
        public bool InsertInsuranceType(InsuranceType insuranceType);
        public bool UpdateInsuranceType(InsuranceType insuranceType, int insuranceTypeId);
    }
}