using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class DistrictBLL : IDistrictBLL
    {
        private readonly IDistrictDAL _districtDAL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public DistrictBLL(IDistrictDAL districtDAL, IMiscellaneousCallsDAL miscellaneousCallsDAL)
        {
            _districtDAL = districtDAL;
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
        }

        public List<District> Get(int id)
        {
            List<District> _districts = _districtDAL.GetDistrict(id);

            foreach (District district in _districts)
            {
                district.State = _miscellaneousCallsDAL.GetStatebyId(district.State.StateId);
            }

            return _districts;
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
