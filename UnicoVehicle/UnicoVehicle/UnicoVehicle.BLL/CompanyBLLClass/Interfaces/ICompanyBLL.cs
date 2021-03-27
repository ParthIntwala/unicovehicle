using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICompanyBLL
    {
        public bool DeleteCompany(int id);
        public List<Company> Get();
        public Company GetCompanybyId(int id);
        public bool InsertCompany(Company company);
        public bool UpdateCompany(Company company, int companyId);
    }
}