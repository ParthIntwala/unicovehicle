using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.DAL
{
    public interface IVehiclePriceDAL
    {
        public List<VehiclePrice> GetVehiclePricebyShowroom(int id);
        public List<VehiclePrice> GetVehiclePricebyVehicle(int id);
        public bool InsertVehiclePrice(VehiclePrice price);
        public bool UpdateVehiclePrice(VehiclePrice price, int id);
    }
}