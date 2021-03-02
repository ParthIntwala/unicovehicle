using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class DistrictBLL : IDistrictBLL
    {
        private readonly IDistrictDAL _districtDAL;
        private readonly IStateBLL _stateBLL;
        bool _status;

        public DistrictBLL(IDistrictDAL districtDAL, IStateBLL stateBLL)
        {
            _districtDAL = districtDAL;
            _stateBLL = stateBLL;
        }

        public List<District> Get()
        {
            List<District> _districts = _districtDAL.GetDistrict();

            foreach (District district in _districts)
            {
                State state = _stateBLL.GetStatebyId(district.StateName.StateId);
                district.StateName = state;
            }

            return _districts;
        }

        public District GetDistrictbyId(int id)
        {
            District _district = _districtDAL.GetDistrictbyId(id);

            if(_district.DistrictId != 0)
            {
                _district.StateName = _stateBLL.GetStatebyId(_district.StateName.StateId);
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
