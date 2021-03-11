using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleDAL
    {
        public List<Vehicle> GetVehiclebyTransmissionType(int Id, int nameId);
        public List<Vehicle> GetVehiclesbyName(int Id);
        public List<Vehicle> GetVehiclebyFuelType(int Id, int nameId);
        public List<Vehicle> GetVehiclebyVehicleType(int Id, int nameId);
        public bool InsertVehicle(Vehicle vehicle);
        public Vehicle GetVehiclebyId(int id);
        public Vehicle GetVehiclebyVariant(int id, int nameId);
        public bool DeleteVehicle(int id);
        public bool UpdateVehicle(Vehicle vehicle, int vehicleId);
    }
}