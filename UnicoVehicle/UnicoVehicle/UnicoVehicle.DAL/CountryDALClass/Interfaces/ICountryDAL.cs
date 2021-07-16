using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ICountryDAL
    {
        public List<Country> GetCountry();
        public Country GetCountrybyId(int id);
        public bool InsertCountry(string country);
        public bool DeleteCountry(int id);
    }
}