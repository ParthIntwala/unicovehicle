using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IVehicleStockBLL
    {
        public List<VehicleStock> GetbyShowroom(int id);
        public List<VehicleStock> GetbyVehicle(int id);
        public bool InsertVehicleStock(VehicleStock vehicleStock);
        public bool UpdateVehicleStock(VehicleStock vehicleStock, int vehicleStockId);
    }
}