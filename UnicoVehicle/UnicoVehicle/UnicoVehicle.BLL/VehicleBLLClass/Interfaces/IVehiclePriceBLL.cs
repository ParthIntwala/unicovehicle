using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public interface IVehiclePriceBLL
    {
        public List<VehiclePrice> GetbyShowroom(int id);
        public List<VehiclePrice> GetbyVehicle(int id);
        public bool InsertVehiclePrice(VehiclePrice vehiclePrice);
        public bool UpdateVehiclePrice(VehiclePrice vehiclePrice, int vehiclePriceId);
    }
}