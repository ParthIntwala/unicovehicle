using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleReviewDAL
    {
        public bool DeleteVehicleReview(int id);
        public List<VehicleReview> GetVehicleReview();
        public VehicleReview GetVehicleReviewbyId(int id);
        public bool InsertVehicleReview(VehicleReview vehicleReview);
        public bool UpdateVehicleReview(VehicleReview vehicleReview, int id);
    }
}