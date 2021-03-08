using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICompanyCountryBLL
    {
        public bool DeleteCompanyCountry(int id);
        public CompanyCountry GetCompanyCountrybyId(int id);
        public bool InsertCompanyCountry(CompanyCountry company);
        public bool UpdateCompanyCountry(CompanyCountry company, int companyCountryId);
    }
}