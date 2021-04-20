using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleNameDAL
    {
        public bool DeleteVehicleName(int id);
        public List<VehicleName> GetVehicleName(int id);
        public VehicleName GetVehicleNamebyId(int id);
        public bool InsertVehicleName(VehicleName vehicle);
        public bool UpdateVehicleName(string vehicle, int id);
    }
}