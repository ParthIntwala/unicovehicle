using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IDistrictBLL
    {
        public bool DeleteDistrict(int id);
        public List<District> Get(int id);
        public District GetDistrictbyId(int id);
        public bool InsertDistrict(string district, int stateId);
    }
}