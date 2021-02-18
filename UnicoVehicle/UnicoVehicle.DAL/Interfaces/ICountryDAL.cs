using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface ICountryDAL
    {
        List<Country> getCountry();
        public bool insertCountry(string country);
        public Country getCountrybyId(int id);
    }
}