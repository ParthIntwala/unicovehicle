using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleImagesDAL
    {
        public VehicleImages GetVehicleImagesbyId(int id);
        public bool InsertVehicleImages(VehicleImages image, int id);
        public bool UpdateVehicleImages(VehicleImages image);
    }
}