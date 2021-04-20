using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleReviewBLL : IVehicleReviewBLL
    {
        private readonly IVehicleReviewDAL _vehicleReviewDAL;
        private readonly IUserBLL _userBLL;
        private readonly IMiscellaneousCallsBLL _miscellaneousCallsBLL;
        bool _status;

        public VehicleReviewBLL(IVehicleReviewDAL vehicleReviewDAL, IUserBLL userBLL, IMiscellaneousCallsBLL miscellaneousCallsBLL)
        {
            _vehicleReviewDAL = vehicleReviewDAL;
            _userBLL = userBLL;
            _miscellaneousCallsBLL = miscellaneousCallsBLL;
        }

        public List<VehicleReview> GetbyUser(int id)
        {
            List<VehicleReview> _vehicleReview = _vehicleReviewDAL.GetVehicleReviewbyUser(id);

            foreach (VehicleReview vehicleReview in _vehicleReview)
            {
                vehicleReview.User = _userBLL.GetUserbyId(vehicleReview.User.UserId);
                vehicleReview.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(vehicleReview.Vehicle.VehicleId);
            }

            return _vehicleReview;
        }

        public List<VehicleReview> GetbyVehicle(int id)
        {
            List<VehicleReview> _vehicleReview = _vehicleReviewDAL.GetVehicleReviewbyVehicle(id);

            foreach (VehicleReview vehicleReview in _vehicleReview)
            {
                vehicleReview.User = _userBLL.GetUserbyId(vehicleReview.User.UserId);
                vehicleReview.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(vehicleReview.Vehicle.VehicleId);
            }

            return _vehicleReview;
        }

        public VehicleReview GetVehicleReviewbyId(int id)
        {
            VehicleReview _vehicleReview = _vehicleReviewDAL.GetVehicleReviewbyId(id);

            if (_vehicleReview.VehicleReviewId != 0)
            {
                _vehicleReview.User = _userBLL.GetUserbyId(_vehicleReview.User.UserId);
                _vehicleReview.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(_vehicleReview.Vehicle.VehicleId);
            }

            return _vehicleReview;
        }

        public bool InsertVehicleReview(VehicleReview vehicleReview)
        {
            _status = _vehicleReviewDAL.InsertVehicleReview(vehicleReview);
            return _status;
        }

        public bool DeleteVehicleReview(int id)
        {
            _status = _vehicleReviewDAL.DeleteVehicleReview(id);
            return _status;
        }

        public bool UpdateVehicleReview(VehicleReview vehicleReview, int userId)
        {
            _status = _vehicleReviewDAL.UpdateVehicleReview(vehicleReview, userId);
            return _status;
        }
    }
}
