using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleStockBLL : IVehicleStockBLL
    {
        private readonly IVehicleStockDAL _vehicleStockDAL;
        private readonly IMiscellaneousCallsBLL _miscellaneousCallsBLL;
        bool _status;

        public VehicleStockBLL(IVehicleStockDAL vehicleStockDAL, IMiscellaneousCallsBLL miscellaneousCallsBLL)
        {
            _vehicleStockDAL = vehicleStockDAL;
            _miscellaneousCallsBLL = miscellaneousCallsBLL;
        }

        public List<VehicleStock> GetbyShowroom(int id)
        {
            List<VehicleStock> _vehicleStock = _vehicleStockDAL.GetVehicleStockbyShowroom(id);

            foreach (VehicleStock vehicle in _vehicleStock)
            {
                vehicle.Showroom = _miscellaneousCallsBLL.GetShowroombyId(vehicle.Showroom.ShowroomId);
                vehicle.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(vehicle.Vehicle.VehicleId);
            }

            return _vehicleStock;
        }

        public List<VehicleStock> GetbyVehicle(int id)
        {
            List<VehicleStock> _vehicleStock = _vehicleStockDAL.GetVehicleStockbyVehicle(id);

            foreach (VehicleStock vehicle in _vehicleStock)
            {
                vehicle.Showroom = _miscellaneousCallsBLL.GetShowroombyId(vehicle.Showroom.ShowroomId);
                vehicle.Vehicle = _miscellaneousCallsBLL.GetVehiclebyId(vehicle.Vehicle.VehicleId);
            }

            return _vehicleStock;
        }

        public bool InsertVehicleStock(VehicleStock vehicleStock)
        {
            _status = _vehicleStockDAL.InsertVehicleStock(vehicleStock);
            return _status;
        }

        public bool UpdateVehicleStock(VehicleStock vehicleStock, int vehicleStockId)
        {
            _status = _vehicleStockDAL.UpdateVehicleStock(vehicleStock, vehicleStockId);
            return _status;
        }
    }
}
