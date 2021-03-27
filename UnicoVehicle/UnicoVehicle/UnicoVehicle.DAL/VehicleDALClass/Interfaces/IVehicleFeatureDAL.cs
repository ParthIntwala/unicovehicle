using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleFeatureDAL
    {
        public bool DeleteVehicleFeature(int id);
        public VehicleFeatures GetVehicleFeaturebyId(int id);
        public bool InsertVehicleFeature(VehicleFeatures feature, int id);
        public bool UpdateVehicleFeature(VehicleFeatures feature);
    }
}