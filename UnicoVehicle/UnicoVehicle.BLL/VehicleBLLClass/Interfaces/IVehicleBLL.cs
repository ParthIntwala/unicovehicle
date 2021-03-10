using UnicoVehicle.DTO;
using System.Collections.Generic;

namespace UnicoVehicle.BLL
{
    public interface IVehicleBLL
    {
        public bool InsertVehicle(Vehicle vehicle);
        public Vehicle GetVehiclebyId(int id);
        public List<Vehicle> GetVehiclebyTransmission(int id);
        public bool DeleteVehicle(int id);
        public bool UpdateVehicle(Vehicle vehicle, int vehicleId);
    }
}