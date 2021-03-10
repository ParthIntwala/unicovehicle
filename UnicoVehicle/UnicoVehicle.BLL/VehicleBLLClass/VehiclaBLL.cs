using System;
using UnicoVehicle.DAL;
using System.Collections.Generic;
using UnicoVehicle.DTO;

namespace UnicoVehicle.BLL
{
    public class VehicleBLL : IVehicleBLL
    {
        private readonly IVehicleDAL _vehicleDAL;
        private readonly IVehicleNameBLL _vehicleNameBLL;
        private readonly IVehicleVariantBLL _vehicleVariantBLL;
        private readonly IFuelTypeBLL _fuelTypeBLL;
        private readonly ITransmissionTypeBLL _transmissionTypeBLL;
        private readonly IVehicleTypeBLL _vehicleTypeBLL;
        private readonly ICylinderArrangementBLL _cylinderArrangementBLL;
        bool _status;

        public VehicleBLL(IVehicleNameBLL vehicleNameBLL, IVehicleDAL vehicleDAL, IVehicleVariantBLL vehicleVariantBLL,
            IFuelTypeBLL fuelTypeBLL, ITransmissionTypeBLL transmissionTypeBLL, IVehicleTypeBLL vehicleTypeBLL,
            ICylinderArrangementBLL cylinderArrangementBLL)
        {
            _vehicleNameBLL = vehicleNameBLL;
            _vehicleDAL = vehicleDAL;
            _vehicleTypeBLL = vehicleTypeBLL;
            _vehicleVariantBLL = vehicleVariantBLL;
            _fuelTypeBLL = fuelTypeBLL;
            _transmissionTypeBLL = transmissionTypeBLL;
            _cylinderArrangementBLL = cylinderArrangementBLL;
        }

        public List<Vehicle> GetVehiclebyTransmission(int id)
        {
            List<Vehicle> _vehicles = _vehicleDAL.GetVehiclebyTransmissionType(id);

            foreach (Vehicle _vehicle in _vehicles)
            {
                _vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(_vehicle.VehicleName.VehicleNameId);
                _vehicle.VehicleType = _vehicleTypeBLL.GetVehicleTypebyId(_vehicle.VehicleType.VehicleTypeId);
                _vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(_vehicle.VehicleVariant.VehicleVariantId);
                _vehicle.TransmissionType = _transmissionTypeBLL.GetTransmissionTypebyId(_vehicle.TransmissionType.TransmissionTypeId);
                _vehicle.FuelType = _fuelTypeBLL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementBLL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
            }

            return _vehicles;
        }

        public Vehicle GetVehiclebyId(int id)
        {
            Vehicle _vehicle = _vehicleDAL.GetVehiclebyId(id);

            if (_vehicle.VehicleId != 0)
            {
                _vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(_vehicle.VehicleName.VehicleNameId);
                _vehicle.VehicleType = _vehicleTypeBLL.GetVehicleTypebyId(_vehicle.VehicleType.VehicleTypeId);
                _vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(_vehicle.VehicleVariant.VehicleVariantId);
                _vehicle.TransmissionType = _transmissionTypeBLL.GetTransmissionTypebyId(_vehicle.TransmissionType.TransmissionTypeId);
                _vehicle.FuelType = _fuelTypeBLL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementBLL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
            }

            return _vehicle;
        }

        public bool InsertVehicle(Vehicle vehicle)
        {
            _status = _vehicleDAL.InsertVehicle(vehicle);
            return _status;
        }

        public bool DeleteVehicle(int id)
        {
            _status = _vehicleDAL.DeleteVehicle(id);
            return _status;
        }

        public bool UpdateVehicle(Vehicle vehicle, int vehicleId)
        {
            _status = _vehicleDAL.UpdateVehicle(vehicle, vehicleId);
            return _status;
        }
    }
}
