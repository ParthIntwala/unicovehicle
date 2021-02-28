using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleTypeBLL : IVehicleTypeBLL
    {
        private readonly IVehicleTypeDAL _vehicleTypeDAL;
        bool _status;

        public VehicleTypeBLL(IVehicleTypeDAL vehicleTypeDAL)
        {
            _vehicleTypeDAL = vehicleTypeDAL;
        }

        public List<VehicleType> Get()
        {
            List<VehicleType> _vehicleTypes = _vehicleTypeDAL.GetVehicleType();
            return _vehicleTypes;
        }

        public VehicleType GetVehicleTypebyId(int id)
        {
            VehicleType _vehicleType = _vehicleTypeDAL.GetVehicleTypebyId(id);
            return _vehicleType;
        }

        public bool InsertVehicleType(string vehicleType)
        {
            _status = _vehicleTypeDAL.InsertVehicleType(vehicleType);
            return _status;
        }

        public bool DeleteVehicleType(int id)
        {
            _status = _vehicleTypeDAL.DeleteVehicleType(id);
            return _status;
        }
    }
}
