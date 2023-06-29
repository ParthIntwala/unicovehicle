using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IVehicleNameBLL
    {
        public bool DeleteVehicleName(int id);
        public List<VehicleName> Get(int id);
        public VehicleName GetVehicleNamebyId(int id);
        public bool InsertVehicleName(VehicleName vehicleName);
        public bool UpdateVehicleName(string vehicleName, int vehicleNameId);
    }
}