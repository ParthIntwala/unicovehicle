using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class DistrictBLL : IDistrictBLL
    {
        private readonly IDistrictDAL _districtDAL;
        private readonly IMiscellaneousCalls _miscellaneousCalls;
        bool _status;

        public DistrictBLL(IDistrictDAL districtDAL, IMiscellaneousCalls miscellaneousCalls)
        {
            _districtDAL = districtDAL;
            _miscellaneousCalls = miscellaneousCalls;
        }

        public List<District> Get(int id)
        {
            List<District> _districts = _districtDAL.GetDistrict(id);

            foreach (District district in _districts)
            {
                district.State = _miscellaneousCalls.GetStatebyId(district.State.StateId);
            }

            return _districts;
        }

        public District GetDistrictbyId(int id)
        {
            District _district = _districtDAL.GetDistrictbyId(id);

            if(_district.DistrictId != 0)
            {
                _district.State = _miscellaneousCalls.GetStatebyId(_district.State.StateId);
            }

            return _district;
        }

        public bool InsertDistrict(string district, int stateId)
        {
            _status = _districtDAL.InsertDistrict(district, stateId);
            return _status;
        }

        public bool DeleteDistrict(int id)
        {
            _status = _districtDAL.DeleteDistrict(id);
            return _status;
        }
    }
}
