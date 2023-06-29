using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IDistrictBLL
    {
        public bool DeleteDistrict(int id);
        public List<District> Get(int id);
        public bool InsertDistrict(string district, int stateId);
        public DTO.Details.District GetDistrictbyId(int id);
    }
}