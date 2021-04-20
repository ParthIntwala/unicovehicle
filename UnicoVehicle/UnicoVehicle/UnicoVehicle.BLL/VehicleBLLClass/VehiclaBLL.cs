﻿using System;
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
        private readonly IFuelTypeDAL _fuelTypeDAL;
        private readonly ITransmissionTypeBLL _transmissionTypeBLL;
        private readonly IVehicleTypeBLL _vehicleTypeBLL;
        private readonly ICylinderArrangementDAL _cylinderArrangementDAL;
        private readonly IVehicleFeatureDAL _vehicleFeaturesDAL;
        bool _status;

        public VehicleBLL(IVehicleNameBLL vehicleNameBLL, IVehicleDAL vehicleDAL, IVehicleVariantBLL vehicleVariantBLL,
            IFuelTypeDAL fuelTypeDAL, ITransmissionTypeBLL transmissionTypeBLL, IVehicleTypeBLL vehicleTypeBLL,
            ICylinderArrangementDAL cylinderArrangementDAL, IVehicleFeatureDAL vehicleFeatureDAL)
        {
            _vehicleNameBLL = vehicleNameBLL;
            _vehicleDAL = vehicleDAL;
            _vehicleTypeBLL = vehicleTypeBLL;
            _vehicleVariantBLL = vehicleVariantBLL;
            _fuelTypeDAL = fuelTypeDAL;
            _transmissionTypeBLL = transmissionTypeBLL;
            _cylinderArrangementDAL = cylinderArrangementDAL;
            _vehicleFeaturesDAL = vehicleFeatureDAL;
        }

        public List<Vehicle> GetVehiclebyTransmission(int id, int nameId)
        {
            List<Vehicle> _vehicles = _vehicleDAL.GetVehiclebyTransmissionType(id, nameId);

            foreach (Vehicle _vehicle in _vehicles)
            {
                _vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(_vehicle.VehicleName.VehicleNameId);
                _vehicle.VehicleType = _vehicleTypeBLL.GetVehicleTypebyId(_vehicle.VehicleType.VehicleTypeId);
                _vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(_vehicle.VehicleVariant.VehicleVariantId);
                _vehicle.TransmissionType = _transmissionTypeBLL.GetTransmissionTypebyId(_vehicle.TransmissionType.TransmissionTypeId);
                _vehicle.FuelType = _fuelTypeDAL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementDAL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
                _vehicle.VehicleFeatures = _vehicleFeaturesDAL.GetVehicleFeaturebyId(_vehicle.VehicleId);
            }

            return _vehicles;
        }

        public List<Vehicle> GetVehiclebyVehicleType(int id, int nameId)
        {
            List<Vehicle> _vehicles = _vehicleDAL.GetVehiclebyVehicleType(id, nameId);

            foreach (Vehicle _vehicle in _vehicles)
            {
                _vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(_vehicle.VehicleName.VehicleNameId);
                _vehicle.VehicleType = _vehicleTypeBLL.GetVehicleTypebyId(_vehicle.VehicleType.VehicleTypeId);
                _vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(_vehicle.VehicleVariant.VehicleVariantId);
                _vehicle.TransmissionType = _transmissionTypeBLL.GetTransmissionTypebyId(_vehicle.TransmissionType.TransmissionTypeId);
                _vehicle.FuelType = _fuelTypeDAL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementDAL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
                _vehicle.VehicleFeatures = _vehicleFeaturesDAL.GetVehicleFeaturebyId(_vehicle.VehicleId);
            }

            return _vehicles;
        }

        public List<Vehicle> GetVehiclebyFuel(int id, int nameId)
        {
            List<Vehicle> _vehicles = _vehicleDAL.GetVehiclebyFuelType(id, nameId);

            foreach (Vehicle _vehicle in _vehicles)
            {
                _vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(_vehicle.VehicleName.VehicleNameId);
                _vehicle.VehicleType = _vehicleTypeBLL.GetVehicleTypebyId(_vehicle.VehicleType.VehicleTypeId);
                _vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(_vehicle.VehicleVariant.VehicleVariantId);
                _vehicle.TransmissionType = _transmissionTypeBLL.GetTransmissionTypebyId(_vehicle.TransmissionType.TransmissionTypeId);
                _vehicle.FuelType = _fuelTypeDAL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementDAL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
                _vehicle.VehicleFeatures = _vehicleFeaturesDAL.GetVehicleFeaturebyId(_vehicle.VehicleId);
            }

            return _vehicles;
        }

        public List<Vehicle> GetVehiclebyName(int id)
        {
            List<Vehicle> _vehicles = _vehicleDAL.GetVehiclesbyName(id);

            foreach (Vehicle _vehicle in _vehicles)
            {
                _vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(_vehicle.VehicleName.VehicleNameId);
                _vehicle.VehicleType = _vehicleTypeBLL.GetVehicleTypebyId(_vehicle.VehicleType.VehicleTypeId);
                _vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(_vehicle.VehicleVariant.VehicleVariantId);
                _vehicle.TransmissionType = _transmissionTypeBLL.GetTransmissionTypebyId(_vehicle.TransmissionType.TransmissionTypeId);
                _vehicle.FuelType = _fuelTypeDAL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementDAL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
                _vehicle.VehicleFeatures = _vehicleFeaturesDAL.GetVehicleFeaturebyId(_vehicle.VehicleId);
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
                _vehicle.FuelType = _fuelTypeDAL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementDAL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
                _vehicle.VehicleFeatures = _vehicleFeaturesDAL.GetVehicleFeaturebyId(_vehicle.VehicleId);
            }

            return _vehicle;
        }

        public Vehicle GetVehiclebyVariant(int id, int nameId)
        {
            Vehicle _vehicle = _vehicleDAL.GetVehiclebyVariant(id, nameId);

            if (_vehicle.VehicleId != 0)
            {
                _vehicle.VehicleName = _vehicleNameBLL.GetVehicleNamebyId(_vehicle.VehicleName.VehicleNameId);
                _vehicle.VehicleType = _vehicleTypeBLL.GetVehicleTypebyId(_vehicle.VehicleType.VehicleTypeId);
                _vehicle.VehicleVariant = _vehicleVariantBLL.GetVehicleVariantbyId(_vehicle.VehicleVariant.VehicleVariantId);
                _vehicle.TransmissionType = _transmissionTypeBLL.GetTransmissionTypebyId(_vehicle.TransmissionType.TransmissionTypeId);
                _vehicle.FuelType = _fuelTypeDAL.GetFuelTypebyId(_vehicle.FuelType.FuelTypeId);
                _vehicle.CylinderArrangement = _cylinderArrangementDAL.GetCylinderArrangementbyId(_vehicle.CylinderArrangement.CylinderArrangementId);
                _vehicle.VehicleFeatures = _vehicleFeaturesDAL.GetVehicleFeaturebyId(_vehicle.VehicleId);
            }

            return _vehicle;
        }

        public bool InsertVehicle(Vehicle vehicle)
        {
            _status = _vehicleDAL.InsertVehicle(vehicle);

            if(_status)
            {
                int id = _vehicleDAL.GetLastVehicleId();

                if(id == -1)
                {
                    return false;
                }

                _status = _vehicleFeaturesDAL.InsertVehicleFeature(vehicle.VehicleFeatures, id);
            }

            return _status;
        }

        public bool DeleteVehicle(int id)
        {
            _status = _vehicleDAL.DeleteVehicle(id);

            if(_status)
            {
                _status = _vehicleFeaturesDAL.DeleteVehicleFeature(id);
            }

            return _status;
        }

        public bool UpdateVehicle(Vehicle vehicle, int vehicleId)
        {
            _status = _vehicleDAL.UpdateVehicle(vehicle, vehicleId);

            if(_status)
            {
                _status = _vehicleFeaturesDAL.UpdateVehicleFeature(vehicle.VehicleFeatures);
            }

            return _status;
        }
    }
}
