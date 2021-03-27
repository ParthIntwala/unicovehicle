using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ICompanyDAL
    {
        public bool DeleteCompany(int id);
        public List<Company> GetCompany();
        public Company GetCompanybyId(int id);
        public bool InsertCompany(Company company);
        public bool UpdateCompany(Company company, int id);
    }
}