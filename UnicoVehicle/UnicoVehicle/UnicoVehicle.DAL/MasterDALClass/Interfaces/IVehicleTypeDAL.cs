using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleTypeDAL
    {
        public bool DeleteVehicleType(int id);
        public List<VehicleType> GetVehicleType();
        public VehicleType GetVehicleTypebyId(int id);
        public bool InsertVehicleType(string vehicleType);
    }
}