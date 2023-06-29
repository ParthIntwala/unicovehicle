using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICountryBll
    {
        public List<Country> Get();
        public bool InsertCountry(string country);
        public bool DeleteCountry(int id);
    }
}