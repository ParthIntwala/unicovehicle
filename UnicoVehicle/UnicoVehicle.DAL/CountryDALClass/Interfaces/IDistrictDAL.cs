using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IDistrictDAL
    {
        public bool DeleteDistrict(int id);
        public List<District> GetDistrict();
        public District GetDistrictbyId(int id);
        public bool InsertDistrict(string district, int stateId);
    }
}