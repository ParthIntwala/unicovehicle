using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ICompanyCountryDAL
    {
        public bool DeleteCompanyCountry(int id);
        public List<CompanyCountry> GetCompanyCountry();
        public CompanyCountry GetCompanyCountrybyId(int id);
        public bool InsertCompanyCountry(CompanyCountry company);
        public bool UpdateCompanyCountry(CompanyCountry company, int id);
    }
}