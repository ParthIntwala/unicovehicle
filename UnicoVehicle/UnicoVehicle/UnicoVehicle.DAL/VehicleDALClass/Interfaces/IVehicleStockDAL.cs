using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehicleStockDAL
    {
        public List<VehicleStock> GetVehicleStockbyShowroom(int id);
        public List<VehicleStock> GetVehicleStockbyVehicle(int id);
        public bool InsertVehicleStock(VehicleStock stock);
        public bool UpdateVehicleStock(VehicleStock stock, int id);
    }
}