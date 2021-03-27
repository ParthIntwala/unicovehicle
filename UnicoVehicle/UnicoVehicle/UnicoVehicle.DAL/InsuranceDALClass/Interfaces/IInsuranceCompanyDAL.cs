using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IInsuranceCompanyDAL
    {
        public bool DeleteInsuranceCompany(int id);
        public List<InsuranceCompany> GetInsuranceCompany();
        public InsuranceCompany GetInsuranceCompanybyId(int id);
        public bool InsertInsuranceCompany(InsuranceCompany insuranceCompany);
        public bool UpdateInsuranceCompany(InsuranceCompany insuranceCompany, int insuranceCompanyId);
    }
}