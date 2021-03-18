using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleFeatureDAL
    {
        public bool DeleteVehicleFeature(int id);
        public VehicleFeatures GetVehicleFeaturebyId(int id);
    }
}