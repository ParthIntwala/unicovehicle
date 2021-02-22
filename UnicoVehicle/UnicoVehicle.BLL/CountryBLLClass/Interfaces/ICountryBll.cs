using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICountryBll
    {
        public List<Country> Get();
        public bool InsertCountry(string country);
        public Country GetCountrybyId(int id);
        public bool DeleteCountry(int id);
    }
}