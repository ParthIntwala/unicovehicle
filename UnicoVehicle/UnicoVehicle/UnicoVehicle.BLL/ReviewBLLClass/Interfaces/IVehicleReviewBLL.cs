using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IVehicleReviewBLL
    {
        public bool DeleteVehicleReview(int id);
        public List<VehicleReview> GetbyUser(int id);
        public List<VehicleReview> GetbyVehicle(int id);
        public VehicleReview GetVehicleReviewbyId(int id);
        public bool InsertVehicleReview(VehicleReview vehicleReview);
        public bool UpdateVehicleReview(VehicleReview vehicleReview, int userId);
    }
}