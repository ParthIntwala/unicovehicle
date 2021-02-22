using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ICountryDAL
    {
        public List<Country> GetCountry();
        public bool InsertCountry(string country);
        public Country GetCountrybyId(int id);
        public bool DeleteCountry(int id);
    }
}