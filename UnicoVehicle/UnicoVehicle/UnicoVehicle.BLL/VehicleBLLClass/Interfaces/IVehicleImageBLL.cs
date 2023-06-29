using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IVehicleImageBLL
    {
        public VehicleImages GetVehicleImagesbyId(int id);
        public bool InsertVehicleImages(VehicleImages image, int id);
        public bool UpdateVehicleImages(VehicleImages image, int id);
    }
}