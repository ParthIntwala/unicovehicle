using UnicoVehicle.DTO;
using System.Collections.Generic;

namespace UnicoVehicle.BLL
{
    public interface IVehicleBLL
    {
        public bool InsertVehicle(Vehicle vehicle);
        public Vehicle GetVehiclebyId(int id);
        public Vehicle GetVehiclebyVariant(int id, int nameId);
        public List<Vehicle> GetVehiclebyTransmission(int id, int nameId);
        public List<Vehicle> GetVehiclebyFuel(int id, int nameId);
        public List<Vehicle> GetVehiclebyVehicleType(int id, int nameId);
        public List<Vehicle> GetVehiclebyName(int id);
        public bool DeleteVehicle(int id);
        public bool UpdateVehicle(Vehicle vehicle, int vehicleId);
    }
}