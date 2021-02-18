using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface ICountryBll
    {
        List<Country> get();
        public bool insertCountry(string country);
        public Country getCountrybyId(int id);
    }
}