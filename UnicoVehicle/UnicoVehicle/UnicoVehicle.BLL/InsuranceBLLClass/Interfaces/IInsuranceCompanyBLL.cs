using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IInsuranceCompanyBLL
    {
        public bool DeleteInsuranceCompany(int id);
        public List<InsuranceCompany> Get();
        public InsuranceCompany GetInsuranceCompanybyId(int id);
        public bool InsertInsuranceCompany(InsuranceCompany insuranceCompany);
        public bool UpdateInsuranceCompany(InsuranceCompany InsuranceCompany, int insuranceCompanyId);
    }
}