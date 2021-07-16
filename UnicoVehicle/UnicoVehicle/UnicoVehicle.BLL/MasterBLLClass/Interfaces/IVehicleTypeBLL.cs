using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IVehicleTypeBLL
    {
        public bool DeleteVehicleType(int id);
        public List<VehicleType> Get();
        public VehicleType GetVehicleTypebyId(int id);
        public bool InsertVehicleType(string vehicleType);
    }
}