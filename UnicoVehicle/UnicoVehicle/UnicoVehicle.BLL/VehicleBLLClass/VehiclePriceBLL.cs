using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehiclePriceBLL : IVehiclePriceBLL
    {
        private readonly IVehiclePriceDAL _vehiclePriceDAL;
        private readonly IMiscellaneousCallsBLL _miscellaneousCallsBLL;
        bool _status;

        public VehiclePriceBLL(IVehiclePriceDAL vehiclePriceDAL, IMiscellaneousCallsBLL miscellaneousCallsBLL)
        {
            _vehiclePriceDAL = vehiclePriceDAL;
            _miscellaneousCallsBLL = miscellaneousCallsBLL;
        }

        public List<VehiclePrice> GetbyShowroom(int id)
        {
            List<VehiclePrice> _vehiclePrice = _vehiclePriceDAL.GetVehiclePricebyShowroom(id);

            foreach (VehiclePrice vehicle in _vehiclePrice)
            {
                vehicle.Showroom = _miscellaneousCallsBLL.GetShowroombyId(vehicle.Showroom.ShowroomId);
                vehicle.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(vehicle.Vehicle.VehicleId);
            }

            return _vehiclePrice;
        }

        public List<VehiclePrice> GetbyVehicle(int id)
        {
            List<VehiclePrice> _vehiclePrice = _vehiclePriceDAL.GetVehiclePricebyVehicle(id);

            foreach (VehiclePrice vehicle in _vehiclePrice)
            {
                vehicle.Showroom = _miscellaneousCallsBLL.GetShowroombyId(vehicle.Showroom.ShowroomId);
                vehicle.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(vehicle.Vehicle.VehicleId);
            }

            return _vehiclePrice;
        }

        public bool InsertVehiclePrice(VehiclePrice vehiclePrice)
        {
            _status = _vehiclePriceDAL.InsertVehiclePrice(vehiclePrice);
            return _status;
        }

        public bool UpdateVehiclePrice(VehiclePrice vehiclePrice, int vehiclePriceId)
        {
            _status = _vehiclePriceDAL.UpdateVehiclePrice(vehiclePrice, vehiclePriceId);
            return _status;
        }
    }
}
