using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class ShowroomBLL : IShowroomBLL
    {
        private readonly IShowroomDAL _showroomDAL;
        private readonly IMiscellaneousCallsDAL _miscellaneousCallsDAL;
        bool _status;

        public ShowroomBLL(IMiscellaneousCallsDAL miscellaneousCallsDAL, IShowroomDAL showroomDAL)
        {
            _miscellaneousCallsDAL = miscellaneousCallsDAL;
            _showroomDAL = showroomDAL;
        }

        public List<Showroom> Get()
        {
            List<Showroom> _showroom = _showroomDAL.GetShowroom();

            foreach (Showroom showroom in _showroom)
            {
                showroom.District = _miscellaneousCallsDAL.GetDistrictbyId(showroom.District.DistrictId);
                showroom.Company = _miscellaneousCallsDAL.GetCompanybyId(showroom.Company.CompanyId);
            }

            return _showroom;
        }

        public List<Showroom> GetCompany(int companyId)
        {
            List<Showroom> _showroom = _showroomDAL.GetShowroombyCompany(companyId);

            foreach (Showroom showroom in _showroom)
            {
                showroom.District = _miscellaneousCallsDAL.GetDistrictbyId(showroom.District.DistrictId);
                showroom.Company = _miscellaneousCallsDAL.GetCompanybyId(showroom.Company.CompanyId);
            }

            return _showroom;
        }

        public List<Showroom> GetDistrict(int districtId)
        {
            List<Showroom> _showroom = _showroomDAL.GetShowroombyDistrict(districtId);

            foreach (Showroom showroom in _showroom)
            {
                showroom.District = _miscellaneousCallsDAL.GetDistrictbyId(showroom.District.DistrictId);
                showroom.Company = _miscellaneousCallsDAL.GetCompanybyId(showroom.Company.CompanyId);
            }

            return _showroom;
        }

        public Showroom GetShowroombyId(int id)
        {
            Showroom _showroom = _showroomDAL.GetShowroombyId(id);

            if (_showroom.ShowroomId != 0)
            {
                _showroom.District = _miscellaneousCallsDAL.GetDistrictbyId(_showroom.District.DistrictId);
                _showroom.Company = _miscellaneousCallsDAL.GetCompanybyId(_showroom.Company.CompanyId);
            }

            return _showroom;
        }

        public bool InsertShowroom(Showroom showroom)
        {
            _status = _showroomDAL.InsertShowroom(showroom);
            return _status;
        }

        public bool DeleteShowroom(int id)
        {
            _status = _showroomDAL.DeleteShowroom(id);
            return _status;
        }

        public bool UpdateShowroom(Showroom showroom, int showroomId)
        {
            _status = _showroomDAL.UpdateShowroom(showroom, showroomId);
            return _status;
        }
    }
}
