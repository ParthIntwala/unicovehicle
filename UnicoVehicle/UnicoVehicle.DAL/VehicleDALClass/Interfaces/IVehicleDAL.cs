using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleDAL
    {
        public List<Vehicle> GetVehiclebyTransmissionType(int Id);
        public bool InsertVehicle(Vehicle vehicle);
        public Vehicle GetVehiclebyId(int id);
        public bool DeleteVehicle(int id);
        public bool UpdateVehicle(Vehicle vehicle, int vehicleId);
    }
}